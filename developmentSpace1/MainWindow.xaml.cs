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

namespace developmentSpace1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Window2 window2 = new Window2();

        Window1 window1 = new Window1();

        public MainWindow() => InitializeComponent();
        
        private void Add_Click(object sender, RoutedEventArgs e)
        {
                     //this.Visibility = Visibility.Hidden;
                     window1.Show();
        }
        private void View_Click(object sender, RoutedEventArgs e)
        {

            //this.Visibility = Visibility.Hidden;
            window2.Show();

        }

        
    }
}