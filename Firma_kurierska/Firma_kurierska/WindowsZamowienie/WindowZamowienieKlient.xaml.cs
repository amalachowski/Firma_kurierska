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
using Firma_kurierska.Class;

namespace Firma_kurierska.WindowsZamowienie
{
    /// <summary>
    /// Logika interakcji dla klasy WindowZamowienieKlient.xaml
    /// </summary>
    public partial class WindowZamowienieKlient : Window
    {
        static SQLconnection sQLconnection = new SQLconnection();
        public WindowZamowienieKlient()
        {

            InitializeComponent();
            sQLconnection.WyswietlKlientow(DGZamowienieNadawca);
        }

        private void BtnZamowienieNadawcaDalej_Click(object sender, RoutedEventArgs e)
        {
            WindowZamowieniePaczki zamowieniePaczki = new WindowZamowieniePaczki();
            
            this.Hide();
            zamowieniePaczki.ShowDialog();
        }

        private void BtnZamowienieNadawcaWyjscie_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnZamowienieNadawcaWyszukaj_Click(object sender, RoutedEventArgs e)
        {
            sQLconnection.WyszukajNadawca(TxtZamowienieNadawcaWyszukaj,DGZamowienieNadawca);
        }
    }
}
