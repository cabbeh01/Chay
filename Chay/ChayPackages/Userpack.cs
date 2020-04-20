using MongoDB.Bson;
using System;

namespace ChayPackages
{
    [Serializable]
    public class Userpack
    {
        /// <summary>ObjectId som tilldelas utav MongoDB.Bson</summary>
        private ObjectId _id;

        /// <summary>Namnet på användaren</summary>
        private string _name;

        /// <summary>Bilden på användaren i base64 format</summary>
        private string _image;
        
        /// <summary>Användarnmanet</summary>
        private string _username;

        /// <summary>
        /// Standardkonstruktor som deklarerar alla variabler till ett användbart objekt
        /// </summary>
        /// <param name="id">ObjectId som tillhör databasen på användaren</param>
        /// <param name="name">Namnet på användaren</param>
        /// <param name="image">Bilden på användaren i base64 format</param>
        /// <param name="username">Användarnamnet</param>
        public Userpack(ObjectId id, string name, string image, string username)
        {
            this._id = id;
            this._image = image;
            this._name = name;
            this._username = username;
        }

        /// <summary>
        /// GET Returnerar ObjectId:et
        /// </summary>
        public ObjectId Id
        {
            get
            {
                return this._id;
            }
        }

        /// <summary>
        /// GET Returnerar namnet
        /// </summary>
        public string Name
        {
            get
            {
                return this._name;
            }
        }

        /// <summary>
        /// GET Returnerar användarnamnet
        /// </summary>
        public string Username
        {
            get
            {
                return this._username;
            }
        }
        
        /// <summary>
        /// GET returnerar bilden
        /// </summary>
        public string Image
        {
            get
            {
                return this._image;
            }
        }
    }
}
