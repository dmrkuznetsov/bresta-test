using BrestaTest.Core.Models.Abstract;
using BrestaTest.Core.Models.Enums;
using BrestaTest.Core.Models.UiHints;
using BrestaTest.Core.Parser.Enums;
using BrestaTest.Core.Parser.Exceptions;
using System.Drawing;
using System.Globalization;

namespace BrestaTest.Core.Parser
{
    public static class BrestaCfgParser
    {
        public static void ParseCfg(string filePath, string cfgContent, ModelType modelType, out List<BaseEntity> models)
        {
            models = new List<BaseEntity>();
            var currentModelTokens = new Dictionary<string, Token>();
            var tokens = BrestaCfgTokenizer.Tokenize(cfgContent);
            Token? prevToken = null;
            foreach (var token in tokens)
            {
                if (token.TokenType == TokenType.Description && prevToken is not null && prevToken.Value.TokenType == TokenType.Property)
                {
                    models.Add(BrestaModelBuilder.CreateModel(filePath, currentModelTokens, modelType));
                    currentModelTokens.Clear();
                    currentModelTokens.Add(token.Name, token);
                }
                else if (token.TokenType == TokenType.Description || token.TokenType == TokenType.Property)
                {
                    if (token.Name != "text" && token.Name != "relevance" && token.Name != "posChange") // for now TODO
                    {
                        currentModelTokens.Add(token.Name, token);
                    }
                }
                prevToken = token;
            }
            //Last model in file
            if (currentModelTokens.Any()) 
            { 
                models.Add(BrestaModelBuilder.CreateModel(filePath, currentModelTokens, modelType));
            }
        }

        public static ColorWithPosition ParseColorWithPos(string content)
        {
            var backSplitted = content.Split(" ");
            if (backSplitted.Length == 1)
            {
                return new ColorWithPosition
                {
                    Color1 = ColorTranslator.FromHtml(backSplitted[0]),
                    Color2 = Color.Empty,
                    Position = UiPosition.unknown
                };
            }
            else if (backSplitted.Length == 3)
            {
                return new ColorWithPosition
                {
                    Color1 = ColorTranslator.FromHtml(backSplitted[0]),
                    Color2 = ColorTranslator.FromHtml(backSplitted[1]),
                    Position = Enum.TryParse(backSplitted[2], out UiPosition pos) ? pos : throw new InvalidBrestaFormatException()
                };
            }
            else
            {
                throw new InvalidBrestaFormatException();
            }
        }
        public static Point ParsePosition(string content)
        {
            var posSplitted = content.Split(' ');
            if (posSplitted.Length != 2) throw new InvalidBrestaFormatException();
            return new Point()
            {
                X = Int32.TryParse(posSplitted[0], out int x) ? x : throw new InvalidBrestaFormatException(),
                Y = Int32.TryParse(posSplitted[1], out int y) ? y : throw new InvalidBrestaFormatException(),
            };
        }
        public static Size ParseSize(string content)
        {
            var sizeSplitted = content.Split(' ');
            if (sizeSplitted.Length != 2) throw new InvalidBrestaFormatException();
            return new Size()
            {
                Height = Int32.TryParse(sizeSplitted[0], out int h) ? h : throw new InvalidBrestaFormatException(),
                Width = Int32.TryParse(sizeSplitted[1], out int w) ? w : throw new InvalidBrestaFormatException(),
            };
        }
        public static LineInfo ParseLineInfo(string content)
        {
            var infoSplitted = content.Split(' '); 
            if (infoSplitted.Length != 6) throw new InvalidBrestaFormatException();
            var colorSplitted = infoSplitted[4].Split('=');
            if (colorSplitted.Length != 2) throw new InvalidBrestaFormatException();
            var thicknessSplitted = infoSplitted[5].Split('=');
            if (thicknessSplitted.Length != 2) throw new InvalidBrestaFormatException();
            var culture = CultureInfo.CreateSpecificCulture("en-US");
            return new LineInfo()
            {
                Coords = new LineCoord
                {
                    P1 = ParsePosition($"{infoSplitted[0]} {infoSplitted[1]}"),
                    P2 = ParsePosition($"{infoSplitted[2]} {infoSplitted[3]}"),
                },
                Color = ColorTranslator.FromHtml(colorSplitted[1]),
                Thickness = float.TryParse(thicknessSplitted[1], NumberStyles.Number, culture, out float italonRange) ? italonRange : throw new InvalidBrestaFormatException()
            };
        }
        public static Indentation ParseIndentation(string content)
        {
            var intentationSplitted = content.Split(' ');
            if (intentationSplitted.Length != 4) throw new InvalidBrestaFormatException();
            return new Indentation()
            {
                Left = Int32.TryParse(intentationSplitted[0], out int l) ? l: throw new InvalidBrestaFormatException(),
                Top = Int32.TryParse(intentationSplitted[1], out int t) ? t : throw new InvalidBrestaFormatException(),
                Right = Int32.TryParse(intentationSplitted[2], out int r) ? r : throw new InvalidBrestaFormatException(),
                Bottom = Int32.TryParse(intentationSplitted[3], out int b) ? b : throw new InvalidBrestaFormatException(),
            };
        }
    }
}
