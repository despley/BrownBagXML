using System.Collections;
using System.Collections.Generic;

namespace XmlPartyUtils
{
    public class XmlParty
    {
        public IList<Party> Party { get; set; }

        public XmlParty()
        {
            Party = new List<Party>();
        }
    }
}
