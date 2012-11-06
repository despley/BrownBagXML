using Xunit;

namespace XmlPartyReaderTests
{

    public class CreateXmlPartyFromReader
    {
        private const string WorkingXmlPartyFile = "XmlPartyInvites.xml";
        //Load the Xml and ensure that the relevant classes are populated
        [Fact]
        public void EnsurePartyReaderCanLoadValidXml()
        {
            var pReader = new XmlPartyReader(WorkingXmlPartyFile);
            Assert.Equal(10, pReader.Invites[0].Attendee.Count);
        }
    }
}
