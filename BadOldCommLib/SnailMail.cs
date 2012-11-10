using System;
using System.Threading;

namespace BadOldCommLib
{
    public class SnailMail
    {
        #region Stamp enum

        public enum Stamp
        {
            FirstClass = 1,
            SecondClass = 2,
            ManualDelivery = 3
        };

        #endregion

        private readonly string _address;
        private readonly Letter _letter;
        private readonly Stamp _stamp;

        public SnailMail(string address, Stamp stamp, Letter letter)
        {
            _letter = letter;
            _stamp = stamp;
            _address = address;
            Attending = false;
        }

        public bool Attending { get; set; }
        public bool ReplyRecieved { get; set; }

        public bool Post()
        {
            Thread.Sleep(5000);
            Console.Write(string.Format("Letter posted to: {0} \n Using a {1} stamp \n With the following message {2}",
                                        _address, _stamp, _letter));
            return true;
        }
    }

    public class Letter
    {
        private string _message;

        public Letter(string message)
        {
            _message = message;
        }
    }
}