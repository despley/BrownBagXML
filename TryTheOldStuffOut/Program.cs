using System;
using BadOldCommLib;

namespace TryTheOldStuffOut
{
    class Program
    {
        static void Main(string[] args)
        {
            const string partyMessage = "Hi would you like to come to my party?";
            Telephone t = new Telephone("01782313414", partyMessage);
            t.MakeCall();
            SmokeSignals s = new SmokeSignals(){WhatToSay = partyMessage};
            s.MakeSomeSmoke();
      
        }
    }
}
