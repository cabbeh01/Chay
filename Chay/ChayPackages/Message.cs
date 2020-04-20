using System;
using System.Runtime.Serialization;

namespace ChayPackages
{
    [Serializable()]
    public class Message
    {
        /// <summary>Författarklassen som varje meddelande har</summary>
        private Userpack _auther;

        /// <summary>Meddelande strängen som avsändaren skickar</summary>
        private string _text;
        
        /// <summary>Tid som meddelandet skickades</summary>
        private DateTime _deliveryTime;
        
        /// <summary>Statusnyckel ifall meddelandet kommer från servern</summary>
        private bool _sysMess;

        /// <summary>
        /// Standard konstruktor som deklarerar ett nytt instans av detta objektet Meddelande
        /// </summary>
        /// <param name="auther">Författarklassen</param>
        /// <param name="message">Meddelandet som vill framföras</param>
        /// <param name="deliveryT">Tiden som meddelandet skickas</param>
        /// <param name="sysMess">Om meddelandet är ett systemmeddelande (Standard) = false</param>
        public Message(Userpack auther, string message, DateTime deliveryT, bool sysMess=false)
        {
            this._auther = auther;
            this._text = message;
            this._deliveryTime = deliveryT;
            this._sysMess = sysMess;
        }
        
        /// <summary>
        /// 
        /// </summary>
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
        
        /// <summary>
        /// 
        /// </summary>
        public bool SysMess
        {
            get
            {
                return this._sysMess;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
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
        
        /// <summary>
        /// 
        /// </summary>
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

        
        /// <summary>
        /// SET serialization
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            /*
             Tillför den datan som ska serializeras. Vid en serialization konverteras en klass till en stream. 
             Detta gör att den blir lätt att att hantera via nätverket eller i filer.
             */
            info.AddValue("_auther", _auther);
            info.AddValue("_text", _text);
            info.AddValue("_delivertime", _deliveryTime);
        }

        /// <summary>
        /// GET serialization
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public Message(SerializationInfo info, StreamingContext context)
        {
            /*
             Extraherar den datan som ska unserializeras. Vid en unserialization konverteras en stream till en klass. 
             Detta gör att den blir lätt att att hantera via nätverket eller i filer.
             */
            _auther = (Userpack)info.GetValue("_auther", typeof(Userpack));
            _text = (string)info.GetValue("_text", typeof(string));
            _deliveryTime = (DateTime)info.GetValue("_delivertime", typeof(DateTime));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Returnerar meddelandete som skickas</returns>
        public override string ToString()
        {
            return $": {this._text}";
        }
    }
}
