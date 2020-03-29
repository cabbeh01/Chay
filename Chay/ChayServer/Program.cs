using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChayServer
{
    class Program
    {
        static TcpListener listener;

        static List<TcpClient> tcpClients = new List<TcpClient>();
        static TcpClient client;
        static bool userExist = false;

        static void Main(string[] args)
        {
            StartServer();
            UserInput();
        }

        static void StartServer()
        {
            try
            {
                Console.Write("Vänligen välj en port:");
                int port = int.Parse(Console.ReadLine());
                listener = new TcpListener(IPAddress.Any, port);
                listener.Start();
                Console.WriteLine($"Server started at 127.0.0.1:{port}");
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

        static async void StartHandshake()
        {
            try
            {
                client = await listener.AcceptTcpClientAsync();
                StartReading(client);
                Console.WriteLine(client);
                tcpClients.Add(client);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        static async void StartReading(TcpClient k)
        {
            if (k.Connected)
            {
                byte[] buffert = new byte[1024];

                int n = 0;
                try
                {
                    n = await k.GetStream().ReadAsync(buffert, 0, buffert.Length);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);


                }

                //Sending data on server screen
                SendMessage($"User 1> {Encoding.Unicode.GetString(buffert, 0, n)}");

                Broadcast(buffert);
                StartReading(k);
            }
            else
            {
                k.Dispose();
                tcpClients.Remove(client);
                UserInput();
            }


        }

        static void SendMessage(string text)
        {
            Console.WriteLine(text);

        }

        static void Broadcast(byte[] data)
        {
            try
            {
                foreach (TcpClient c in tcpClients)
                {
                    c.GetStream().Write(data, 0, data.Length);
                }
            }
            catch
            {
                Console.WriteLine("Går inte att broadcasta");
            }
        }

        static void UserInput()
        {
            try
            {
                Console.Write(">");
                string data = Console.ReadLine();
                if (string.IsNullOrEmpty(data))
                {
                    UserInput();
                }
                data.Remove(0, 1);
                string[] dataSplice = data.Split();
                switch (dataSplice[0].ToLower())
                {
                    case "kick":
                        if (!String.IsNullOrEmpty(dataSplice[1]) && userExist)
                        {
                            Console.WriteLine($"Nu kickar vi användaren {dataSplice[1]}");
                        }
                        else if (!String.IsNullOrEmpty(dataSplice[1]))
                        {
                            Console.WriteLine("Användaren finns inte");
                        }
                        else
                        {
                            Console.WriteLine("Du måste mata in en användare som du vill kicka");
                        }
                        break;

                    case "ls":

                        Console.WriteLine("Listar alla användare som är uppkopplade till servern");
                        break;

                    case "stop":
                        if(tcpClients.Count > 0)
                        {
                            foreach (TcpClient c in tcpClients)
                            {
                                c.Dispose();
                            }
                            listener.Stop();
                            Console.WriteLine("Servern stoppades");
                        }
                        else
                        {
                            Console.WriteLine("Servern stoppades");
                        }
                        
                        break;

                    case "start":
                        if (!listener.Pending())
                        {
                            listener.Start();
                            Console.WriteLine("Servern startades");
                        }
                        Console.WriteLine("Servern är redan igång");

                        break;

                    case "clear":

                        Console.Clear();
                        break;


                    case "help":
                        Console.Clear();
                        Console.WriteLine("Dessa kommandona finns tillgängliga");
                        Console.WriteLine("___________________________________________________");
                        Console.WriteLine("help - Visar de kommandon som finns tillgänliga");
                        Console.WriteLine("kick XX- Stänger ner en uppkoppling mellan servern och en användare");
                        Console.WriteLine("ls - Visar de användare som är uppkopplade mot servern");
                        Console.WriteLine("stop - Stoppar servern");
                        Console.WriteLine("start - Startar servern");
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

            }

            UserInput();
        }
    }

}
