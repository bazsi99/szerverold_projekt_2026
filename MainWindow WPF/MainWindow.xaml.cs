using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
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
        private void Foetel_Click(object sender, RoutedEventArgs e)
        {
            new EtelWindow("foetel", "Főételek").Show();
        }

        private void Leves_Click(object sender, RoutedEventArgs e)
        {
            new EtelWindow("leves", "Levesek").Show();
        }

        private void Desszert_Click(object sender, RoutedEventArgs e)
        {
            new EtelWindow("desszert", "Desszertek").Show();
        }

        private void Random_Click(object sender, RoutedEventArgs e)
        {
            new RandomWindow().Show();
        }
    }
}