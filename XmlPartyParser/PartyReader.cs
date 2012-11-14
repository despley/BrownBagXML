using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;

namespace XmlPartyParser
{
    // This class is deliberately 
    public class PartyReader
    {
        public PartyReader(string pathToXmlFile, List<IPartyFactory> partyFactory, XmlParty xmlParty)
        {
            using (XmlReader reader = XmlReader.Create(pathToXmlFile))
            {
                bool finished = false;
                //get into the XML
                reader.MoveToContent();
                do
                {
                    while (reader.Name != "Party" && reader.Read())
                    {
                    }

                    if (reader.Name == "Party")
                    {
                        var party = new Party(reader.GetAttribute("id"));
                        RetrievePartyMessage(reader, party);
                        xmlParty.Party.Add(party);
                        ProcessOnlyPartyElement(party, reader, partyFactory);
                    }
                    else
                        finished = true;
                } while (finished == false);
            }
        }

        public void RetrievePartyMessage(XmlReader reader, Party party)
        {
            while (reader.Name != "Message" && reader.Read())
            {
            }
            party.Message = reader.ReadElementContentAsString();
        }

        public void BuildXmlPartyElement(IElementToPartyTranslator elementToPartyTranslator, Attendee attendee,
                                         XElement xElement)
        {
            elementToPartyTranslator.Translate(xElement);
        }

        //We know the XML is structured to open and close with a party element, therefore it is logical to bounce in and out on these nodes
        public void ProcessOnlyPartyElement(Party party, XmlReader reader, List<IPartyFactory> partyFactory)
        {
            Attendee attendee;
            do
            {
                reader.Read();
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.Name == "Attendee")
                    {
                        attendee = new Attendee(reader.GetAttribute("id"));
                        party.Attendee.Add(attendee);
                    }
                    IPartyFactory translator = partyFactory.Find(p => p.ElementName == reader.Name);
                    if (translator != null)
                        BuildXmlPartyElement(translator.ElementToPartyTranslator,
                                             party.Attendee[party.Attendee.Count - 1],
                                             XNode.ReadFrom(reader) as XElement);
                }
            } while (reader.Name != "Party");
            //move past the end of the element
            reader.Read();
        }
    }
}