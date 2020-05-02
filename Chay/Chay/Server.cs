using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using ChayPackages;

namespace Chay
{
    public class Server
    {
        //Jag deklarerar varibler publik endast för att mongoDB ska kunna komma åt dem när de skapar objekt på databasen
        //Skulle jag inte använt mig av mongoDB hade jag gjort deklarationen privat  =)

        /// <summary>ObjectId som tilldelas utav MongoDB.Bson</summary>
        public ObjectId Id { get; set; }

        /// <summary>Ip-address</summary>
        public IPAddress Ip { get; set; }

        /// <summary>Portnummer</summary>
        public int Port { get; set; }

        /// <summary>Namn</summary>
        public string Name { get; set; }

        /// <summary>Lista på anslutna användare</summary>
        public List<User> Users { get; set; }

        /// <summary>Lista på meddelande</summary>
        public List<Message> Messages { get; set; }

        /// <summary>Klient</summary>
        [field: NonSerialized]
        internal TcpClient _client;

        /// <summary>
        /// Standardkonstruktor
        /// </summary>
        /// <param name="ip">Ip-address</param>
        /// <param name="port">Portnummer</param>
        /// <param name="users">Användarlista</param>
        /// <param name="client">Klient</param>
        public Server(IPAddress ip, int port, List<User> users, TcpClient client)
        {
            this.Ip = ip;
            this.Port = port;
            this.Users = users;
            this._client = client;
        }


        /// <summary>
        /// Specialkonstruktor
        /// </summary>
        /// <param name="name">Namn</param>
        /// <param name="ip">Ip-address</param>
        /// <param name="port">Portnummer</param>
        public Server(string name, IPAddress ip, int port)
        {
            this.Ip = ip;
            this.Port = port;
            this.Name = name;
        }

        /// <summary>
        /// Specialkontruktor
        /// </summary>
        /// <param name="port">Portnummer</param>
        public Server(int port)
        {
            //this._ip = ip;
            this.Port = port;
        }

        /// <summary>
        /// Nödkontruktor ifall Serverobjekt behöver deklareras till null
        /// </summary>
        public Server()
        {

        }

        /// <summary>
        /// To string()
        /// </summary>
        /// <returns>Namn| Ip-address: portnummer</returns>
        public override string ToString()
        {
            return $"{Name} | {Ip}: {Port}";
        }
    }
}
