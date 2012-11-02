using System;
using System.Runtime.Serialization;
namespace XmlFormat
{
    public class XmlPartyDataLoader
    {
       public void PlayWithXml()
       {
           var partyXml = EntityBase<XmlPartyParty>.LoadFromFile("XmlPartyInvites.xml");
           foreach (attendeeType invite  in partyXml.Invite)
           {
               Console.WriteLine(invite.id);

           }
       }
    }
}
