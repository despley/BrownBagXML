using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BadOldCommLib;

namespace XmlFormat
{
    public class XmlTelephoneCall : IContactable
    {
        public string NumberToDial { get; set; }
        public XmlTelephoneCall(string numberToDial)
        {
            NumberToDial = numberToDial;
        }
        public bool Contact(string message)
        {
            try
            {
                var legacyCommLibTelephone = new Telephone(NumberToDial, message);
                legacyCommLibTelephone.MakeCall();
                return true;
            }
            catch (Exception ex)
            {
                //Log ex
                System.Diagnostics.Trace.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
