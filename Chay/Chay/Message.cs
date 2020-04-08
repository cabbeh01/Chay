using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chay
{
    [Serializable]
    public class Message
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

        public override string ToString()
        {
            return $"{this._auther.Name}: {this._text}";
        }
    }
}
