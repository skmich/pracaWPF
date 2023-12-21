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

namespace PracaWPF
{
    /// <summary>
    /// Logika interakcji dla klasy Rejestracja.xaml
    /// </summary>
    public partial class Rejestracja : Window
    {
        public Rejestracja()
        {
            InitializeComponent();
        }

        private void confirmation_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();
            user.Name = name.Text;
            user.Surname = surname.Text;
            user.BirthDate = birthdate.Text;
            user.Mail = mail.Text;
            user.Telephone = int.Parse(phone.Text);
            user.Password = password.Text;
            user.IsAdmin = admin.ToString() == "true";

            Database.CreateUser(user);

            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}
