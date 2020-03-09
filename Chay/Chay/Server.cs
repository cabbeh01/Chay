using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Chay
{
    public class Server
    {
        public ObjectId Id { get; set; }
        public string _ip { get; set; }
        public short _port { get; set; }
        public string _name { get; set; }

        public List<User> _servers { get; set; }

        private TcpClient _client;


        public Server(string ip, short port, List<User> users, TcpClient client)
        {
            this._ip = ip;
            this._port = port;
            this._servers = users;
            this._client = client;
        }
        public override string ToString()
        {
            return $"{_ip}: {_port}";
        }
    }
}
