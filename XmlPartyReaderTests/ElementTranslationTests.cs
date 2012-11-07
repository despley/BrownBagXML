using System.Xml.Linq;
using XmlPartyReader;
using XmlPartyUtils;
using Xunit;

namespace XmlPartyReaderTests
{
  
    public class ElementTranslationTests
    {
        [Fact]
        public void TestTelephoneCallIsParsedProperly()
          {
              var attendee = new Attendee("defaultId");
            XElement element = XElement.Parse("<TelephoneCall>01292488599</TelephoneCall>");
            IElementToPartyTranslator elementToTelephoneCall = new ElementToTelephoneCall();
            elementToTelephoneCall.Translate(element, attendee);
            var ele = elementToTelephoneCall as ElementToTelephoneCall;
            Assert.Equal("01292488599", ele.NumberToDial);

          }
    }
}
