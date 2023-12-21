using PracaWPF.classes;
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
using System.Windows.Shapes;
using System.Xml.Linq;

namespace PracaWPF
{
    /// <summary>
    /// Logika interakcji dla klasy Logowanie.xaml
    /// </summary>
    public partial class Logowanie : Window
    {
        public Logowanie()
        {
            InitializeComponent();
        }

        private void logIn(object sender, RoutedEventArgs e)
        {
            string email = mailText.Text;
            string pass = passwordText.Text;
            User existingUser = Database.ReadUserByMail(email);

            if (existingUser != null)
            {
                if(existingUser.Password == passwordText.Text)
                {
                    Menu menu = new Menu();
                    menu.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Nie poprawne hasło", "Błąd logowania", MessageBoxButton.OK);
                }
            }
            else
            {
                MessageBox.Show("Nie poprawny mail", "Błąd logowania", MessageBoxButton.OK);
            }



        }
    }
}
