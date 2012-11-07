using System;
using System.Xml.Linq;
using XmlPartyUtils;

namespace XmlPartyReader
{
    public class ElementToTelephoneCall : IElementToPartyTranslator
    {
        public void Translate(XElement element, Attendee attendee)
        {
            
        }

        public string NumberToDial { get; set; }
    }
}
