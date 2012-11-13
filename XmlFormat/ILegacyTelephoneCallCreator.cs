namespace XmlFormat
{
    public interface ILegacyTelephoneCallCreator
    {
        IContactable CreateContactable(string numberToDial);
    }
}