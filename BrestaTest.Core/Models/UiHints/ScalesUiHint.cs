using BrestaTest.Core.Models.Abstract;
using BrestaTest.Core.Models.UiHints;
using System.Drawing;

namespace BrestaTest.Core.ModelPresentations
{
    public class ScalesUiHint : BaseUiHint 
    {
        public Point Position { get; set; }
        public Size Size { get; set; }
        public float Thickness { get; set; } = 0.5F;
        public float ThicknessCurrent { get; set; } = 0.5F;
        public float ThicknessMouse { get; set; } = 0.5F;
        public ColorWithPosition Background { get; set; }
        public ColorWithPosition Foreground { get; set; } 
        public ColorWithPosition MinusForeground { get; set; }  
        public Color Stroke { get; set; } = ColorTranslator.FromHtml("#FF717171");
        public LineInfo Line { get; set; }
        public LineInfo MinusLine { get; set; }
        public Point IconPos { get; set; }
        public Indentation MatPadding { get; set; }
        public int MatValueMinWidth { get; set; } = 2;
        public int MatRounding { get; set; } = 2;
        public int MatFontSize { get; set; } = 8;
        public Color MatColor { get; set; }
        public int MatAddIndent { get; set; } = 5;
        public string[] Text { get; set; }
        public int Z { get; set; }
    }
}
