using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using BrestaTest.WPF.Controls;
using BrestaTest.WPF.ModelViews;
using System.Collections.Specialized;

namespace BrestaTest.WPF.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dispatcher _dispatcher;
        private MainModelView _mv;
        public MainWindow()
        {
            InitializeComponent();
            _mv = (MainModelView)DataContext;
            _mv.Scales.CollectionChanged += Scales_CollectionChanged;
            _dispatcher = Dispatcher.CurrentDispatcher;
        }
        private int _sampleXOffset = -800;
        private int _samplYOffset = -100;
        private void Scales_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            _dispatcher.Invoke(() =>
            {
                switch (e.Action) 
                {
                    case NotifyCollectionChangedAction.Reset:
                        ScalesHolder.Children.Clear();
                        break;
                    case NotifyCollectionChangedAction.Add:
                        foreach (var item in e.NewItems)
                        {
                            var mv = (ScalesModelView)item;
                            var c = new ScalesControl(mv);
                            ScalesHolder.Children.Add(c);
                            //c.Width = mv.Size.Width;
                            //c.Height = mv.Size.Height;
                            c.Visibility = Visibility.Visible;
                            Canvas.SetLeft(c, mv.Position.X + _sampleXOffset);
                            Canvas.SetTop(c, mv.Position.Y + _samplYOffset);
                        }
                        break;
                }
            });
        }
    }
}