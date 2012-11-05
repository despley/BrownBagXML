using XmlFormat;
using Xunit;
namespace XmlFormatTests
{
    
    class ThrowAwayTests
    {
        [Fact]
        public void AssesrtHowXmlWorks()
        {
           XmlPartyDataLoader xmlPartyDataLoader = new XmlPartyDataLoader();
           xmlPartyDataLoader.PlayWithXml();
           Assert.Equal(true, true);
        }
    }
}
