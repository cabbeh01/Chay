using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChayPackages
{
    [Serializable]
    public class Userpack
    {
        private ObjectId _id;
        private string _name;
        private string _image;
        private string _username;

        public Userpack(ObjectId id, string name, string image, string username)
        {
            this._id = id;
            this._image = image;
            this._name = name;
            this._username = username;
        }

        public ObjectId Id
        {
            get
            {
                return this._id;
            }
        }

        public string Name
        {
            get
            {
                return this._name;
            }
        }
        public string Username
        {
            get
            {
                return this._username;
            }
        }
        public string Image
        {
            get
            {
                return this._image;
            }
        }
    }
}
