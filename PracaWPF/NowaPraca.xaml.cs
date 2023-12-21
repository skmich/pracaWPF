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
    /// Logika interakcji dla klasy NowaPraca.xaml
    /// </summary>
    public partial class NowaPraca : Window
    {
        public NowaPraca()
        {
            InitializeComponent();
        }

        private void AddOffer_Click(object sender, RoutedEventArgs e)
        {
            Offer offer = new Offer() {
                Title = title.Text,
                Position = position.Text,
                Payment = int.Parse(payment.Text),
                WorkHours = workHours.Text,
                Responsibilities = responsibilities.Text,
                Requirements = requirements.Text,
                Benefits = benefits.Text
            };
            

            Database.CreateOffer(offer);

            Menu menu = new Menu();
            menu.Show();
            this.Close();
        }
    }
}
