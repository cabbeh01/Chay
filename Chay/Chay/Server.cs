using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ChayPackages;

namespace Chay
{
    [Serializable()]
    public class Server
    {
        public ObjectId Id { get; set; }
        public IPAddress Ip { get; set; }
        public int Port { get; set; }
        public string Name { get; set; }

        public List<User> Users { get; set; }
        public List<Message> Messages { get; set; }

        [field: NonSerialized]
        internal TcpClient _client;

        public Server(IPAddress ip, int port, List<User> users, TcpClient client)
        {
            this.Ip = ip;
            this.Port = port;
            this.Users = users;
            this._client = client;
        }
        
        public Server(string name, IPAddress ip, int port)
        {
            this.Ip = ip;
            this.Port = port;
            this.Name = name;
        }

        public Server(int port)
        {
            //this._ip = ip;
            this.Port = port;
        }

        public Server()
        {

        }
        public override string ToString()
        {
            return $"{Name}| {Ip}: {Port}";
        }
    }
}
