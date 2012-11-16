namespace XmlPartyParser
{
    public abstract class LegacyTelephoneCallCreatorBase
    {
        protected ContactableTelephonecallLegacyCreatorBase ContactableTelephonecallLegacyCreatorBase { get; set; }
        protected LegacyTelephoneCallCreatorBase(
            ContactableTelephonecallLegacyCreatorBase contactableTelephonecallLegacyCreatorBase)
        {
            ContactableTelephonecallLegacyCreatorBase = contactableTelephonecallLegacyCreatorBase;
        }
        public abstract IContactable CreateContactable(string numberToDial);
    }
}
