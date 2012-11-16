namespace XmlPartyParser
{
    public abstract class ContactableTelephonecallLegacyCreatorBase : IContactable
    {
        public virtual string NumberToDial { get; set; }
        public abstract bool Contact(string message);
    }
}
