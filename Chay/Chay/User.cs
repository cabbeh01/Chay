using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chay
{
    public class User
    {

        public ObjectId Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }


        public override string ToString()
        {
            return $"{Username}, {Password}";
        }
    }
}
