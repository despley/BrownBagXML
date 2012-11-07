using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlPartyUtils
{
    public class Party
    {
        public IList<Attendee> Attendee { get; set; } 
        public string Id { get; set; }
        public string Message;
        public Party(string id)
        {
            Id = id;
            Attendee = new List<Attendee>();
        }
    }

}
