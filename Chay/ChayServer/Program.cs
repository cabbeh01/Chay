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
        static MongoCRUD _db = new MongoCRUD("dbChay");
        static TcpListener listener;
        static TcpClient client;
        static Server s = new Server();


        static void Main(string[] args)
        {
            Console.WriteLine("Servern kopplar upp sig");
            CheckDatabase();
            StartServer();
            UserInputAsync();
            client.NoDelay = true;
        }

        static void StartServer()
        {
            try
            {
                Console.Write("Vänligen välj en port: ");
                int port = int.Parse(Console.ReadLine());
                listener = new TcpListener(IPAddress.Any, port);
                listener.Start();
                s.Users = new List<User>();
                s.Port = port;
                Console.Clear();
                
                Console.WriteLine("För information om vilka kommandon som finns tillgängliga vänlig använd \" help \" ");
                Console.WriteLine("_________________________________________________________________________________ \n");
                Console.WriteLine($"Server started at 127.0.0.1:{port}\n");
                
                
            }
            catch
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Vänligen mata in en korrekt port");
                Console.ForegroundColor = ConsoleColor.Gray;
                StartServer();
            }

            StartHandshake();
        }

        
        static void CheckDatabase()
        {
            try
            {
                if (File.Exists("env"))
                {
                    List<Server> ls = _db.GetAll<Server>("Servers");
                    MongoDB.Bson.ObjectId objID = GetSetting();
                    foreach (Server serv in ls)
                    {
                        if (serv.Id == GetSetting())
                        {
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
                    SetSetting();
                }
            }
            catch(Exception err)
            {
                Console.WriteLine(err);
            }

        }
        static void SetSetting()
        {
            try
            {
                
                FileStream stream = new FileStream("env", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter writer = new StreamWriter(stream);

                s.Id = _db.GenID();
                //Default settings
                writer.Write(s.Id);
                writer.Dispose();
                try
                {
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
        static ObjectId GetSetting()
        {
            try
            {
                FileStream stream = new FileStream("env", FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(stream);

                //Default settings
                ObjectId a = ObjectId.Parse(reader.ReadLine());
                reader.Dispose();
                return a;
            }
            catch
            {
                return ObjectId.Empty;
            }

        }

        static async void StartHandshake()
        {
            try
            {
                client = await listener.AcceptTcpClientAsync();

                User a = new User(client);
                s.Users.Add(a);
                
                StartReading(a);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            StartHandshake();
        }
        static void SendId(ObjectId id, TcpClient client)
        {
            try
            {
                byte[] byteId = new byte[254];
                //Console.WriteLine(id);
                byteId = Encoding.Unicode.GetBytes(id.ToString());
                client.GetStream().Write(byteId, 0, byteId.Length);
            }
            catch
            {
                Console.WriteLine("Gick inte att skicka id");
            }
        }
        static async void StartReading(User u)
        {
            try
            {
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
                    //UserInput();
                }
            }
            catch(Exception ex)
            {
                u.Client.Dispose();
                s.Users.Remove(u);

                Console.WriteLine(ex.ToString());
                //UserInput();
            }


          
        }


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

        static async void SendtoUser(User usr,byte[] data)
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
                    
                    case "restart":
                        if(s.Users.Count > 0)
                        {
                            foreach (User c in s.Users)
                            {
                                c.Client.Dispose();
                            }

                            s.Users.Clear();
                        }
                        
                        Console.Clear();
                        
                        listener.Stop();
                        listener.Start();
                        Console.WriteLine("Servern stoppades");
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
                        Console.WriteLine("restart - Startar om servern");
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

        static void ListUsers()
        {
            try
            {
                if(s.Users.Count>0){
                    User usr = new User();
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
