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

namespace Firma_kurierska.ExtraWindows
{
    /// <summary>
    /// Logika interakcji dla klasy KurierzyDodaj.xaml
    /// </summary>
    public partial class KurierzyDodaj : Window
    {
        DataGrid dataGrid;
        public KurierzyDodaj(DataGrid dataGrid)
        {
            InitializeComponent();
            this.dataGrid = dataGrid;
        }

        private void BtnKurierzyWWyszukaj_Click(object sender, RoutedEventArgs e)
        {
            TextBox[] textBoxes = new TextBox[4];
            textBoxes[0] = TxtKurierzyDImie;
            textBoxes[1] = TxtKurierzyDNazwisko;
            textBoxes[2] = TxtKurierzyDMiasto;
            textBoxes[3] = TxtKurierzyDTelefon;

            SQLconnection sQLconnection = new SQLconnection();
            sQLconnection.DodajKurierow(textBoxes);
            sQLconnection.WyswietlKuerierow(dataGrid);
            this.Close();
        }

        private void BtnKurierzyWWyjdz_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
