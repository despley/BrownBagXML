namespace XmlFormat
{
    public interface ILegacyTelephoneCall
    {
        IContactable CreateContactable(string numberToDial);
    }
}
