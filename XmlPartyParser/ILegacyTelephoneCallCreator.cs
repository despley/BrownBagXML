namespace XmlPartyParser
{
    public interface ILegacyTelephoneCallCreator
    {
        IContactable CreateContactable(string numberToDial);
    }
}