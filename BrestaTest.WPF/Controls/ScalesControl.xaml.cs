using BrestaTest.WPF.ModelViews;
using System.Windows.Controls;

namespace BrestaTest.WPF.Controls
{
    /// <summary>
    /// Interaction logic for Scales.xaml
    /// </summary>
    public partial class ScalesControl : UserControl
    {
        public ScalesControl(ScalesModelView mv)
        {
            DataContext = mv;
            InitializeComponent();
        }
    }
}
