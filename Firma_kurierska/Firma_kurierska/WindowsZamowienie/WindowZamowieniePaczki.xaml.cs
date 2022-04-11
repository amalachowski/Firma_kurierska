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
    /// Logika interakcji dla klasy WindowZamowieniePaczki.xaml
    /// </summary>
    public partial class WindowZamowieniePaczki : Window
    {
        SQLconnection sQLconnection = new SQLconnection();
        private static string miasto;
        private static string ulica;
        private static string nr_ulicy;
        private static string lokal;
        private static int id_paczki;
        private static int id_kuriera;
        private static  int id_statusu;


        public WindowZamowieniePaczki()
        {
            InitializeComponent();
            sQLconnection.WyswietlPaczki(DGZamowieniePaczki);
            sQLconnection.WypelnijRodzajePaczek(CBZamowienieRodzajPaczki);
            sQLconnection.WyswietlKuerierow(DGZamowienieKurierzy);
        }

        private void BtnZamowieniePaczkiDodaj_Click(object sender, RoutedEventArgs e)
        {
            
            

            id_statusu = (int)CBZamowienieRodzajPaczki.SelectedValue;
            miasto = TxtPaczkaMiasto.Text;
            ulica = TxtPaczkaUlica.Text;
            nr_ulicy = TxtPaczkaNRUlica.Text;
            lokal = TxtPaczkaLokal.Text;
            
            sQLconnection.UaktualinijPaczki(miasto , ulica , nr_ulicy, lokal, id_kuriera, id_paczki, id_statusu);
            sQLconnection.UaktualnijZamowienie();
            
            sQLconnection.WyswietlPaczki(DGZamowieniePaczki);

        }

        private void DGZamowieniePaczki_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BtnZamowieniePaczkiUsun.Visibility = Visibility.Visible;
            DataGrid dataGrid = sender as DataGrid;
            DataRowView rowView = dataGrid.SelectedItem as DataRowView;
            try
            {
                if (rowView != null)
                {
                    id_paczki = (int)rowView.Row[0]; // zapisywanie wybranego id paczki
                    

                }

            }
            catch (Exception kom)
            {
                MessageBox.Show(kom.Message);
            }

        }

        private void DGZamowienieKurierzy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;
            DataRowView rowView = dataGrid.SelectedItem as DataRowView;
            
            try
            {
                if (rowView != null)
                {
                    id_kuriera = (int)rowView.Row[0]; // zapisywanie wybranego id Kuriera


                }

            }
            catch (Exception kom)
            {
                MessageBox.Show(kom.Message);
            }

        }

        private void BtnZamowieniePaczkiUsun_Click(object sender, RoutedEventArgs e)
        {
            sQLconnection.UsunPaczke(id_paczki);
            sQLconnection.WyswietlPaczki(DGZamowieniePaczki);


        }

        private void BtnZamowieniePaczkiZatwierdz_Click(object sender, RoutedEventArgs e)
        {
            
            this.Close();
        }
    }
}
