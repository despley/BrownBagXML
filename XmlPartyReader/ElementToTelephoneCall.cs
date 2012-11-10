using System.Xml.Linq;
using XmlFormat;

namespace XmlPartyReader
{
    public class ElementToTelephoneCall : IElementToPartyTranslator
    {
        public ElementToTelephoneCall(ILegacyTelephoneCallCreator legacyTelephoneCall)
        {
            LegacyTelephoneCall = legacyTelephoneCall;
        }

        public ILegacyTelephoneCallCreator LegacyTelephoneCall { get; set; }

        public string NumberToDial { get; set; }

        #region IElementToPartyTranslator Members

        public IContactable Translate(XElement element)
        {
            NumberToDial = element.Value;
            return LegacyTelephoneCall.CreateContactable(NumberToDial);
        }

        #endregion
    }
}