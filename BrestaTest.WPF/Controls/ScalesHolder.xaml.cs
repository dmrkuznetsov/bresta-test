using BrestaTest.WPF.ModelViews;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace BrestaTest.WPF.Controls
{
    /// <summary>
    /// Interaction logic for ScalesHolder.xaml
    /// </summary>
    public partial class ScalesHolder : UserControl
    {
        public ObservableCollection<ScalesModelView> ScalesCollection 
        {
            get { return (ObservableCollection<ScalesModelView>)GetValue(ScalesCollectionProperty); }
            set {
                SetValue(ScalesCollectionProperty, value); 
             /*   value.CollectionChanged += ScalesCollectionChanged; */}
        }
        private void ScalesCollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            MessageBox.Show("ok");
        }
        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ScalesCollectionProperty =
            DependencyProperty.Register("ScalesCollection", typeof(ObservableCollection<ScalesModelView>), typeof(ScalesHolder), new PropertyMetadata(new ObservableCollection<ScalesModelView>()));

        public ScalesHolder()
        {
            InitializeComponent();
        }
    }
}
