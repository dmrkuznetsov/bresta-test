using BrestaTest.Core.ModelPresentations;
using BrestaTest.Core.Models.Abstract;
using BrestaTest.Core.Models.Boards;
using BrestaTest.Core.Models.Enums;
using BrestaTest.Core.Models.Scales;
using BrestaTest.Core.Parser.Enums;
using BrestaTest.Core.Parser.Exceptions;
using System.Drawing;
using System.Globalization;

namespace BrestaTest.Core.Parser
{
    internal static class BrestaModelBuilder
    {
        public static BaseEntity CreateModel(string filePath, IDictionary<string, Token> tokens, ModelType modelType)
        {
            switch (modelType)
            {
                case ModelType.ScalesMV4TD:
                    {
                        if (!tokens.TryGetValue("name", out Token nameToken)) throw new InvalidBrestaFormatException();
                        if (!tokens.TryGetValue("sign", out Token signToken)) throw new InvalidBrestaFormatException();
                        if (!tokens.TryGetValue("id", out Token idToken)) throw new InvalidBrestaFormatException();
                        if (!tokens.TryGetValue("capacity", out Token capacityToken)) throw new InvalidBrestaFormatException();
                        if (!tokens.TryGetValue("minimal", out Token minimalToken)) throw new InvalidBrestaFormatException();
                        if (!tokens.TryGetValue("accuracy", out Token accuracyToken)) throw new InvalidBrestaFormatException();
                        if (!tokens.TryGetValue("algo", out Token algoToken)) throw new InvalidBrestaFormatException();
                        if (!tokens.TryGetValue("pos", out Token posToken)) throw new InvalidBrestaFormatException();
                        if (!tokens.TryGetValue("size", out Token sizeToken)) throw new InvalidBrestaFormatException();

                        if (!tokens.TryGetValue("pos", out Token thicknessToken)) throw new InvalidBrestaFormatException();
                        if (!tokens.TryGetValue("thicknessCurrent", out Token thicknessCurrentToken)) throw new InvalidBrestaFormatException();
                        if (!tokens.TryGetValue("thicknessMouse", out Token thicknessMouseToken)) throw new InvalidBrestaFormatException();
                        if (!tokens.TryGetValue("background", out Token backgroundToken)) throw new InvalidBrestaFormatException();
                        if (!tokens.TryGetValue("foreground", out Token foregroundToken)) throw new InvalidBrestaFormatException();
                        if (!tokens.TryGetValue("-foreground", out Token minusForegroundToken)) throw new InvalidBrestaFormatException();
                        if (!tokens.TryGetValue("stroke", out Token strokeToken)) throw new InvalidBrestaFormatException();
                        if (!tokens.TryGetValue("line", out Token lineToken)) throw new InvalidBrestaFormatException();
                        if (!tokens.TryGetValue("-line", out Token minusLineToken)) throw new InvalidBrestaFormatException();
                        if (!tokens.TryGetValue("iconPos", out Token iconPosToken)) throw new InvalidBrestaFormatException();
                        if (!tokens.TryGetValue("matPadding", out Token matPaddingToken)) throw new InvalidBrestaFormatException();
                        if (!tokens.TryGetValue("matValueMinWidth", out Token matValueMinWidthToken)) throw new InvalidBrestaFormatException();
                        if (!tokens.TryGetValue("matRounding", out Token matRoundingToken)) throw new InvalidBrestaFormatException();
                        if (!tokens.TryGetValue("matFontSize", out Token matFontSizeToken)) throw new InvalidBrestaFormatException();
                        if (!tokens.TryGetValue("matColor", out Token matColorToken)) throw new InvalidBrestaFormatException();
                        if (!tokens.TryGetValue("matAddIndent", out Token matAddIndentToken)) throw new InvalidBrestaFormatException();
                        tokens.TryGetValue("z", out Token zToken);

                        var textTokens = tokens.Where(x => x.Key == "text");

                        if (!tokens.TryGetValue("adrErrorModule1", out Token adrErrorModule1Token)) throw new InvalidBrestaFormatException();
                        if (!tokens.TryGetValue("adrErrorSensor1", out Token adrErrorSensor1Token)) throw new InvalidBrestaFormatException();
                        if (!tokens.TryGetValue("adrSensor1", out Token adrSensor1Token)) throw new InvalidBrestaFormatException();
                        if (!tokens.TryGetValue("CancelIfPause", out Token cancelIfPauseToken)) throw new InvalidBrestaFormatException();
                        if (!tokens.TryGetValue("errArrivalTime", out Token errArrivalTimeToken)) throw new InvalidBrestaFormatException();
                        if (!tokens.TryGetValue("errArrivalVal", out Token errArrivalValToken)) throw new InvalidBrestaFormatException();
                        if (!tokens.TryGetValue("errTimeMax", out Token errTimeMaxToken)) throw new InvalidBrestaFormatException();
                        tokens.TryGetValue("inFeederOutput", out Token inFeederOutputToken);
                        if (!tokens.TryGetValue("italonMass", out Token italonMassToken)) throw new InvalidBrestaFormatException();
                        if (!tokens.TryGetValue("italonMin", out Token italonMinToken)) throw new InvalidBrestaFormatException();
                        if (!tokens.TryGetValue("italonRange", out Token italonRangeToken)) throw new InvalidBrestaFormatException();
                        if (!tokens.TryGetValue("massReady", out Token massReadyToken)) throw new InvalidBrestaFormatException();
                        if (!tokens.TryGetValue("weighMax", out Token weightMaxToken)) throw new InvalidBrestaFormatException();
                        if (!tokens.TryGetValue("weighMin", out Token weightMinToken)) throw new InvalidBrestaFormatException();
                        var culture = CultureInfo.CreateSpecificCulture("en-US");
                        var scales = new ScalesMV4TD()
                        {
                            FullPathToFile = filePath,
                            Name = nameToken.Content,
                            Sign = signToken.Content,
                            Id = Int32.TryParse(idToken.Content, out int id) ? id : throw new InvalidBrestaFormatException(),
                            Capacity = float.TryParse(capacityToken.Content, NumberStyles.Number, culture, out float capacity) ? capacity : throw new InvalidBrestaFormatException(),
                            Minimal = float.TryParse(minimalToken.Content, NumberStyles.Number, culture, out float minimal) ? minimal : throw new InvalidBrestaFormatException(),
                            Accuracy = float.TryParse(accuracyToken.Content, NumberStyles.Number, culture, out float accuracy) ? accuracy : throw new InvalidBrestaFormatException(),
                            Algo = algoToken.Content,

                            AddrErrorModule1 = Int32.TryParse(adrErrorModule1Token.Content, out int adrErrorModule1) ? adrErrorModule1 : 0,
                            AddrErrorSensor1 = Int32.TryParse(adrErrorSensor1Token.Content, out int adrErrorSensor1) ? adrErrorSensor1 : 0,
                            AddrSensor1 = Int32.TryParse(adrSensor1Token.Content, out int adrSensor1) ? adrSensor1 : 0,
                            CancelIfPause = Int32.TryParse(cancelIfPauseToken.Content, out int cancelIfPause) ?
                                cancelIfPause == 1 ?
                                    PauseOption.IfPausedCancel :
                                    PauseOption.IfCritErrorCancel :
                            throw new InvalidBrestaFormatException(),
                            ErrArrivalTime = Int32.TryParse(errArrivalTimeToken.Content, out int errArrivalTime) ? errArrivalTime : throw new InvalidBrestaFormatException(),
                            ErrArrivalVal = float.TryParse(errArrivalValToken.Content, NumberStyles.Number, culture, out float errArrivalVal) ? errArrivalVal : throw new InvalidBrestaFormatException(),
                            ErrTimeMax = Int32.TryParse(errTimeMaxToken.Content, out int errTimeMax) ? errTimeMax : throw new InvalidBrestaFormatException(),
                            InFeederOutput = inFeederOutputToken.Content,
                            EtalonMass = Int32.TryParse(italonMassToken.Content, out int italonMass) ? italonMass : throw new InvalidBrestaFormatException(),
                            EtalonMin = float.TryParse(italonMinToken.Content, NumberStyles.Number, culture, out float italonMin) ? italonMin : throw new InvalidBrestaFormatException(),
                            EtalonRange = float.TryParse(italonRangeToken.Content, NumberStyles.Number, culture, out float italonRange) ? italonRange : throw new InvalidBrestaFormatException(),
                            MassReady = float.TryParse(massReadyToken.Content, NumberStyles.Number, culture, out float massReady) ? massReady : throw new InvalidBrestaFormatException(),
                            WeightMax = float.TryParse(weightMaxToken.Content, NumberStyles.Number, culture, out float weightMax) ? weightMax : throw new InvalidBrestaFormatException(),
                            WeightMin = float.TryParse(weightMinToken.Content, NumberStyles.Number, culture, out float weightMin) ? weightMin : throw new InvalidBrestaFormatException(),
                        };
                        scales.UiHint = new ScalesUiHint()
                        {
                            Position = BrestaCfgParser.ParsePosition(posToken.Content),
                            Size = BrestaCfgParser.ParseSize(sizeToken.Content),
                            Thickness = float.TryParse(capacityToken.Content, NumberStyles.Number, culture, out float thickness) ? thickness : throw new InvalidBrestaFormatException(),
                            ThicknessCurrent = float.TryParse(thicknessCurrentToken.Content, NumberStyles.Number, culture, out float thicknessCurrent) ? thicknessCurrent : throw new InvalidBrestaFormatException(),
                            ThicknessMouse = float.TryParse(thicknessMouseToken.Content, NumberStyles.Number, culture, out float thicknessMouse) ? thicknessMouse : throw new InvalidBrestaFormatException(),
                            Background = BrestaCfgParser.ParseColorWithPos(backgroundToken.Content),
                            Foreground = BrestaCfgParser.ParseColorWithPos(foregroundToken.Content),
                            MinusForeground = BrestaCfgParser.ParseColorWithPos(minusForegroundToken.Content),
                            Stroke = ColorTranslator.FromHtml(strokeToken.Content),
                            Line = BrestaCfgParser.ParseLineInfo(lineToken.Content),
                            MinusLine = BrestaCfgParser.ParseLineInfo(minusLineToken.Content),
                            IconPos = BrestaCfgParser.ParsePosition(iconPosToken.Content),
                            MatPadding = BrestaCfgParser.ParseIndentation(matPaddingToken.Content),
                            MatValueMinWidth = Int32.TryParse(matValueMinWidthToken.Content, out int matvalueMinWidth) ? matvalueMinWidth : throw new InvalidBrestaFormatException(),
                            MatRounding = Int32.TryParse(matRoundingToken.Content, out int matRounding) ? matRounding : throw new InvalidBrestaFormatException(),
                            MatFontSize = Int32.TryParse(matFontSizeToken.Content, out int matFontSize) ? matFontSize : throw new InvalidBrestaFormatException(),
                            //TODO mat color
                            MatAddIndent = Int32.TryParse(matAddIndentToken.Content, out int matAddIndent) ? matAddIndent : throw new InvalidBrestaFormatException(),
                            Z = Int32.TryParse(zToken.Content, out int z) ? z : 0
                        };
                        return scales;

                    }
                case ModelType.ScaleBoardElement:
                    {
                        if (!tokens.TryGetValue("name", out Token nameToken)) throw new InvalidBrestaFormatException();
                        if (!tokens.TryGetValue("id", out Token idToken)) throw new InvalidBrestaFormatException();
                        if (!tokens.TryGetValue("type", out Token typeToken)) throw new InvalidBrestaFormatException();

                        if (!tokens.TryGetValue("hideIfAuto", out Token hideIfAutoToken)) hideIfAutoToken = new Token() { TokenType=TokenType.Property, Name = "hideIfAuto", Content = "false" };
                        if (!tokens.TryGetValue("tgt", out Token tgtToken)) tgtToken = new Token() { TokenType=TokenType.Property, Name = "tgt", Content = "" };
                        if (!tokens.TryGetValue("click", out Token clickToken)) clickToken = new Token() { TokenType=TokenType.Property, Name = "click", Content = "" };
                        if (!tokens.TryGetValue("clickValue", out Token clickValueToken)) clickValueToken = new Token() { TokenType=TokenType.Property, Name = "clickValue", Content = "1" };
                        if (!tokens.TryGetValue("clickLog", out Token clickLogToken)) clickLogToken = new Token() { TokenType=TokenType.Property, Name = "clickLog", Content = "" };

                        return  new ScalesBoardElement()
                        {
                            FullPathToFile = filePath,
                            Name = nameToken.Content,
                            Id = Int32.TryParse(idToken.Content, out int id) ? id : throw new InvalidBrestaFormatException(),
                            Type = typeToken.Content,
                            HideIfAuto = hideIfAutoToken.Content == "true",
                            Tgt = tgtToken.Content,
                            Click = clickToken.Content,
                            ClickValue = Int32.TryParse(clickValueToken.Content, out int clickValue) ? clickValue : throw new InvalidBrestaFormatException(),
                            ClickLog = clickLogToken.Content,
                        };
                    }

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
