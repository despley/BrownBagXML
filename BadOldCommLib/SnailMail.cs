using System;
using System.Threading;

namespace BadOldCommLib
{
    public class SnailMail
    {
        private string _address;
        private Stamp _stamp;
        private Letter _letter;

        public bool Attending { get; set; }
        public bool ReplyRecieved
        {
            get;
            set;
        }

        public enum Stamp
        {
            FirstClass = 1,
            SecondClass = 2,
            ManualDelivery = 3
        };
        
        public SnailMail (string address, Stamp stamp, Letter letter)
        {
            _letter = letter;
            _stamp = stamp;
            _address = address;
            Attending = false;
        }

        public bool Post()
        {
            Thread.Sleep(5000);
            Console.Write(string.Format("Letter posted to: {0} \n Using a {1} stamp \n With the following message {2}", _address, _stamp, _letter));
            return true;
        }


    }

    public class Letter
    {
        private string _message;
        public Letter(string message)
        {
            this._message = message;
        }
    }
}
