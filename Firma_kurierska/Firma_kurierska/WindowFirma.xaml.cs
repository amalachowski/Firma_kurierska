using Firma_kurierska.Class;
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

namespace Firma_kurierska
{
    /// <summary>
    /// Logika interakcji dla klasy WindowFirma.xaml
    /// </summary>
    public partial class WindowFirma : Window
    {
        private int id_uzytkownika;
        private int id_rekoruKlienta;
        private int id_rekordAdres;

        

        public WindowFirma(int id_uzytkownika)
        {
            InitializeComponent();
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            this.MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
            SQLconnection sQLconnection = new SQLconnection();
            sQLconnection.WyswietlKlientow(DGKlienci);
            this.id_uzytkownika = id_uzytkownika;

            
        }
        #region KlienciBTN
        private void BtinKlienciWyszukaj_Click(object sender, RoutedEventArgs e)
        {

            TextBox[] textBoxesKlienci = new TextBox[8];
            textBoxesKlienci[0] = TxtKlienciImie;
            textBoxesKlienci[1] = TxtKlienciNazwisko;
            textBoxesKlienci[2] = TxtKlienciMiasto;
            textBoxesKlienci[3] = TxtKlieciUlica;
            textBoxesKlienci[4] = TxtKlienciNRUlica;
            textBoxesKlienci[5] = TxtKlienciLokal;
            textBoxesKlienci[6] = TxtKlienciTelefon;
            textBoxesKlienci[7] = TxtKlienciEmail;


            SQLconnection sQLconnection = new SQLconnection();
            sQLconnection.WyszukajKlienci(textBoxesKlienci,DGKlienci);






        }

        private void BtnKlienciDodaj_Click(object sender, RoutedEventArgs e)
        {
            Helper helper = new Helper();
            TextBox[] textBoxesKlienci = new TextBox[8];
            textBoxesKlienci[0] = TxtKlienciImie;
            textBoxesKlienci[1] = TxtKlienciNazwisko;
            textBoxesKlienci[2] = TxtKlienciMiasto;
            textBoxesKlienci[3] = TxtKlieciUlica;
            textBoxesKlienci[4] = TxtKlienciNRUlica;
            textBoxesKlienci[5] = TxtKlienciLokal;
            textBoxesKlienci[6] = TxtKlienciTelefon;
            textBoxesKlienci[7] = TxtKlienciEmail;
            SQLconnection sQLconnection = new SQLconnection();
            sQLconnection.DodajKlienci(textBoxesKlienci,CBKlinetVIP);
            sQLconnection.WyswietlKlientow(DGKlienci);

            helper.WyczyscFormatke(textBoxesKlienci);

        }

        private void DGKlienci_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            DataGrid dataGrid = sender as DataGrid;
            DataRowView rowView = dataGrid.SelectedItem as DataRowView;
            try
            {
                if (rowView != null)
                {
                    id_rekoruKlienta = (int)rowView.Row[0]; // zapisywanie wybranego id klienta
                    TxtKlienciImie.Text = rowView.Row[1].ToString(); /* 1st Column on selected Row */
                    id_rekordAdres = (int)rowView.Row[2]; // zapisywanie wybranego id Adresu
                    TxtKlienciNazwisko.Text = rowView.Row[3].ToString();
                    TxtKlienciMiasto.Text = rowView.Row[4].ToString();
                    TxtKlieciUlica.Text = rowView.Row[5].ToString();
                    TxtKlienciNRUlica.Text = rowView.Row[6].ToString();
                    TxtKlienciLokal.Text = rowView.Row[7].ToString();
                    TxtKlienciTelefon.Text = rowView.Row[8].ToString();
                    TxtKlienciEmail.Text = rowView.Row[9].ToString();
                    CBKlinetVIP.IsChecked = (bool)rowView.Row[10];
                    
                }
            }
            catch (Exception kom) 
            {
                MessageBox.Show(kom.Message );
            }
        }

        private void BtnKlienciUsun_Click(object sender, RoutedEventArgs e)
        {
            TextBox[] textBoxesKlienci = new TextBox[8];
            textBoxesKlienci[0] = TxtKlienciImie;
            textBoxesKlienci[1] = TxtKlienciNazwisko;
            textBoxesKlienci[2] = TxtKlienciMiasto;
            textBoxesKlienci[3] = TxtKlieciUlica;
            textBoxesKlienci[4] = TxtKlienciNRUlica;
            textBoxesKlienci[5] = TxtKlienciLokal;
            textBoxesKlienci[6] = TxtKlienciTelefon;
            textBoxesKlienci[7] = TxtKlienciEmail;
            Helper helper = new Helper();
            SQLconnection sql = new SQLconnection();
            sql.UsunKlienci(id_rekordAdres,id_rekoruKlienta);
            sql.WyswietlKlientow(DGKlienci);
            helper.WyczyscFormatke(textBoxesKlienci);






        }

        private void BtnKlienciEdytuj_Click(object sender, RoutedEventArgs e)
        {
            Helper helper = new Helper();
            SQLconnection sql = new SQLconnection();
            TextBox[] textBoxesKlienci = new TextBox[8];
            textBoxesKlienci[0] = TxtKlienciImie;
            textBoxesKlienci[1] = TxtKlienciNazwisko;
            textBoxesKlienci[2] = TxtKlienciMiasto;
            textBoxesKlienci[3] = TxtKlieciUlica;
            textBoxesKlienci[4] = TxtKlienciNRUlica;
            textBoxesKlienci[5] = TxtKlienciLokal;
            textBoxesKlienci[6] = TxtKlienciTelefon;
            textBoxesKlienci[7] = TxtKlienciEmail;
            sql.EdytujKlienci(id_rekoruKlienta,id_rekordAdres,textBoxesKlienci,CBKlinetVIP);
            sql.WyswietlKlientow(DGKlienci);
            helper.WyczyscFormatke(textBoxesKlienci);



        }
        #endregion
        #region ZmianaHasla
        private void BtnZmienDaneZmien_Click(object sender, RoutedEventArgs e)
        {
            SQLconnection sQLconnection = new SQLconnection();
            Helper helper = new Helper();
            if (sQLconnection.SprawdzPoprzednieHaslo(TxtZmienDaneStareHaslo.Text, id_uzytkownika))
            {
                if (helper.PoprawnoscHaslaStaregoINowego(TxtZamienDaneNoweHaslo, TxtZmienDaneNoweHaslo2))
                {
                    sQLconnection.ZmienHasloUzytkownika(TxtZamienDaneNoweHaslo.Text, id_uzytkownika);
                    MessageBox.Show("Haslo zostało zmienione");
                }
            }
            else 
            {
                MessageBox.Show("Stare haslo jest błędne");

            }
        }
        #endregion
    }
}
