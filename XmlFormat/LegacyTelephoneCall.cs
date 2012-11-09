namespace XmlFormat
{
    public class LegacyTelephoneCall : ILegacyTelephoneCall
    {
        public IContactable CreateContactable(string numberToDial)
        {
            return new XmlTelephoneCall(numberToDial);
        }
    }
}
