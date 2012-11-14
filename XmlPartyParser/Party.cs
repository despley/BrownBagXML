using System.Collections.Generic;

namespace XmlPartyParser
{
    public class Party
    {
        public string Message;

        public Party(string id)
        {
            Id = id;
            Attendee = new List<Attendee>();
        }

        public IList<Attendee> Attendee { get; set; }
        public string Id { get; set; }
    }
}