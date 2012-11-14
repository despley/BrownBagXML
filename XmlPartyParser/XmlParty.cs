using System.Collections.Generic;

namespace XmlPartyParser
{
    public class XmlParty
    {
        public XmlParty()
        {
            Party = new List<Party>();
        }

        public IList<Party> Party { get; set; }
    }
}