using System.Xml.Linq;
using XmlFormat;

namespace XmlPartyReader
{
    public interface IElementToPartyTranslator
    {
        IContactable Translate(XElement element);
    }
}