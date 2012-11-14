using System;
using BadOldCommLib;

namespace XmlPartyParser
{
    class LegacySnailMailCreator : ILegacySnailMailCreator
    {
        public IContactable CreateContactable(string address, SnailMail.Stamp stamp)
        {
            throw new NotImplementedException();
        }
    }
}
