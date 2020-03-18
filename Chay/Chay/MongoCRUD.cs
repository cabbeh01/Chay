using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDBLogin
{
    public class MongoCRUD
    {
        private IMongoDatabase _db;

        public MongoCRUD(string database)
        {
            var client = new MongoClient("mongodb+srv://dbAdmin:Hej123@cluster-v0iz1.mongodb.net/test?retryWrites=true&w=majority");
            _db = client.GetDatabase(database);
        }

        public async void InsertOne<T>(string table, T data)
        {
            var collection = _db.GetCollection<T>(table);
            await collection.InsertOneAsync(data);
        }

        public List<T> GetAll<T>(string table)
        {
            var collection = _db.GetCollection<T>(table);
            
            return collection.Find(new BsonDocument()).ToList();
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
            var collection = _db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("Id", id);
            collection.DeleteOne(filter);
        }

        public void UpdateOne<T>(string table, ObjectId id, T item)
        {
            var collection = _db.GetCollection<T>(table);
            var result = collection.ReplaceOne(new BsonDocument("_id", id), item);
        }


        //Hashar med en md5
        static public string Encrypt(string value)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] data = md5.ComputeHash(utf8.GetBytes(value));
                return Convert.ToBase64String(data);
            }
        }

    }
}
