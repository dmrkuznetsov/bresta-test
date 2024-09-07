using BrestaTest.Core.Models.Abstract;
using BrestaTest.Core.Models.UiHints;

namespace BrestaTest.Core.ModelPresentations
{
    public class ScalesBoardUiHint : BaseUiHint 
    {
        public int Radius { get; set; }
        public int Stroke { get; set; }
        public ColorWithPosition Background { get; set; } 
        public ColorWithPosition MinusBackground { get; set; } 
    }
}
