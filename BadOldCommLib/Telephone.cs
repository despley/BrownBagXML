using System;
using System.Threading;

namespace BadOldCommLib
{
    public class Telephone
    {
        public Telephone(string number, string message)
        {
            Message = message;
            Number = number;
        }


        public string Number { get; set; }

        public string Message { get; set; }

        public bool MakeCall()
        {
            Console.WriteLine(String.Format("Making call to: {0} ", Number ));
            Console.WriteLine("dialling....");
            Thread.Sleep(1000);
            var r = new Random();
            while (r.Next(0, 100) > 10)
            {
                Console.WriteLine(".... still dialling");
                Thread.Sleep(1000);
            }
            if (r.Next(0, 100) > 50)
            {
                Console.WriteLine("Hello? ");
                Console.WriteLine(Message);
                Console.WriteLine("Yes I would love to");
                return true;
            }
            Console.WriteLine("Hello? ");
            Console.WriteLine(Message);
            Console.WriteLine("No, I am not a party person and want to stay at home");
            return false;
        }
    }
}
