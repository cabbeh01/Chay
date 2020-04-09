using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Chay
{
    [Serializable()]
    public class Message : ISerializable
    {
        private User _auther;
        private string _text;
        private DateTime _deliveryTime;

        public Message(User user, string message, DateTime deliveryT)
        {
            this._auther = user;
            this._text = message;
            this._deliveryTime = deliveryT;
        }

        public User Auther
        {
            get
            {
                return this._auther;
                
            }
            set
            {
                value = this._auther;
            }
        }
        
        public string Text
        {
            get
            {
                return this._text;
            }
            set
            {
                value = this._text;
            }
        }
        
        public DateTime DelivaryTime
        {
            get
            {
                return this._deliveryTime;
            }
            set
            {
                value = this._deliveryTime;
            }
        }

        // GET & SET serialization
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("_auther", _auther);
            info.AddValue("_text", _text);
            info.AddValue("_delivertime", _deliveryTime);
        }

        public Message(SerializationInfo info, StreamingContext context)
        {
            _auther = (User)info.GetValue("_auther", typeof(User));
            _text = (string)info.GetValue("_text", typeof(string));
            _deliveryTime = (DateTime)info.GetValue("_delivertime", typeof(DateTime));
        }

        public override string ToString()
        {
            return $": {this._text}";
        }
    }
}
