using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Chay
{
    public class User
    {
        public ObjectId Id { get; set; }
        public string _username { get; set; }
        public string _password { get; set; }
        public string _name { get; set; }

        public List<Server> _servers { get; set; }

        private TcpClient _client;


        public User(string username, string name, List<Server> servers, TcpClient client)
        {
            this._username = username;
            this._name = name;
            this._servers = servers;
            this._client = client;
        }
        
        public User(string username, string password)
        {
            this._username = username;
            this._password = password;
        }



        public override string ToString()
        {
            return $"{_servers}";
        }
    }
}
