using System.Xml.Linq;
using XmlFormat;
using XmlPartyUtils;

namespace XmlPartyReader
{
    public interface IElementToPartyTranslator
    {
        IContactable Translate(XElement element);
    }
}