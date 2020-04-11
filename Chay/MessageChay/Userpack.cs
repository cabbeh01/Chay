using MongoDB.Bson;
using System;

namespace MessageChay
{
    [Serializable]
    public class Userpack
    {
        private ObjectId _id;
        private string _name;
        private string _image;


        public Userpack(ObjectId id, string name, string image)
        {
            this._id = id;
            this._image = image;
            this._name = name;
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
        public string Image
        {
            get
            {
                return this._image;
            }
        }
    }
}
