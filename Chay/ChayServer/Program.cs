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
        //static int port = 3333;
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
                        Console.WriteLine("Dessa kommandona finns tillgängliga");
                        Console.Read();
                        Environment.Exit(0);
                        break;

                    case "exit":
                        Console.WriteLine("Shutting down, click to escape this window");
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
