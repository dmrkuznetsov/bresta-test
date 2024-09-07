using BrestaTest.Core.Models.Boards;
using BrestaTest.Core.Models.Scales;
using BrestaTest.WPF.ModelViews.Abstract;
using System.IO;
using System.Drawing;
using System.Windows.Media;
using Color = System.Windows.Media.Color;

namespace BrestaTest.WPF.ModelViews
{
    public class ScalesModelView : ObservableObject
    {
        #region Поля-свойства
        public string FilePath { get => new FileInfo(_model.FullPathToFile).Name;  }
        private ScalesMV4TD _model;
        private List<ScalesBoardElement> _boardElements;
        public Point Position { get => _model.UiHint.Position; }
        public Size Size { get => _model.UiHint.Size; }
        public Brush Background { get => new SolidColorBrush(Color.FromArgb(
            _model.UiHint.Background.Color1.A,
            _model.UiHint.Background.Color1.R,
            _model.UiHint.Background.Color1.G,
            _model.UiHint.Background.Color1.B));
        }
        #endregion
        public ScalesModelView(ScalesMV4TD model, IEnumerable<ScalesBoardElement> boardElements)
        {
            _model = model;
            _boardElements = new List<ScalesBoardElement>(boardElements);
        }
    }
}
