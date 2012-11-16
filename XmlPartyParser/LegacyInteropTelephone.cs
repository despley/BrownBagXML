using System;
using System.Diagnostics;
using BadOldCommLib;

namespace XmlPartyParser
{
    public class LegacyInteropTelephone : ContactableTelephonecallLegacyCreatorBase
    {
        public LegacyInteropTelephone(string numberToDial)
        {
            NumberToDial = numberToDial;
        }

        public LegacyInteropTelephone(){}

        public override sealed string NumberToDial { get; set; }

        #region IContactable Members

        public override bool Contact(string message)
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