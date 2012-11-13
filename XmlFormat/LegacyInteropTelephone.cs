using System;
using System.Diagnostics;
using BadOldCommLib;

namespace XmlFormat
{
    public class LegacyInteropTelephone : IContactable
    {
        public LegacyInteropTelephone(string numberToDial)
        {
            NumberToDial = numberToDial;
        }

        public string NumberToDial { get; set; }

        #region IContactable Members

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
                Trace.WriteLine(ex.Message);
                return false;
            }
        }

        #endregion
    }
}