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

        private void delJobBut_Click(object sender, RoutedEventArgs e)
        {
            Offer selected = offersLiist.SelectedItem as Offer;

            if (selected != null)
            {
                var result = MessageBox.Show("Czy na pewno chcesz usunąć tą ofertę?", "Question", MessageBoxButton.YesNoCancel);
                if (result == MessageBoxResult.Yes)
                {
                    Database.DeleteOffer(selected);

                    ofert = new ObservableCollection<Offer>(Database.ReadOffer());
                    offersLiist.ItemsSource = ofert;
                }
                else
                {
                    MessageBox.Show("Akcja została anulowana", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Proszę wybrać daną", "Info", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void offersLiist_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Offer selected = offersLiist.SelectedItem as Offer;

            if (selected != null)
            {

                Offer f = Database.OfferInfo(selected.OfferId);

                MessageBox.Show("ID: "+f.OfferId + "\nTytuł: "+f.Title+ "\nPozycja: " +f.Position +"\nPłaca: " + f.Payment + "\nTak dalej", "Info", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("Proszę wybrać daną", "Info", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void goToUser(object sender, RoutedEventArgs e)
        {
            Menu2 menu2 = new Menu2();
            this.Visibility = Visibility.Collapsed;
            menu2.Visibility = Visibility.Visible;
        }
    }
}
