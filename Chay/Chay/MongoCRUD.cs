using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Windows.Forms;

namespace MongoDBLogin
{
    public class MongoCRUD
    {
        /// <summary>Interface för MongoClassen</summary>
        private IMongoDatabase _db;

        /// <summary>
        /// Standardkontruktor
        /// </summary>
        /// <param name="database">Databas</param>
        public MongoCRUD(string database)
        {
            try
            {
                //Skapar en uppkoppling med mongoDB genom secret key osv..
                var client = new MongoClient("mongodb+srv://....");
                _db = client.GetDatabase(database);
            }
            catch
            {
                MessageBox.Show("Kan inte ansluta till databasen");
            }
        }

        /// <summary>
        /// Genererar ObjectID
        /// </summary>
        /// <returns>ObjectID</returns>
        public ObjectId GenID()
        {
            return ObjectId.GenerateNewId();
        }

        /// <summary>
        /// Mata in ett objekt i databasen
        /// </summary>
        /// <typeparam name="T">Objekttyp</typeparam>
        /// <param name="table">I vilket table som objektet ska ligga i</param>
        /// <param name="data">Datan som ska in i tablet</param>
        public async void InsertOne<T>(string table, T data)
        {
            try
            {
                var collection = _db.GetCollection<T>(table);
                await collection.InsertOneAsync(data);
            }
            catch
            {
                MessageBox.Show("Går inte att lagra data");
            }
            
        }

        /// <summary>
        /// Hämtar all data i ett table
        /// </summary>
        /// <typeparam name="T">Typen som ska hämtas</typeparam>
        /// <param name="table">Tablet</param>
        /// <returns>Returnerar lista på typen</returns>
        public List<T> GetAll<T>(string table)
        {
            try
            {
                var collection = _db.GetCollection<T>(table);

                return collection.Find(new BsonDocument()).ToList();
            }
            catch
            {
                return new List<T>();
            }
            
        }

        /// <summary>
        /// Hittar ett objekt med hjälp av ObjectID
        /// </summary>
        /// <typeparam name="T">Typen</typeparam>
        /// <param name="table">Table</param>
        /// <param name="id">ObjectID</param>
        /// <returns>Returnerar Typen som hittas</returns>
        public T FindById<T>(string table,ObjectId id)
        {

            var collection = _db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("Id", id);

            return collection.Find(filter).First();

        }

        /// <summary>
        /// Hitta objekt med hjälp av sträng
        /// </summary>
        /// <typeparam name="T">Typen</typeparam>
        /// <param name="table">Table</param>
        /// <param name="findstring">Strängen att leta med</param>
        /// <param name="tofind">Att hitta</param>
        /// <returns>Returnerar det som den hittat</returns>
        public T FindByParameter<T>(string table,string findstring, string tofind)
        {
            var collection = _db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq(findstring, tofind);

            return collection.Find(filter).First();
        }

        /// <summary>
        /// Ta bort ett objekt från table
        /// </summary>
        /// <typeparam name="T">Typen</typeparam>
        /// <param name="table">Table</param>
        /// <param name="id">ObjectID</param>
        public void RemoveOne<T>(string table, ObjectId id)
        {
            try
            {
                var collection = _db.GetCollection<T>(table);
                var filter = Builders<T>.Filter.Eq("Id", id);
                collection.DeleteOne(filter);
            }
            catch
            {
                MessageBox.Show("Går inte att ta bort");
            }
        }

        /// <summary>
        /// Uppdatera ett objekt i tablet
        /// </summary>
        /// <typeparam name="T">Typen</typeparam>
        /// <param name="table">Table</param>
        /// <param name="id">ObjectID</param>
        /// <param name="item">Objectet</param>
        public void UpdateOne<T>(string table, ObjectId id, T item)
        {
            try
            {
                var collection = _db.GetCollection<T>(table);
                var result = collection.ReplaceOne(new BsonDocument("_id", id), item);
            }
            catch
            {
                MessageBox.Show("Går inte att updatera");
            }
        }

        /// <summary>
        /// Hashar ett strängvärde med md5 hash
        /// </summary>
        /// <param name="value">Värdet som ska hashas</param>
        /// <returns>returnerar det hashade värdet</returns>
        static public string Encrypt(string value)
        {
            try
            {
                //Skapar en md5Cryptomodule
                using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
                {
                    UTF8Encoding utf8 = new UTF8Encoding();

                    //Beräknar hash
                    byte[] data = md5.ComputeHash(utf8.GetBytes(value));

                    //Returnerar hashen
                    return Convert.ToBase64String(data);
                }
            }
            catch
            {
                MessageBox.Show("Går inte att Encrypta");
                return "";
            }
            
        }

    }
}
