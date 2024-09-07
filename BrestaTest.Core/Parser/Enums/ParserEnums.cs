namespace BrestaTest.Core.Parser.Enums
{
    internal struct Token
    {
        public TokenType TokenType;
        public string Name;
        public string Content;
    }
    internal enum TokenType
    {
        Description,
        Property
    }
}
