using Firma_kurierska.Class;
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

namespace Firma_kurierska.WindowsZamowienie
{
    /// <summary>
    /// Logika interakcji dla klasy WindowZamowieniePodsumowanie.xaml
    /// </summary>
    public partial class WindowZamowieniePodsumowanie : Window
    {
        public WindowZamowieniePodsumowanie(int id_zamowienia)
        {
            InitializeComponent();
            SQLconnection sql = new SQLconnection();
            sql.WyswietlDane(dane, id_zamowienia);
            sql.WyswietlPaczki(DGZamowieniePaczki, id_zamowienia);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


        }
    }
}
