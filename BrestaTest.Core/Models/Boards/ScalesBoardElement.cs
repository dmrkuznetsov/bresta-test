using BrestaTest.Core.ModelPresentations;
using BrestaTest.Core.Models.Abstract;

namespace BrestaTest.Core.Models.Boards
{
    public class ScalesBoardElement : BaseEntity
    {
        public string FullPathToFile { get; set; }
        public string Type { get; set; }
        public bool HideIfAuto { get; set; }
        public string Tgt { get; set; }
        public string Click { get; set; }
        public int ClickValue { get; set; }
        public string ClickLog { get; set; }
        public string PauseCancelTgt { get; set; }
        public ScalesBoardUiHint UiHint {get;set;}
    }
}
