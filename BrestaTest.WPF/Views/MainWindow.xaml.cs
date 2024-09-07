using System.Windows;
using BrestaTest.Core.Loader;

namespace BrestaTest.WPF.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private string _sample = "";
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var models = ScalesLoader.LoadScales("C:\\Users\\Admin\\Desktop\\Новая папка\\scales\\", "C:\\Users\\Admin\\Desktop\\Новая папка\\boards\\");

            int sdfd = 0;
        }
    }
}