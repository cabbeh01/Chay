using MongoDBLogin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using ChayPackages;
using Chay;
using MongoDB.Bson;

namespace ChayServer
{
    class Program
    {
        /// <summary>Databasen</summary>
        static MongoCRUD _db = new MongoCRUD("dbChay");

        /// <summary>TCP lyssnare</summary>
        static TcpListener listener;

        /// <summary>TCP client</summary>
        static TcpClient client;

        /// <summary>Servern</summary>
        static Server s = new Server();

        /// <summary>
        /// Standardkonstruktor för kommandoapplikation
        /// </summary>
        static void Main(string[] args)
        {
            try
            {
                //Skriver ut nödvändig information
                Console.WriteLine("Servern kopplar upp sig");

                //Kontrollerar databasen
                CheckDatabase();
                
                //Startar servern
                StartServer();

                //Väntar på att användaren ska mata in ett kommando i konsolen
                UserInputAsync();
                client.NoDelay = true;
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Ett problem uppstod vänligen kontakta utvecklaren");
            }
        }

        /// <summary>
        /// Starta servern
        /// </summary>
        static void StartServer()
        {
            try
            {
                //Låter användaren välja vilken port serverna ska starta på
                Console.Write("Vänligen välj en port: ");
                int port = int.Parse(Console.ReadLine());

                //Skapar en lyssanre
                listener = new TcpListener(IPAddress.Any, port);

                //Startar lyssningen
                listener.Start();

                //Gör en lista för alla uppkopplade användare
                s.Users = new List<User>();
                
                //Sätter serverporten till porten som användaren valde
                s.Port = port;

                
                Console.Clear();
                
                //Skriver ut anslutnings informationen till servern
                Console.WriteLine("För information om vilka kommandon som finns tillgängliga vänlig använd \" help \" ");
                Console.WriteLine("_________________________________________________________________________________ \n");
                Console.WriteLine($"Server started at 127.0.0.1:{port}\n"); 
            }
            catch
            {
                //Matar inte användaren in en port
                //Skrivs detta ut på skärmen
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Vänligen mata in en korrekt port");
                Console.ForegroundColor = ConsoleColor.Gray;

                //Kör metoden igen
                StartServer();
            }

            //Startar Handshake
            StartHandshake();
        }

        /// <summary>
        /// Kollar databasen
        /// </summary>
        static void CheckDatabase()
        {
            try
            {
                //Existerar filen env
                if (File.Exists("env"))
                {
                    //Hämstar alla serverar på databasen
                    List<Server> ls = _db.GetAll<Server>("Servers");

                    //Hämtar ObjectID från filen
                    MongoDB.Bson.ObjectId objID = GetObjectID();
                    
                    foreach (Server serv in ls)
                    {
                        //Finns ObjectID:et
                        if (serv.Id == GetObjectID())
                        {
                            //Sätter server objektet till serv
                            s = serv;
                            
                            Console.Write("Databas  |   ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("fungerar");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine("\n\n");
                        }
                    }
                }
                else
                {
                    //Annars skapar den ett ObjektID samt fil
                    SetObjectID();
                }
            }
            catch(Exception err)
            {
                Console.WriteLine(err);
            }

        }

        /// <summary>
        /// Skapar ObjektID
        /// </summary>
        static void SetObjectID()
        {
            try
            {
                //Öppnar en filströmm
                FileStream stream = new FileStream("env", FileMode.OpenOrCreate, FileAccess.Write);

                //Skapar en skrivare
                StreamWriter writer = new StreamWriter(stream);

                //Genererar ObjectID
                s.Id = _db.GenID();

                //Skriver ID till filen
                writer.Write(s.Id);

                //Släpper resurser
                writer.Dispose();


                try
                {
                    //Sätter in ID:et i databasen
                    _db.InsertOne("Servers", s);

                    Console.Write("Databas  |   ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("fungerar");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("\n\n");
                }
                catch
                {
                    Console.Write("Databas  |   ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("misslyckades");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("\n\n");
                }
                
            }
            catch
            {
                Console.WriteLine("Går inte spara");
            }

        }

        /// <summary>
        /// Hämtar ObjektID
        /// </summary>
        /// <returns>Returnerar objektID om dewt finns</returns>
        static ObjectId GetObjectID()
        {
            try
            {
                //Öppnar strömm
                FileStream stream = new FileStream("env", FileMode.Open, FileAccess.Read);

                //Deklarerar läsare
                StreamReader reader = new StreamReader(stream);

                //Hämtar ObjectID
                ObjectId a = ObjectId.Parse(reader.ReadLine());

                //Släpper resurser
                reader.Dispose();
                return a;
            }
            catch
            {
                return ObjectId.Empty;
            }

        }

        /// <summary>
        /// Startar Handshake mellan sever och klient
        /// </summary>
        static async void StartHandshake()
        {
            try
            {
                //Hittar den en användare som försöker ansluta
                client = await listener.AcceptTcpClientAsync();

                //Kopplar klienten till en User
                User a = new User(client);

                //Lägger till användaren i användarlistan
                s.Users.Add(a);
                
                //Börjar läsa
                StartReading(a);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //Väntar på att någon ny ska ansluta
            StartHandshake();
        }

        /// <summary>
        /// Skickar ID till användare
        /// </summary>
        /// <param name="id">ObjectID:et</param>
        /// <param name="client">Klienten</param>
        static void SendId(ObjectId id, TcpClient client)
        {
            try
            {
                //Buffert minne till att skicka
                byte[] byteId = new byte[254];
                
                //Gör om ID:et till byte
                byteId = Encoding.Unicode.GetBytes(id.ToString());
                
                //Skickar ID:et till klienten
                client.GetStream().Write(byteId, 0, byteId.Length);
            }
            catch
            {
                Console.WriteLine("Gick inte att skicka id");
            }
        }

        /// <summary>
        /// Påbörjar läsning
        /// </summary>
        /// <param name="u">Användaren</param>
        static async void StartReading(User u)
        {
            try
            {
                //Är klienten uppkopplad
                if (u.Client.Connected)
                {
                    
                    // [Metadata]--[DATA]--[END]
                    try
                    {
                        byte[] meta = new byte[8];
                        NetworkStream stream = u.Client.GetStream();
                        await stream.ReadAsync(meta, 0, meta.Length);

                        int len = int.Parse(Encoding.ASCII.GetString(meta));
                        //Console.WriteLine(len);
                        await Task.Run(async () => {

                            byte[] tempbuffer = new byte[len];
                            stream.Read(tempbuffer, 0, tempbuffer.Length);

                            Message incomming = (Message)ByteArrayToObject(tempbuffer);

                            if (incomming.SysMess && incomming.Text == "connected")
                            {
                                Console.Write($"\n{incomming.Auther.Id}: ({incomming.Auther.Name}) joinade servern");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("  +\n");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                foreach (User a in s.Users)
                                {
                                    if(a.Client == u.Client)
                                    {
                                        a.Id = incomming.Auther.Id;
                                        a.Username = incomming.Auther.Username;
                                        a.Name = incomming.Auther.Name;
                                        //Console.WriteLine(s.Id);
                                        SendId(s.Id, u.Client);
                                        _db.UpdateOne<Server>("Servers", s.Id, s);
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine($"{incomming.Auther.Name}: {incomming.Text}");
                                if(s.Messages == null)
                                {
                                    s.Messages = new List<Message>();
                                }
                                s.Messages.Add(incomming);
                                await UpdateMessageDB();

                                byte[] backToClient = new byte[64];
                                backToClient = Encoding.Unicode.GetBytes("newmess");
                                Broadcast(backToClient);
                            }

                        });

                    }
                    catch(Exception ex)
                    {
                        //Console.WriteLine("Ett fel uppstod \n" + ex.ToString());
                        if (ex.GetType().IsAssignableFrom(typeof(System.IO.IOException)))
                        {
                            u.Client.Dispose();
                            s.Users.Remove(u);
                            _db.UpdateOne<Server>("Servers", s.Id, s);
                            Console.Write($"\n{u.Id}: ({u.Name}) lämnade servern");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("  -");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        else
                        {
                            StartReading(u);
                        }
                        
                    }

                    StartReading(u);
                }
                else
                {
                    u.Client.Dispose();
                    s.Users.Remove(u);
                }
            }
            catch(Exception ex)
            {
                u.Client.Dispose();
                s.Users.Remove(u);

                Console.WriteLine(ex.ToString());
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arrBytes"></param>
        /// <returns>Returnerar objektet</returns>
        static Object ByteArrayToObject(byte[] arrBytes)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter binForm = new BinaryFormatter();
                ms.Write(arrBytes, 0, arrBytes.Length);
                ms.Seek(0, SeekOrigin.Begin);
                Object obj = (Object)binForm.Deserialize(ms);
                return obj;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        static async Task UpdateMessageDB()
        {
            try
            {
                await Task.Run(() => {
                    if (s.Messages == null)
                    {
                        s.Messages = new List<Message>();
                    }
                    _db.UpdateOne<Server>("Servers", s.Id, s);
                });
            }
            catch
            {
                Console.WriteLine("Ett fel uppstod");
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        static async void Broadcast(byte[] data)
        {
            try
            {
                foreach (User c in s.Users)
                {
                    Console.WriteLine("");
                    await c.Client.GetStream().WriteAsync(data, 0, data.Length);
                    //Console.WriteLine("Har nu broadcastat");
                }
            }
            catch
            {
                Console.WriteLine("Går inte att broadcasta");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        static void UserInputAsync()
        {
            try
            {
                
                Console.Write("> ");
                string data = Console.ReadLine();
                if (string.IsNullOrEmpty(data))
                {
                    UserInputAsync();
                }
                data.Remove(0, 1);
                string[] dataSplice = data.Split();
                switch (dataSplice[0].ToLower())
                {
                    case "kick":
                        if (!String.IsNullOrEmpty(dataSplice[1]))
                        {
                            KickUser(dataSplice[1]);
                        }
                        else
                        {
                            Console.Write(dataSplice[0] + "\n" + dataSplice[1]);
                            Console.WriteLine("Du måste mata in en användare som du vill kicka");
                        }
                        break;

                    case "ls":

                        ListUsers();
                        break;

                    case "clear":

                        Console.Clear();
                        break;

                    case "clean":

                        try
                        {
                            s.Messages.Clear();
                            _db.UpdateOne<Server>("Servers", s.Id, s);
                            byte[] backToClient = new byte[64];
                            backToClient = Encoding.Unicode.GetBytes("newmess");
                            Broadcast(backToClient);
                        }
                        catch
                        {
                            Console.Clear();
                            Console.WriteLine("Det går inte rensa meddelandena");
                        }
                        
                        break;


                    case "help":
                        Console.Clear();
                        Console.WriteLine("Dessa kommandona finns tillgängliga");
                        Console.WriteLine("___________________________________________________");
                        Console.WriteLine("help - Visar de kommandon som finns tillgänliga");
                        Console.WriteLine("kick XX- Stänger ner en uppkoppling mellan servern och en användare");
                        Console.WriteLine("ls - Visar de användare som är uppkopplade mot servern");
                        Console.WriteLine("clear - Rensar terminalens utmatning");
                        Console.WriteLine("clean - Rensar alla meddelande på servern och databasen");
                        Console.WriteLine("exit - Stänger ner programmet");
                        break;

                    case "exit":
                        Console.WriteLine("Stänger ned, klicka på valfritangent för att stänga fönstret!");
                        Console.Read();
                        Environment.Exit(0);
                        break;

                }

            }
            catch
            {
                Console.WriteLine("");
            }

            UserInputAsync();
        }

        /// <summary>
        /// Sparkar användaren från servern
        /// </summary>
        /// <param name="us">Användare</param>
        static async void KickUser(string us)
        {
            try
            {
                User usr = new User();
                foreach (User u in s.Users)
                {
                    if (u.Username == us)
                    {
                        byte[] backToClient = new byte[64];
                        backToClient = Encoding.Unicode.GetBytes("kicked");
                        await u.Client.GetStream().WriteAsync(backToClient, 0, backToClient.Length);
                        u.Client.Dispose();
                        usr = u;
                        Console.WriteLine($"Användaren {us} är nu kickad");
                    }
                }
                s.Users.Remove(usr);
            }
            catch
            {
                Console.WriteLine("Användaren finns inte");
            }
            
        }

        /// <summary>
        /// Listar användarna
        /// </summary>
        static void ListUsers()
        {
            try
            {
                //Finns det några användare
                if(s.Users.Count>0){
                    
                    User usr = new User();

                    //Skrivs de ut på skärmen
                    foreach (User u in s.Users)
                    {
                        Console.WriteLine($"Id: {u.Id}| {u.Username} - Namn({u.Name})");
                    }
                }
                else
                {
                    Console.WriteLine("Inga användare är uppkopplade mot servern");
                }
                
            }
            catch
            {
                Console.WriteLine("Inga användare är uppkopplade mot servern");
            }

        }
    }

}
