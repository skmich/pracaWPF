using PracaWPF.classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace PracaWPF
{
    /// <summary>
    /// Logika interakcji dla klasy Menu2.xaml
    /// </summary>
    public partial class Menu2 : Window
    {
        public ObservableCollection<User> user { get; private set; }
        public Menu2()
        {
            InitializeComponent();
            user = new ObservableCollection<User>(Database.ReadUser());
            usersList.ItemsSource = user;
        }


        private void delUserBut_Click(object sender, RoutedEventArgs e)
        {
            User selected = usersList.SelectedItem as User;

            if (selected != null)
            {
                var result = MessageBox.Show("Czy na pewno chcesz usunąć tego użytkownika?", "Question", MessageBoxButton.YesNoCancel);
                if (result == MessageBoxResult.Yes)
                {
                    Database.DeleteUser(selected);

                    user = new ObservableCollection<User>(Database.ReadUser());
                    usersList.ItemsSource = user;
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

        private void usersList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            User selected = usersList.SelectedItem as User;

            if (selected != null)
            {

                User f = Database.UserInfo(selected.Id);

                MessageBox.Show("ID: " + f.Id + "\nImie: " + f.Name + "\nNazwisko: " + f.Surname + "\nData urodzenia: " + f.BirthDate + "\nTak dalej", "Info", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("Proszę wybrać daną", "Info", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void goToOffer(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            this.Visibility = Visibility.Collapsed;
            menu.Visibility = Visibility.Visible;
        }
    }
}
