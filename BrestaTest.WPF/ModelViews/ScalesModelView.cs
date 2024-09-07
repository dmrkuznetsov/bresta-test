using BrestaTest.Core.Models.Boards;
using BrestaTest.Core.Models.Scales;
using BrestaTest.WPF.ModelViews.Abstract;
using System.IO;

namespace BrestaTest.WPF.ModelViews
{
    public class ScalesModelView : ObservableObject
    {
        #region Поля-свойства
        public string FilePath { get => new FileInfo(_model.FullPathToFile).Name;  }
        private ScalesMV4TD _model;
        private List<ScalesBoardElement> _boardElements;
        #endregion
        public ScalesModelView(ScalesMV4TD model, IEnumerable<ScalesBoardElement> boardElements)
        {
            _model = model;
            _boardElements = new List<ScalesBoardElement>(boardElements);
        }
    }
}
