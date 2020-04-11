using System;
using System.Runtime.Serialization;

namespace ChayPackages
{
    [Serializable()]
    public class Message
    {
        private Userpack _auther;
        private string _text;
        private DateTime _deliveryTime;
        private bool _sysMess;

        public Message(Userpack auther, string message, DateTime deliveryT, bool sysMess=false)
        {
            this._auther = auther;
            this._text = message;
            this._deliveryTime = deliveryT;
            this._sysMess = sysMess;
        }

        public Userpack Auther
        {
            get
            {
                return this._auther;

            }
            set
            {
                this._auther = value;
            }
        }
        public bool SysMess
        {
            get
            {
                return this._sysMess;
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
                this._text = value;
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
                this._deliveryTime = value;
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
            _auther = (Userpack)info.GetValue("_auther", typeof(Userpack));
            _text = (string)info.GetValue("_text", typeof(string));
            _deliveryTime = (DateTime)info.GetValue("_delivertime", typeof(DateTime));
        }

        public override string ToString()
        {
            return $": {this._text}";
        }
    }
}
