using BrestaTest.Core.Parser.Enums;

namespace BrestaTest.Core.Parser
{
    internal static class BrestaCfgTokenizer
    {
        [Flags]
        private enum State : byte
        {
            None = 0,
            TokenName = 1,
            TokenContent = 2,
            ElementDescription = 4,
            SingleLineComment = 8,
            Section = 16
        }
      
        internal static Token[] Tokenize(string cfgContent)
        {
            var currentState = State.None;
            var result = new List<Token>();
            var tokenName = String.Empty;
            var tokenContent = String.Empty;
            Char? prevChar = null;
            foreach (var ch in cfgContent)
            {
                if (prevChar == '\n' && ch == '[')
                {
                    currentState = State.Section;
                }
                else if (ch == ']' && currentState == State.Section)
                {
                    currentState = State.None;
                }
                else if (currentState == State.Section)
                {
                    //no need for sections
                }
                else if (ch == '/' && prevChar is not null && prevChar == '/')
                {
                    currentState = State.SingleLineComment;
                }
                else if (ch == '\n' && currentState == State.SingleLineComment)
                {
                    currentState = State.None;
                }
                else if (currentState == State.SingleLineComment)
                {
                    //no need for comments
                }
                else if (ch == '{' && !currentState.HasFlag(State.TokenContent))
                {
                    currentState = State.ElementDescription;
                }
                else if (ch == '}' && !currentState.HasFlag(State.TokenContent))
                {
                    currentState = State.None;
                }
                else if (currentState.HasFlag(State.ElementDescription))
                {
                    if (ch == ':' && currentState.HasFlag(State.TokenName))
                    {
                        currentState &= ~State.TokenName;
                        currentState |= State.TokenContent;
                    }
                    else if ((ch == ';' || ch == '}') && currentState.HasFlag(State.TokenContent))
                    {
                        result.Add(new Token { TokenType = TokenType.Description, Name = tokenName.Trim(), Content = tokenContent.Trim() });
                        currentState &= ~State.TokenContent;
                        if (ch == '}') currentState = State.None;
                        tokenName = String.Empty;
                        tokenContent = String.Empty;
                    }
                    else if ((Char.IsLetterOrDigit(ch) || ch == '-') && !currentState.HasFlag(State.TokenContent))
                    {
                        tokenName += ch;
                        currentState |= State.TokenName;
                    }
                    else if (currentState.HasFlag(State.TokenContent))
                    {
                        tokenContent += ch;
                    }
                }
                else if (ch == ':' && currentState.HasFlag(State.TokenName))
                {
                    currentState &= ~State.TokenName;
                    currentState |= State.TokenContent;
                }
                else if (ch == '\n' && currentState.HasFlag(State.TokenContent))
                {
                    result.Add(new Token { TokenType = TokenType.Property, Name = tokenName.Trim(), Content = tokenContent.Trim() });
                    currentState &= ~State.TokenContent;
                    tokenName = String.Empty;
                    tokenContent = String.Empty;
                }
                else if ((Char.IsLetterOrDigit(ch) || ch == '-') && !currentState.HasFlag(State.TokenContent))
                {
                    tokenName += ch;
                    currentState |= State.TokenName;
                }
                else if (currentState.HasFlag(State.TokenContent))
                {
                    tokenContent += ch;
                }
                prevChar = ch;
            }
            return result.ToArray();
        }
    }
}
