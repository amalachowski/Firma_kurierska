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
using static Firma_kurierska.WindowFirma;



namespace Firma_kurierska.ExtraWindows
{
    /// <summary>
    /// Logika interakcji dla klasy KurierzyWyszukaj.xaml
    /// </summary>
    public partial class KurierzyWyszukaj : Window
    {
        DataGrid DataGrid;
        public KurierzyWyszukaj(DataGrid dataGrid)
        {
            InitializeComponent();
            this.DataGrid = dataGrid;
        }

        private void BtnKurierzyWWyjdz_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnKurierzyWWyszukaj_Click(object sender, RoutedEventArgs e)
        {
            SQLconnection sQLconnection = new SQLconnection();
            System.Windows.Controls.TextBox[] textBox = new TextBox[4];
            textBox[0] = TxtKurierzyWImie;
            textBox[1] = TxtKurierzyWNazwisko;
            textBox[2] = TxtKurierzyWMiasto;
            textBox[3] = TxtKurierzyWTelefon;
            sQLconnection.WyszukajKurierow(textBox,DataGrid);
            this.Close();
        }
    }
}
