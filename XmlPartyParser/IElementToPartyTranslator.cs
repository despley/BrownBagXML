using System.Xml.Linq;

namespace XmlPartyParser
{
    public interface IElementToPartyTranslator
    {
        IContactable Translate(XElement element);
    }
}