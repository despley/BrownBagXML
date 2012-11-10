namespace XmlPartyReader
{
    public class PartyFactory : IPartyFactory
    {
        public PartyFactory(string elementName, IElementToPartyTranslator elementToPartyTranslator)
        {
            ElementName = elementName;
            ElementToPartyTranslator = elementToPartyTranslator;
        }

        public PartyFactory()
        {
        }

        #region IPartyFactory Members

        public string ElementName { get; set; }
        public IElementToPartyTranslator ElementToPartyTranslator { get; set; }

        #endregion
    }
}