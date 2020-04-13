﻿using System;
using System.Runtime.Serialization;

namespace MessageChay
{
    [Serializable()]
    public class Message : ISerializable
    {
        private Userpack _auther;
        private string _text;
        private DateTime _deliveryTime;

        public Message(Userpack auther, string message, DateTime deliveryT)
        {
            this._auther = auther;
            this._text = message;
            this._deliveryTime = deliveryT;
        }

        public Userpack Auther
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