using Chay;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace ChayServer
{
    public class User
    {
        //Jag deklarerar varibler publik endast för att mongoDB ska kunna komma åt dem när de skapar objekt på databasen
        //Skulle jag inte använt mig av mongoDB hade jag gjort deklarationen privat  =)

        /// <summary>ObjectId som tilldelas utav MongoDB.Bson</summary>
        public ObjectId Id { get; set; }

        /// <summary>Användarnamn</summary>
        public string Username { get; set; }

        /// <summary>Lösenord</summary>
        public string Password { get; private set; }

        /// <summary>Namn</summary>
        public string Name { get; set; }

        /// <summary>Bild i base64 format</summary>
        public string Image { get; set; }

        /// <summary>Serverlista</summary>
        public List<Server> Servers { get; set; }

        /// <summary>Klient</summary>
        [field: NonSerialized]
        internal TcpClient Client;

        /// <summary>
        /// Standardkonstruktor
        /// </summary>
        /// <param name="username">Användarnamn</param>
        /// <param name="name">Namn</param>
        /// <param name="servers">Lista på serverar</param>
        /// <param name="client">Klient</param>
        public User(string username, string name, List<Server> servers, TcpClient client)
        {
            this.Username = username;
            this.Name = name;
            this.Servers = servers;
            this.Client = client;
        }

        /// <summary>
        /// Specialkonstruktor vid inloggning
        /// </summary>
        /// <param name="username">Användarnamn</param>
        /// <param name="password">Lösenord</param>
        public User(string username, string password)
        {
            this.Username = username;
            this.Name = username;
            this.Password = password;
        }

        /// <summary>
        /// Specialkontruktor
        /// </summary>
        /// <param name="client">Klient</param>
        public User(TcpClient client) {
            this.Client = client;
        }

        /// <summary>
        /// Nödkontruktor ifall man definerar en tom
        /// </summary>
        public User()
        {

        }

        /// <summary>
        /// To string()
        /// </summary>
        /// <returns>Lista på serverar</returns>
        public override string ToString()
        {
            return $"{Servers}";
        }
    }

}
