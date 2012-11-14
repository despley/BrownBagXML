namespace XmlPartyParser
{
    public class LegacyTelephoneCallCreator : ILegacyTelephoneCallCreator
    {
        #region ILegacyTelephoneCall Members

        public IContactable CreateContactable(string numberToDial)
        {
            return new LegacyInteropTelephone(numberToDial);
        }

        #endregion
    }
}