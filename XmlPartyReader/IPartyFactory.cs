namespace XmlPartyReader
{
    public interface IPartyFactory
    {
        string ElementName { get; set; }
        IElementToPartyTranslator ElementToPartyTranslator { get; set; }
    }
}