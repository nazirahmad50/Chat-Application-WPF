
using System.Windows;


namespace Fasetto.Word
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // now this window is linked to the windowviewmodel
            DataContext = new WindowViewModel(this);
        }
    }
}
