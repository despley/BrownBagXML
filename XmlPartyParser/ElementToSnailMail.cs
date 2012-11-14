using System.Xml.Linq;
using BadOldCommLib;

namespace XmlPartyParser
{
    public class ElementToSnailMail : IElementToPartyTranslator
    {
        public ILegacySnailMailCreator LegacySnailMailCreator { get; set; }
        public SnailMail.Stamp PostageClass { get; set; }
        public string Address { get; set; }
        public ElementToSnailMail(ILegacySnailMailCreator legacySnailMailCreator)
        {
            LegacySnailMailCreator = legacySnailMailCreator;
        }

        public IContactable Translate(XElement element)
        {
            Address = element.Value;
            PostageClass = SnailMail.Stamp.FirstClass;
            return LegacySnailMailCreator.CreateContactable(Address, PostageClass);
        }
    }
}
