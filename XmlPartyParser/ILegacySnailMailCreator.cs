using BadOldCommLib;

namespace XmlPartyParser
{
    public interface ILegacySnailMailCreator
    {
        IContactable CreateContactable(string address, SnailMail.Stamp stamp);
    }
}