﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Chay
{
    public class User
    {
        public ObjectId Id { get; set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Name { get; set; }

        public string Image { get; set; }

        public List<Server> Servers { get; set; }

        internal TcpClient Client;


        public User(string username, string name, List<Server> servers, TcpClient client)
        {
            this.Username = username;
            this.Name = name;
            this.Servers = servers;
            this.Client = client;
        }

        public User(string username, string password)
        {
            this.Username = username;
            this.Name = username;
            this.Password = password;
        }

        

        public override string ToString()
        {
            return $"{Servers}";
        }
    }

}