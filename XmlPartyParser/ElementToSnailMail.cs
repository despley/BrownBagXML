using System;
using System.Xml.Linq;
using BadOldCommLib;

namespace XmlPartyParser
{
    public class ElementToSnailMail : IElementToPartyTranslator
    {
        public ILegacySnailMailCreator LegacySnailMail { get; set; }
        public SnailMail.Stamp PostageClass { get; set; }
        public string Address { get; set; }
        public ElementToSnailMail(ILegacySnailMailCreator legacySnailMailCreator)
        {
            LegacySnailMail = legacySnailMailCreator;
        }

        public IContactable Translate(XElement element)
        {
            Address = element.Value;
            var attributeStampClass = element.Attribute("class");
            if (attributeStampClass == null)
                throw new Exception("Class attribute of SnailMail element was null");
            var stampClass = attributeStampClass.Value;
            PostageClass = (SnailMail.Stamp)Enum.Parse(typeof(SnailMail.Stamp), stampClass);
            return LegacySnailMail.CreateContactable(Address, PostageClass);
        }
    }
}
