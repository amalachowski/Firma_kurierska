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
using Firma_kurierska.ExtraWindows;
using System.Windows.Shapes;


namespace Firma_kurierska
{
    /// <summary>
    /// Logika interakcji dla klasy WindowFirma.xaml
    /// </summary>
    public partial class WindowFirma : Window
    {
        private int id_uzytkownika;
        private int id_pracownika;
        private int id_rekoruKlienta;
        private int id_rekordAdres;
        private int id_KurierKuriera;
        private string kurierImieKuriera;
        private string kurierNazwiskoKuriera;
        private string kurierMiastoKuriera;
        private string kurierTelefonKuriera;


        

        public WindowFirma(int id_uzytkownika, int idStanowiska)
        {
            InitializeComponent();
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            this.MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
            SQLconnection sQLconnection = new SQLconnection();
            sQLconnection.WyswietlKlientow(DGKlienci);
            sQLconnection.WyswietlKuerierow(DGKureirzy);
            this.id_uzytkownika = id_uzytkownika;
            if (idStanowiska > 2)
            {
               TabItemPracownicy.Width = 0;               // Ukrywanie Pracownikow i kurierow
               TabItemKurierzy.Width = 0;
            
            }

            
        }
        #region KlienciBTN
        private void BtinKlienciWyszukaj_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(TxtKlienciImie.Text);

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
            if (chbx_pokaz.IsChecked == true)
            {
                MessageBox.Show("Ukryj hasło aby je dodać");

            }
            else
            {
                SQLconnection sQLconnection = new SQLconnection();
                Helper helper = new Helper();
                string stare = sQLconnection.Szyfruj(TxtZmienDaneStareHaslo.Password);

                if (sQLconnection.SprawdzPoprzednieHaslo(stare, id_uzytkownika))
                {


                    if (helper.PoprawnoscHaslaStaregoINowego(TxtZamienDaneNoweHaslo.Password, TxtZmienDaneNoweHaslo2.Password))
                    {
                        if (TxtZamienDaneNoweHaslo.Password == TxtZmienDaneStareHaslo.Password)
                        {
                            MessageBox.Show("Nowe hasło nie może być takie jak stare.");
                            return;
                        }
                        
                        if (TxtZamienDaneNoweHaslo.Password.Length < 8 || TxtZamienDaneNoweHaslo.Password.Length > 14)
                        {
                            MessageBox.Show("Hasło musi mieć minimum 8 znaków, maksymalnie 14.");
                            return;
                        }
                        else if (!TxtZamienDaneNoweHaslo.Password.Any(char.IsUpper))
                        {
                            MessageBox.Show("Hasło musi mieć conajmniej 1 wielką literę");
                            return;
                        }
                        else if (!TxtZamienDaneNoweHaslo.Password.Any(char.IsLower))
                        {
                            MessageBox.Show("Hasło musi mieć conajmniej 1 małą literę");
                            return;
                        }
                        else if (TxtZamienDaneNoweHaslo.Password.Contains(" "))
                        {
                            MessageBox.Show("Hasło nie może zawierać spacji");
                            return;
                        }
                        bool isspecjal = false;
                        string specialCh = @"%!@#$%^&*()?/>.<,:;'\|}]{[_~`+=-" + "\"";
                        char[] specialChh = specialCh.ToCharArray();
                        foreach (char ch in specialChh)
                        {
                            if (TxtZamienDaneNoweHaslo.Password.Contains(ch))
                            {
                                isspecjal = true;
                            }

                        }
                        if (!isspecjal)
                        {
                            MessageBox.Show("Hasło musi zawierać znak specjalny");
                            return;
                        }
                        sQLconnection.ZmienHasloUzytkownika(TxtZamienDaneNoweHaslo.Password, id_uzytkownika);
                        MessageBox.Show("Hasło zostało zmienione!");
                    }
                }
                else
                {
                    MessageBox.Show("Stare haslo jest błędne");

                }
            }
        }

        #endregion


        #region Kurierzy
        private void BtnKuerirzyWyszukaj_Click(object sender, RoutedEventArgs e)
        {
            ExtraWindows.KurierzyWyszukaj kurierzyWyszukaj = new KurierzyWyszukaj(DGKureirzy);
            kurierzyWyszukaj.ShowDialog();
            
            
        }

        private void BtnKurierzyDodaj_Click(object sender, RoutedEventArgs e)
        {
            KurierzyDodaj kurierzyDodaj = new KurierzyDodaj(DGKureirzy);
            kurierzyDodaj.ShowDialog();
        }

        private void BtnKurierzyUsun_Click(object sender, RoutedEventArgs e)
        {
            if (id_KurierKuriera != 0)
            {
                SQLconnection sQLconnection = new SQLconnection();
                sQLconnection.UsunKuriera(id_KurierKuriera);
                sQLconnection.WyswietlKuerierow(DGKureirzy);
            }
            else 
            {

                MessageBox.Show("Nie wybrano Kuriera do usnięcia");
            }
        }

        private void DGKureirzy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;
            DataRowView rowView = dataGrid.SelectedItem as DataRowView;
            try
            {
                if (rowView != null)
                {
                    id_KurierKuriera = (int)rowView.Row[0]; // zapisywanie wybranego id Kuriera
                    kurierImieKuriera = (string)rowView.Row[1];
                    kurierNazwiskoKuriera = (string)rowView.Row[2];
                    kurierMiastoKuriera = (string)rowView.Row[3];
                    kurierTelefonKuriera = (string)rowView.Row[4];

                }
               
            }
            catch (Exception kom)
            {
                MessageBox.Show(kom.Message);
            }
            


        }
        private void BtnKurierzyEdytujClick(object sender, RoutedEventArgs e)
        {
            if (id_KurierKuriera != 0) 
            {
                string[] daneKuriera = new string[4];
                daneKuriera[0] = kurierImieKuriera.ToString();
                daneKuriera[1] = kurierNazwiskoKuriera.ToString();
                daneKuriera[2] = kurierMiastoKuriera.ToString();
                daneKuriera[3] = kurierTelefonKuriera.ToString();
                KurierzyEdytuj kurierzyEdytuj = new KurierzyEdytuj(id_KurierKuriera, daneKuriera, DGKureirzy);


            kurierzyEdytuj.ShowDialog(); 
            }
            else
            {

                MessageBox.Show("Nie wybrano Kuriera do edytowania");
            }



        }

        #endregion


        #region Wyjscie
        private void BtnWyjscieWyjdz_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
        
        private void BtnWyjscieWyloguj_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();

            this.Close();
            mainWindow.Show();

        }


        #endregion

        private void BtnKurierzyOdswierz_Click(object sender, RoutedEventArgs e)
        {
            SQLconnection sQLconnection = new SQLconnection();
            sQLconnection.WyswietlKuerierow(DGKureirzy);
        }

        #region Pracownicy

        private void BtinPracownicyWyszukaj_Click(object sender, RoutedEventArgs e)
        {
            string[] danePracownicy = new string[4];
            danePracownicy[0] = tbx_prac_imie.Text;
            danePracownicy[1] = tbx_prac_nazwisko.Text;
            danePracownicy[2] = tbx_prac_login.Text;
            danePracownicy[3] = cbx_stanowisko.Text;

            SQLconnection sQLconnection = new SQLconnection();
            sQLconnection.WyszukajPracownicy(danePracownicy, dgv_pracownicy);
        }

        private void Dgv_pracownicy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;
            DataRowView rowView = dataGrid.SelectedItem as DataRowView;
            try
            {
                if (rowView != null)
                {
                    id_pracownika = (int)rowView.Row[0]; // zapisywanie wybranego id pracownika
                    tbx_prac_imie.Text = rowView.Row[1].ToString(); /* 1st Column on selected Row */
                    tbx_prac_nazwisko.Text = rowView.Row[2].ToString();
                    tbx_prac_login.Text = rowView.Row[3].ToString();
                    cbx_stanowisko.Text = rowView.Row[4].ToString();
                    tbx_prac_haslo.Text = rowView.Row[5].ToString();
                    tbx_prac_haslo.Text = "";
                    tbx_prac_haslo2.Text = "";
                    lbxHaslo.Content = "Podaj nowe hasło:";


                }
            }
            catch (Exception kom)
            {
                MessageBox.Show(kom.Message);
            }
        }

        private void Btn_czysc_Click(object sender, RoutedEventArgs e)
        {
            Helper helper = new Helper();
            TextBox[] textBoxes = new TextBox[5];
            textBoxes[0] = tbx_prac_imie;
            textBoxes[1] = tbx_prac_nazwisko;
            textBoxes[2] = tbx_prac_login;
            textBoxes[3] = tbx_prac_haslo;
            textBoxes[4] = tbx_prac_haslo2;
            helper.WyczyscFormatke(textBoxes);
            cbx_stanowisko.Text = "";
            lbxHaslo.Content = "Hasło:";
        }


        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            tbx_prac_haslo.Visibility = Visibility.Visible;
            tbx_prac_haslo2.Visibility = Visibility.Visible;
            lbxHaslo.Visibility = Visibility.Visible;
            lbxHaslo2.Visibility = Visibility.Visible;
            if (tbx_prac_haslo.Text.Length > 0)
            {
                tbx_prac_haslo.Text = "";
                tbx_prac_haslo2.Text = "";
                lbxHaslo.Content = "Podaj nowe hasło:";
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            tbx_prac_haslo.Visibility = Visibility.Hidden;
            tbx_prac_haslo2.Visibility = Visibility.Hidden;
            lbxHaslo.Visibility = Visibility.Hidden;
            lbxHaslo2.Visibility = Visibility.Hidden;
            lbxHaslo.Content = "Hasło:";
        }

        private void BtnPracownicyDodaj_Click(object sender, RoutedEventArgs e)
        {
            Helper helper = new Helper();
            string[] pracownik = new string[5];
            pracownik[0] = tbx_prac_imie.Text;
            pracownik[1] = tbx_prac_nazwisko.Text;
            pracownik[2] = tbx_prac_login.Text;
            pracownik[3] = tbx_prac_haslo.Text;
            pracownik[4] = cbx_stanowisko.SelectedValue.ToString();
            SQLconnection sQLconnection = new SQLconnection();
            sQLconnection.DodajPracownika(pracownik);
            sQLconnection.WyswietlPracownikow(dgv_pracownicy);

            TextBox[] textBoxes = new TextBox[5];
            textBoxes[0] = tbx_prac_imie;
            textBoxes[1] = tbx_prac_nazwisko;
            textBoxes[2] = tbx_prac_login;
            textBoxes[3] = tbx_prac_haslo;
            textBoxes[4] = tbx_prac_haslo2;
            helper.WyczyscFormatke(textBoxes);
            cbx_stanowisko.Text = "";
            lbxHaslo.Content = "Hasło:";

        }

        private void BtnPracownicyUsun_Click(object sender, RoutedEventArgs e)
        {

            Helper helper = new Helper();
            SQLconnection sql = new SQLconnection();
            sql.UsunPracownika(id_pracownika);
            sql.WyswietlPracownikow(dgv_pracownicy);
            TextBox[] textBoxes = new TextBox[5];
            textBoxes[0] = tbx_prac_imie;
            textBoxes[1] = tbx_prac_nazwisko;
            textBoxes[2] = tbx_prac_login;
            textBoxes[3] = tbx_prac_haslo;
            textBoxes[4] = tbx_prac_haslo2;
            helper.WyczyscFormatke(textBoxes);
            cbx_stanowisko.Text = "";
            lbxHaslo.Content = "Hasło:";


        }
        #endregion

        private void BtnPracownicyEdytuj_Click(object sender, RoutedEventArgs e)
        {
            Helper helper = new Helper();
            string[] pracownik = new string[5];
            pracownik[0] = tbx_prac_imie.Text;
            pracownik[1] = tbx_prac_nazwisko.Text;
            pracownik[2] = tbx_prac_login.Text;
            pracownik[3] = tbx_prac_haslo.Text;
            pracownik[4] = cbx_stanowisko.SelectedValue.ToString();
            SQLconnection sQLconnection = new SQLconnection();
            sQLconnection.EdytujPracownika(id_pracownika, pracownik);
            sQLconnection.WyswietlPracownikow(dgv_pracownicy);

            TextBox[] textBoxes = new TextBox[5];
            textBoxes[0] = tbx_prac_imie;
            textBoxes[1] = tbx_prac_nazwisko;
            textBoxes[2] = tbx_prac_login;
            textBoxes[3] = tbx_prac_haslo;
            textBoxes[4] = tbx_prac_haslo2;
            helper.WyczyscFormatke(textBoxes);
            cbx_stanowisko.Text = "";
            lbxHaslo.Content = "Hasło:";
        }

        private void TabItemPracownicy_Loaded(object sender, RoutedEventArgs e)
        {
            SQLconnection sQLconnection = new SQLconnection();
            sQLconnection.WyswietlPracownikow(dgv_pracownicy);
            sQLconnection.ZaladujStanowiskaDoCBX(cbx_stanowisko);
            tbx_prac_haslo.Visibility = Visibility.Hidden;
            tbx_prac_haslo2.Visibility = Visibility.Hidden;
            lbxHaslo.Visibility = Visibility.Hidden;
            lbxHaslo2.Visibility = Visibility.Hidden;
        }

        private void ShowPassword_Checked(object sender, RoutedEventArgs e)
        {
            TxtZmienDaneStareHasloTekst.Text = TxtZmienDaneStareHaslo.Password;
            TxtZmienDaneStareHaslo.Visibility = Visibility.Collapsed;
            TxtZmienDaneStareHasloTekst.Visibility = Visibility.Visible;

            TxtZamienDaneNoweHasloTekst.Text = TxtZamienDaneNoweHaslo.Password;
            TxtZamienDaneNoweHaslo.Visibility = Visibility.Collapsed;
            TxtZamienDaneNoweHasloTekst.Visibility = Visibility.Visible;

            TxtZmienDaneNoweHaslo2Tekst.Text = TxtZmienDaneNoweHaslo2.Password;
            TxtZmienDaneNoweHaslo2.Visibility = Visibility.Collapsed;
            TxtZmienDaneNoweHaslo2Tekst.Visibility = Visibility.Visible;
        }

        private void ShowPassword_Unchecked(object sender, RoutedEventArgs e)
        {
            TxtZmienDaneStareHaslo.Password = TxtZmienDaneStareHasloTekst.Text;
            TxtZmienDaneStareHasloTekst.Visibility = Visibility.Collapsed;
            TxtZmienDaneStareHaslo.Visibility = Visibility.Visible;

            TxtZamienDaneNoweHaslo.Password = TxtZamienDaneNoweHasloTekst.Text;
            TxtZamienDaneNoweHasloTekst.Visibility = Visibility.Collapsed;
            TxtZamienDaneNoweHaslo.Visibility = Visibility.Visible;

            TxtZmienDaneNoweHaslo2.Password = TxtZmienDaneNoweHaslo2Tekst.Text;
            TxtZmienDaneNoweHaslo2Tekst.Visibility = Visibility.Collapsed;
            TxtZmienDaneNoweHaslo2.Visibility = Visibility.Visible;
        }
    }
}
