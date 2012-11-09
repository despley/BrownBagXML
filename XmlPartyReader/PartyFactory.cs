namespace XmlPartyReader
{
    public class PartyFactory : IPartyFactory
    {
        public string ElementName { get; set; }
        public IElementToPartyTranslator ElementToPartyTranslator{get;set;}
        public PartyFactory(string elementName, IElementToPartyTranslator elementToPartyTranslator)
        {
            ElementName = elementName;
            ElementToPartyTranslator = elementToPartyTranslator;
        }
        public PartyFactory()
        {
            
        }
    }
}
