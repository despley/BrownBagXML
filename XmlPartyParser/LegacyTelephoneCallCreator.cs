namespace XmlPartyParser
{
    public class LegacyTelephoneCallCreator : LegacyTelephoneCallCreatorBase
    {
        public LegacyTelephoneCallCreator(ContactableTelephonecallLegacyCreatorBase contactableTelephonecallLegacyCreatorBase) : base(contactableTelephonecallLegacyCreatorBase)
        {
        }

        public override IContactable CreateContactable(string numberToDial)
        {
            ContactableTelephonecallLegacyCreatorBase.NumberToDial = numberToDial;
            return ContactableTelephonecallLegacyCreatorBase;
        }
    }
}