using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XmlPartyParser
{
    public class ElementToSmokeSignal : IElementToPartyTranslator
    {

        public ILegacySmokeSignalCreator LegacySmokeSignalCreator { get; set; }
        public ElementToSmokeSignal(ILegacySmokeSignalCreator legacySmokeSignalCreator)
        {
            LegacySmokeSignalCreator = legacySmokeSignalCreator;
        }

        public IContactable Translate(XElement element)
        {
            return LegacySmokeSignalCreator.CreateContactable();
        }
    }
}
