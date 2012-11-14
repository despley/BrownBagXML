using System.Collections.Generic;
using XmlPartyParser;
using Xunit;

namespace XmlPartyParserTests
{
    public class CreateXmlPartyFromReader
    {
        private const string WorkingXmlPartyFile = "XmlPartyInvites.xml";
        //Load the Xml and ensure that the party id is set correctly
        [Fact]
        public void EnsurePartyReaderCanLoadValidXmlViaPath()
        {
            var party = new XmlParty();
            var pReader = new PartyReader(WorkingXmlPartyFile, new List<IPartyFactory>(), party);
            Assert.Equal("75aaae10-b42f-49db-9cfe-22322e3943a5", party.Party[0].Id);
        }

        [Fact]
        public void EnsureTwoPartyIdsCanBeRetrievedFromAValidXmlFile()
        {
            var party = new XmlParty();
            var pReader = new PartyReader(WorkingXmlPartyFile, new List<IPartyFactory>(), party);
            Assert.Equal("731db09a-39be-49d8-a75a-bddab653e20d", party.Party[1].Id);
        }

        [Fact]
        public void MessageShouldBeAttachedAtThePartyLevel()
        {
            var party = new XmlParty();
            var pReader = new PartyReader(WorkingXmlPartyFile, new List<IPartyFactory>(), party);
            Assert.Equal("Hello, please come to my party - it will be great", party.Party[0].Message.Trim());
        }

        [Fact]
        public void CaptureTheAttendeeId()
        {
            var party = new XmlParty();
            var pReader = new PartyReader(WorkingXmlPartyFile, new List<IPartyFactory>(), party);
            Assert.Equal("661d4e8f-79d2-4127-a791-7a1c1d27a1d2", party.Party[0].Attendee[0].Id);
            Assert.Equal("032180d5-1f3b-4e42-bd12-60609f2e61c2", party.Party[0].Attendee[6].Id);
            Assert.Equal("661d4e8f-79d2-4127-a791-7a1c1d27a1d3", party.Party[1].Attendee[0].Id);
            Assert.Equal("032180d5-1f3b-4e42-bd12-60609f2e61c3", party.Party[1].Attendee[6].Id);
        }

    }
}