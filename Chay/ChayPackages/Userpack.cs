using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChayPackages
{
    [Serializable]
    public class Userpack
    {
        /// <summary> </summary>
        private ObjectId _id;

        /// <summary> </summary>
        private string _name;

        /// <summary> </summary>
        private string _image;

        /// <summary> </summary>
        private string _username;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="image"></param>
        /// <param name="username"></param>
        public Userpack(ObjectId id, string name, string image, string username)
        {
            this._id = id;
            this._image = image;
            this._name = name;
            this._username = username;
        }

        /// <summary>
        /// 
        /// </summary>
        public ObjectId Id
        {
            get
            {
                return this._id;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get
            {
                return this._name;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Username
        {
            get
            {
                return this._username;
            }
        }
        
        /// <summary>
        /// 
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
