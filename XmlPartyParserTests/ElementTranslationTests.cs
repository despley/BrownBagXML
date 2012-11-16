using System;
using System.Xml.Linq;
using BadOldCommLib;
using Moq;
using XmlPartyParser;
using Xunit;

namespace XmlPartyParserTests
{
    public class ElementTranslationTests
    {

        [Fact]
        public void TestParsedTelephoneCallCanCallLegacyStub()
        {
            //I want to create an element that signifies a telehpone call, put the right details in and ensure it calls the underlying legacy class correctly
            XElement element = XElement.Parse("<TelephoneCall>01292488599</TelephoneCall>");
            var mockContactableTelephonecallLegacyCreatorBase = new Mock<ContactableTelephonecallLegacyCreatorBase>();
            var legacyTelehponeCall = new LegacyTelephoneCallCreator(mockContactableTelephonecallLegacyCreatorBase.Object);
            IElementToPartyTranslator elementToTelephoneCall = new ElementToTelephoneCall(legacyTelehponeCall);
            elementToTelephoneCall.Translate(element);
            mockContactableTelephonecallLegacyCreatorBase.VerifySet(f => f.NumberToDial = "01292488599");
        }

        [Fact]
        public void TestSnailMailIsParsedProperly()
        {
            XElement element = XElement.Parse("<SnailMail class=\"FirstClass\">19 Baker St, London, W12 4TF</SnailMail>");
            var mockSnailMail = new Mock<ILegacySnailMailCreator>();
            IElementToPartyTranslator elementToSnailMail = new ElementToSnailMail(mockSnailMail.Object);
            elementToSnailMail.Translate(element);
            var ele = elementToSnailMail as ElementToSnailMail;
            Assert.Equal("FirstClass", ele.PostageClass.ToString());
            Assert.Equal("19 Baker St, London, W12 4TF", ele.Address);
        }
        [Fact]
        public void AssertExceptionThrownWhenClassIsMissingFromSnailMailAttribute()
        {
            XElement element = XElement.Parse("<SnailMail>19 Baker St, London, W12 4TF</SnailMail>");
            var mockSnailMail = new Mock<ILegacySnailMailCreator>();
            IElementToPartyTranslator elementToSnailMail = new ElementToSnailMail(mockSnailMail.Object);
            var ex = Assert.Throws<Exception>(() => elementToSnailMail.Translate(element));
            Assert.Equal("Class attribute of SnailMail element was null", ex.Message);
        }

        [Fact]
        public void TestParsedSnailMailCallCanCallLegacyStub()
        {
            //I want to create an element that signifies a SnailMail delivery, put the right details in and ensure it will call the underlying legacy class correctly
            XElement element = XElement.Parse("<SnailMail class=\"FirstClass\">19 Baker St, London, W12 4TF</SnailMail>");
            var mockSnailMail = new Mock<ILegacySnailMailCreator>();
            var mockIContactable = new Mock<IContactable>();
            mockSnailMail.Setup(f => f.CreateContactable("19 Baker St, London, W12 4TF", SnailMail.Stamp.FirstClass)).Returns(mockIContactable.Object);
            IElementToPartyTranslator elementToSnailMail = new ElementToSnailMail(mockSnailMail.Object);
            IContactable connectableDevice = elementToSnailMail.Translate(element);
            connectableDevice.Contact("Hello - Party time");
            mockSnailMail.Verify(f => f.CreateContactable("19 Baker St, London, W12 4TF", SnailMail.Stamp.FirstClass), Times.AtMostOnce());
            mockIContactable.Verify(c => c.Contact("Hello - Party time"), Times.AtMostOnce());
        }

        [Fact]
        public void TestSmokeSignalCanBeCalled()
        {
            XElement element = XElement.Parse("<SmokeSignal />");
            var mockSmokeSignal = new Mock<ILegacySmokeSignalCreator>();
            var mockIcontactable = new Mock<IContactable>();
            mockSmokeSignal.Setup(f => f.CreateContactable()).Returns(mockIcontactable.Object);
            IElementToPartyTranslator elementToSmokeSignal = new ElementToSmokeSignal(mockSmokeSignal.Object);
            elementToSmokeSignal.Translate(element).Contact("Hello - Party time");
            mockSmokeSignal.Verify(f => f.CreateContactable(), Times.AtMostOnce());
            mockIcontactable.Verify(f => f.Contact("Hello - Party time"), Times.AtMostOnce());
            

        }
    }
}