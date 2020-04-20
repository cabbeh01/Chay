using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDBLogin
{
    public class MongoCRUD
    {
        private IMongoDatabase _db;

        public MongoCRUD(string database)
        {
            try
            {
                var client = new MongoClient("mongodb+srv://dbAdmin:Hej123@cluster-v0iz1.mongodb.net/test?retryWrites=true&w=majority");
                _db = client.GetDatabase(database);
            }
            catch
            {
                Console.WriteLine("Kan inte ansluta till databasen");
            }
        }
        public ObjectId GenID()
        {
            return ObjectId.GenerateNewId();
        }


        public async void InsertOne<T>(string table, T data)
        {
            try
            {
                var collection = _db.GetCollection<T>(table);
                await collection.InsertOneAsync(data);
            }
            catch
            {
                Console.WriteLine("Går inte att lagra data");
            }
            
        }

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

        public T FindById<T>(string table,ObjectId id)
        {

            var collection = _db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("Id", id);

            return collection.Find(filter).First();

        }

        public T FindByParameter<T>(string table,string findstring, string tofind)
        {
            var collection = _db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq(findstring, tofind);

            return collection.Find(filter).First();
        }

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
                Console.WriteLine("Går inte att ta bort");
            }
        }

        public void UpdateOne<T>(string table, ObjectId id, T item)
        {
            try
            {
                var collection = _db.GetCollection<T>(table);
                var result = collection.ReplaceOne(new BsonDocument("_id", id), item);
            }
            catch
            {
                Console.WriteLine("Går inte att updatera");
            }
        }


        //Hashar med en md5
        static public string Encrypt(string value)
        {
            try
            {
                using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
                {
                    UTF8Encoding utf8 = new UTF8Encoding();
                    byte[] data = md5.ComputeHash(utf8.GetBytes(value));
                    return Convert.ToBase64String(data);
                }
            }
            catch
            {
                Console.WriteLine("Går inte att Encrypta");
                return "";
            }
            
        }

    }
}
