using PracaWPF.classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PracaWPF
{
    /// <summary>
    /// Logika interakcji dla klasy Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public ObservableCollection<Offer> ofert { get; private set; }
        public Menu()
        {
            InitializeComponent();
            ofert = new ObservableCollection<Offer>(Database.ReadOffer());
            offersLiist.ItemsSource = ofert;
        }

        private void goToNowaPraca(object sender, RoutedEventArgs e)
        {
            NowaPraca nowaPraca = new NowaPraca();
            this.Visibility = Visibility.Collapsed;
            nowaPraca.Visibility = Visibility.Visible;
        }
    }
}
