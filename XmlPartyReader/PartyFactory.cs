using System.Xml.Linq;
using XmlPartyUtils;

namespace XmlPartyReader
{
    public class PartyFactory : IPartyFactory
    {
        public string ElementName { get; set; }
        public IElementToPartyTranslator ElementToPartyTranslator{get;set;}
        public PartyFactory(string elementName, IElementToPartyTranslator elementToPartyTranslator)
        {
            ElementName = elementName;
            ElementToPartyTranslator = elementToPartyTranslator;
        }
        public PartyFactory()
        {
            
        }
    }

    public interface IElementToPartyTranslator
    {
        void Translate(XElement element, Attendee attendee);
    }
}
