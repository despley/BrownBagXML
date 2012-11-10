using System;
using BadOldCommLib;

namespace TryTheOldStuffOut
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello and Welcome to party broadcaster");

            string partyMessage = string.Empty;
            ConsoleKeyInfo consoleKey;
            do
            {
                Console.WriteLine(
                    "\n Please press \n 1. To enter message to broadcast \n 2. Make a telephone call \n 3. Send smoke signals \n 4. Send an old fashioned snail mail \n");
                consoleKey = Console.ReadKey();
                Console.WriteLine("");
                switch (consoleKey.KeyChar.ToString())
                {
                    case "1":
                        Console.WriteLine("Please write your party message and press return");
                        partyMessage = Console.ReadLine();
                        break;
                    case "2":
                        if (partyMessage == string.Empty)
                        {
                            Console.WriteLine("You can't call someone with an empty message");
                            break;
                        }
                        Console.WriteLine("Please enter the phone number");
                        var t = new Telephone(Console.ReadLine(), partyMessage);
                        try
                        {
                            t.MakeCall();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Failed to make call: {0}", ex.Message);
                        }

                        break;
                    case "3":
                        if (partyMessage == string.Empty)
                        {
                            Console.WriteLine(
                                "You can't send smoke signals to someone with an empty message, that would just be air");
                            break;
                        }
                        var s = new SmokeSignals {WhatToSay = partyMessage};
                        s.MakeSomeSmoke();
                        break;
                    case "4":
                        if (partyMessage == string.Empty)
                        {
                            Console.WriteLine("Sending a letter with no content is not going to work");
                            break;
                        }
                        Console.WriteLine("Please enter the address");
                        string address = Console.ReadLine();
                        Console.WriteLine("What type of stamp would you like to use: 1) First class 2) Second class?");
                        string stampType = Console.ReadKey().KeyChar.ToString();
                        if (stampType == "1")
                        {
                            new SnailMail(address, SnailMail.Stamp.FirstClass, new Letter(partyMessage)).Post();
                            break;
                        }
                        if (stampType == "2")
                        {
                            new SnailMail(address, SnailMail.Stamp.SecondClass, new Letter(partyMessage)).Post();
                            break;
                        }
                        Console.WriteLine("Cannot send letter as an invalid stamp was used");
                        break;


                    default:
                        Console.WriteLine("Invalid option selected");
                        break;
                }
            } while (consoleKey.Key != ConsoleKey.Escape);
        }
    }
}