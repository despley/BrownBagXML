using System;
using System.Xml.Linq;
using XmlFormat;
using XmlPartyUtils;

namespace XmlPartyReader
{
    public class ElementToTelephoneCall : IElementToPartyTranslator
    {
        public ILegacyTelephoneCall LegacyTelephoneCall { get; set; }
        public ElementToTelephoneCall(ILegacyTelephoneCall legacyTelephoneCall)
        {
            LegacyTelephoneCall = legacyTelephoneCall;
        }

        public IContactable Translate(XElement element)
        {
            NumberToDial = element.Value;
            return LegacyTelephoneCall.CreateContactable(NumberToDial);
        }

        public string NumberToDial { get; set; }

    }
}
