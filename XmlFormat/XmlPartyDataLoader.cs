using System;
using System.Runtime.Serialization;
namespace XmlFormat
{
    public class XmlPartyDataLoader
    {
       public void PlayWithXml()
       {
           var partyXml = XmlPartyBase<XmlParty>.LoadFromFile("XmlPartyInvites.xml");
           foreach (XmlPartyParty p in partyXml.Party)
           {
               foreach (attendeeType attendeeType in p.Invite)
               {
                   Console.WriteLine(attendeeType.Item);
               }
           }
       }
    }
}
