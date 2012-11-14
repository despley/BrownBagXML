using System.Xml.Linq;

namespace XmlPartyParser
{
    public class ElementToTelephoneCall : IElementToPartyTranslator
    {

        public ILegacyTelephoneCallCreator LegacyTelephoneCall { get; set; }
        public string NumberToDial { get; set; }
        public ElementToTelephoneCall(ILegacyTelephoneCallCreator legacyTelephoneCall)
        {
            LegacyTelephoneCall = legacyTelephoneCall;
        }
        public IContactable Translate(XElement element)
        {
            NumberToDial = element.Value;
            return LegacyTelephoneCall.CreateContactable(NumberToDial);
        }
    }
}