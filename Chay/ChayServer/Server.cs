using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Chay
{
    [Serializable]
    public class Server
    {
        public ObjectId Id { get; set; }
        public IPAddress _ip { get; set; }
        public int _port { get; set; }
        public string _name { get; set; }

        public List<User> _users { get; set; }
        public List<Message> _messages { get; set; }

        private TcpClient _client;

        
        public Server(IPAddress ip, int port, List<User> users, TcpClient client)
        {
            this._ip = ip;
            this._port = port;
            this._users = users;
            this._client = client;
        }
        
        public Server(string name, IPAddress ip, int port)
        {
            this._ip = ip;
            this._port = port;
            this._name = name;
        }

        public Server(int port)
        {
            //this._ip = ip;
            this._port = port;
        }

        public Server()
        {

        }

        public override string ToString()
        {
            return $"{_name}| {_ip}: {_port}";
        }
    }
}
