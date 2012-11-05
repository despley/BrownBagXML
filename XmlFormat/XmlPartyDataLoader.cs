using System;
using System.Runtime.Serialization;
namespace XmlFormat
{
    public class XmlPartyDataLoader
    {
       public void PlayWithXml()
       {
           var partyXml = EntityBase<XmlParty>.LoadFromFile("XmlPartyInvites.xml");
           foreach (XmlPartyParty p in partyXml.Party)
           {
               Console.WriteLine(p.id);
               foreach (attendeeType attendeeType in p.Invite)
               {
                   Console.WriteLine(attendeeType.id);
                   Console.WriteLine(attendeeType.Item);

               }
           }
       }
    }
}
