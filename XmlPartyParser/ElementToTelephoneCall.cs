using System.Xml.Linq;

namespace XmlPartyParser
{
    public class ElementToTelephoneCall : IElementToPartyTranslator
    {
        public LegacyTelephoneCallCreatorBase LegacyTelephoneCallCreatorBase { get; set; }
        public ElementToTelephoneCall(LegacyTelephoneCallCreatorBase legacyTelephoneCallCreatorBase)
        {
            LegacyTelephoneCallCreatorBase = legacyTelephoneCallCreatorBase;
        }
        public IContactable Translate(XElement element)
        {
            return LegacyTelephoneCallCreatorBase.CreateContactable(element.Value);
        }
    }
}