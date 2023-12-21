using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PracaWPF
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

        private void goToLogowanie(object sender, RoutedEventArgs e)
        {
            Logowanie logow = new Logowanie();
            this.Visibility = Visibility.Collapsed;
            logow.Visibility = Visibility.Visible;
        }

        private void goToRejestracja(object sender, RoutedEventArgs e)
        {
            Rejestracja rejestracja = new Rejestracja();
            this.Visibility = Visibility.Collapsed;
            rejestracja.Visibility = Visibility.Visible;
        }
    }
}
