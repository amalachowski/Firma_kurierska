using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Logika interakcji dla klasy KurierzyEdytuj.xaml
    /// </summary>
    public partial class KurierzyEdytuj : Window
    {
        string[] daneKuriera;
        DataGrid dataGrid;
        private int idKuriera;
        public KurierzyEdytuj(int idKuriera,string[] daneKuriera,DataGrid dataGrid)
        {
            
            InitializeComponent();
            this.idKuriera = idKuriera;
            this.dataGrid = dataGrid;
            this.daneKuriera = daneKuriera;
            WypelnijTextbox();
            
        }

        public void WypelnijTextbox() //wypelniania textboxow w panelu edytuj z data grid
        {
           
            TxtKurierzyEImie.Text = daneKuriera[0];
            TxtKurierzyENazwisko.Text = daneKuriera[1];
            TxtKurierzyEMiasto.Text = daneKuriera[2];
            TxtKurierzyETelefon.Text = daneKuriera[3];

        }

        private void BtnKuerierzyEWyjdz_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnKuerierzyEEdytuj_Click(object sender, RoutedEventArgs e)
        {
            TextBox[] textBoxes = new TextBox[4];
            textBoxes[0] = TxtKurierzyEImie;
            textBoxes[1] = TxtKurierzyENazwisko;
            textBoxes[2] = TxtKurierzyEMiasto;
            textBoxes[3] = TxtKurierzyETelefon;

            SQLconnection sQLconnection = new SQLconnection();
            sQLconnection.EdytujKuriera(textBoxes,idKuriera);
            sQLconnection.WyswietlKuerierow(dataGrid);
            this.Close();
        }
    }
}
