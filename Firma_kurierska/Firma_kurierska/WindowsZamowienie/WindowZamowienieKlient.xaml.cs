using System;
using System.Collections.Generic;
using System.Data;
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
        private int id_nadawcy { get; set; }
        static SQLconnection sQLconnection = new SQLconnection();
        Helper Helper = new Helper();
        public WindowZamowienieKlient()
        {

            InitializeComponent();
            sQLconnection.WyswietlKlientow(DGZamowienieNadawca);
            Helper.ZaladujCBZamowienieIloscPaczek(CBZamowienieIloscPaczek);
        }

        private void BtnZamowienieNadawcaDalej_Click(object sender, RoutedEventArgs e)
        {
            int wybranaIloscPaczek;
            
            sQLconnection.DodajZamowienie(id_nadawcy);
            wybranaIloscPaczek = (int)CBZamowienieIloscPaczek.SelectedItem;
            sQLconnection.DodajPaczki(wybranaIloscPaczek);
            WindowZamowieniePaczki zamowieniePaczki = new WindowZamowieniePaczki();
            this.Close();


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

        private void DGZamowienieNadawca_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;
            DataRowView rowView = dataGrid.SelectedItem as DataRowView;
            try
            {
                if (rowView != null)
                {
                    id_nadawcy = (int)rowView.Row[0]; // zapisywanie wybranego id nadawcy
                    

                }

            }
            catch (Exception kom)
            {
                MessageBox.Show(kom.Message);
            }
        }
    }
}
