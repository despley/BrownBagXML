using System.Xml.Linq;
using Moq;
using XmlFormat;
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
            XElement element = XElement.Parse("<TelephoneCall>01292488599</TelephoneCall>");
            var mockLegacyTelehponeCall = new Mock<ILegacyTelephoneCall>();
            IElementToPartyTranslator elementToTelephoneCall = new ElementToTelephoneCall(mockLegacyTelehponeCall.Object);
            elementToTelephoneCall.Translate(element);
            var ele = elementToTelephoneCall as ElementToTelephoneCall;
            Assert.Equal("01292488599", ele.NumberToDial);
        }

        [Fact]
        public void TestParsedTelephoneCallCanCallLegacyStub()
        {
            //I want to create an element that signifies a telehpone call, put the right details in and ensure it calls the underlying legacy class correctly
            XElement element = XElement.Parse("<TelephoneCall>01292488599</TelephoneCall>");
            var mockLegacyTelehponeCall = new Mock<ILegacyTelephoneCall>();
            var mockIContactable = new Mock<IContactable>();
            mockLegacyTelehponeCall.Setup(f => f.CreateContactable("01292488599")).Returns(mockIContactable.Object);
            IElementToPartyTranslator elementToTelephoneCall = new ElementToTelephoneCall(mockLegacyTelehponeCall.Object);
            var connectableDevice= elementToTelephoneCall.Translate(element);
            connectableDevice.Contact("Hello - Party time");
            mockLegacyTelehponeCall.Verify(f => f.CreateContactable("01292488599"), Times.AtMostOnce());
            mockIContactable.Verify(c => c.Contact("Hello - Party time"), Times.AtMostOnce());
        }
    }
}