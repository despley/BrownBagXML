using System;
using System.Threading;

namespace BadOldCommLib
{
    public class SmokeSignals
    {
        public string WhatToSay { get; set; }
        public bool Response { get; set; }
        public bool SmokeAnswer { get; set; }
        public void MakeSomeSmoke()
        {
            Console.WriteLine("About to send some smoke");
            Console.WriteLine("This may take some time");
            Thread.Sleep(10000);
            var r = new Random();
            foreach (char a in WhatToSay.ToCharArray())
            {
                Console.WriteLine("waft waft.... pfffttt, pfffttt");
                Thread.Sleep(r.Next(1,10000));
                Console.WriteLine(a);
                Thread.Sleep(r.Next(1, 10000));
            }
            Console.WriteLine("Finished smoke, no idea if there is a response?!?");
        }

        
    }
}
