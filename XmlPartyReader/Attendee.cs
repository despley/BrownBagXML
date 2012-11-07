using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlPartyUtils
{
    public class Attendee
    {
        public string Id { get; set; }
        public Attendee (string id)
        {
            Id = id;
        }
    }
}
