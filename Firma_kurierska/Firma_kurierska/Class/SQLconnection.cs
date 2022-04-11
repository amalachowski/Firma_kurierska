using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows;


namespace Firma_kurierska.Class
{
    class SQLconnection
    {
        private static int id_zamowienia;
        

        private const string conect = "datasource=sql11.freesqldatabase.com ; port=3306; username=sql11479040; password=TFWPBFQEvA; database=sql11479040";
        public int[] Sprawdz_uzytkownika(string login, string haslo)
        {
            int[] dane = new int[2];
            MySqlConnection myconnection = new MySqlConnection(conect);
            MySqlCommand nowe = new MySqlCommand("SELECT PRC_id ,PRC_STN_id  FROM sql11479040.Pracownicy WHERE PRC_login='" + login + "' AND PRC_haslo=md5('" + haslo + "');", myconnection);
            MySqlDataReader dd;
            int id;
            try
            {
                myconnection.Open();
                dd = nowe.ExecuteReader();
                if (dd.Read())
                {
                    dane[0] = dd.GetInt32(0);
                    dane[1] = dd.GetInt32(1);
                }
                else
                {
                    id = 0;
                }
                dd.Close();
                myconnection.Close();
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message);
            }
            return dane;
        }
        

        #region Klienci
        public void WyswietlKlientow(System.Windows.Controls.DataGrid dataGrid)
        {
            MySqlConnection myconnection = new MySqlConnection(conect);
            MySqlCommand cmd = new MySqlCommand("SELECT KL_id , KL_imie, ADR_id , KL_nazwisko , ADR_miasto , ADR_ulica, ADR_nr_ulicy , ADR_nr_lok, KL_telefon , KL_email ," +
                " KL_VIP FROM Klienci INNER JOIN Adres ON Klienci.KL_adres_id = Adres.ADR_id;", myconnection); 
            try
            {
                myconnection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter
                {
                    SelectCommand = cmd
                };
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                BindingSource zrodlo = new BindingSource();
                zrodlo.DataSource = dataTable;
                dataGrid.ItemsSource = zrodlo;
                myconnection.Close();

            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message);
            }
            dataGrid.Columns[0].Visibility = Visibility.Hidden;
        }
        public void WyszukajKlienci(System.Windows.Controls.TextBox[] textBoxes, System.Windows.Controls.DataGrid dataGrid)
        {
            MySqlConnection myconnection = new MySqlConnection(conect);
            MySqlCommand cmd = new MySqlCommand("SELECT KL_id , KL_imie, ADR_id , KL_nazwisko , ADR_miasto , ADR_ulica, ADR_nr_ulicy , ADR_nr_lok, KL_telefon , KL_email ," +
                " KL_VIP FROM Klienci INNER JOIN Adres ON Klienci.KL_adres_id = Adres.ADR_id where KL_imie like '%" + textBoxes[0].Text.ToString() + "%'" +
                " and KL_nazwisko like '%" + textBoxes[1].Text.ToString() + "%' and ADR_miasto like '%" + textBoxes[2].Text.ToString() + "%' and ADR_ulica like '%" + textBoxes[3].Text.ToString() + "%'" +
                "and ADR_nr_ulicy like '%" + textBoxes[4].Text + "%' and ADR_nr_lok like '%" + textBoxes[5].Text + "%' and KL_telefon like '%" + textBoxes[6].Text.ToString() + "%' and KL_email like '%" + textBoxes[7].Text.ToString() + "%';", myconnection);

            try
            {
                myconnection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                BindingSource zrodlo = new BindingSource();
                zrodlo.DataSource = dataTable;
                dataGrid.ItemsSource = zrodlo;
                myconnection.Close();

            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message);
            }
            dataGrid.Columns[0].Visibility = Visibility.Hidden;





        }

        public void DodajKlienci(System.Windows.Controls.TextBox[] textBoxes, System.Windows.Controls.CheckBox VIP)
        {


            MySqlConnection myconnection = new MySqlConnection(conect);
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlDataAdapter adapter1 = new MySqlDataAdapter();
            MySqlCommand cmd1 = new MySqlCommand("Insert into Adres set ADR_miasto=@ADRMiasto , ADR_ulica=@ADRUlica , ADR_nr_ulicy=@ADRNrUlica , ADR_nr_lok=@ADRLokal ");
            MySqlCommand cmd = new MySqlCommand("insert into Klienci set KL_imie=@klImie , KL_nazwisko=@KlNazwisko , KL_adres_id=(Select ADR_id from Adres where ADR_miasto=@ADRMiasto and ADR_ulica=@ADRUlica and ADR_nr_ulicy=@ADRNrUlica and ADR_nr_lok=@ADRLokal) , KL_telefon=@KlTelefon , KL_email=@KlEmail , KL_VIP=@KLVIP;");
            cmd.Parameters.AddWithValue("@KlImie",textBoxes[0].Text);
            
            cmd.Parameters.AddWithValue("@KlNazwisko", textBoxes[1].Text.ToString());
            cmd.Parameters.AddWithValue("@ADRMiasto", textBoxes[2].Text.ToString());
            cmd1.Parameters.AddWithValue("@ADRMiasto", textBoxes[2].Text.ToString());
            cmd.Parameters.AddWithValue("@ADRUlica", textBoxes[3].Text.ToString());
            cmd1.Parameters.AddWithValue("@ADRUlica", textBoxes[3].Text.ToString());
            cmd.Parameters.AddWithValue("@ADRNrUlica", textBoxes[4].Text.ToString());
            cmd1.Parameters.AddWithValue("@ADRNrUlica", textBoxes[4].Text.ToString());
            cmd.Parameters.AddWithValue("@ADRLokal", textBoxes[5].Text.ToString());
            cmd1.Parameters.AddWithValue("@ADRLokal", textBoxes[5].Text.ToString());
            cmd.Parameters.AddWithValue("@KlTelefon", textBoxes[6].Text.ToString());
            cmd.Parameters.AddWithValue("@KlEmail", textBoxes[7].Text.ToString());
            cmd.Parameters.AddWithValue("@KLVIP", (bool)VIP.IsChecked? 1 : 0);

            try
            {
                myconnection.Open();
                adapter.InsertCommand = cmd1;
                adapter1.InsertCommand = cmd;
                adapter.InsertCommand.Connection = myconnection;
                adapter1.InsertCommand.Connection = myconnection;
                adapter.InsertCommand.ExecuteNonQuery();
                adapter1.InsertCommand.ExecuteNonQuery();
                myconnection.Close();
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message);
            }

        }

        public void UsunKlienci(int id_rekordAdres,int id_rekordKlient)
        {

            MySqlConnection myconnection = new MySqlConnection(conect);
            MySqlCommand zapytanie = myconnection.CreateCommand();
            MySqlTransaction transaction;

            myconnection.Open();
            transaction = myconnection.BeginTransaction(IsolationLevel.ReadCommitted);
            zapytanie.Connection = myconnection;
            zapytanie.Transaction = transaction;
            

            try
            {

                
                zapytanie.CommandText = "Delete from Klienci where KL_id=" + id_rekordKlient + ";";
                zapytanie.ExecuteNonQuery();
                zapytanie.CommandText = "Delete from Adres where ADR_id=" + id_rekordAdres + "; ";
                zapytanie.ExecuteNonQuery();

                transaction.Commit();


            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                transaction.Rollback();
            }
            myconnection.Close();


        }

        public void EdytujKlienci(int id_rekordKlienci,int id_rekordAdress, System.Windows.Controls.TextBox[] textBoxes, System.Windows.Controls.CheckBox VIP) 
        {
            MySqlConnection myconnection = new MySqlConnection(conect);
            MySqlCommand cmd = myconnection.CreateCommand();
            MySqlTransaction transaction;   
            cmd.Parameters.AddWithValue("@KlImie", textBoxes[0].Text);
            cmd.Parameters.AddWithValue("@KlNazwisko", textBoxes[1].Text.ToString());
            cmd.Parameters.AddWithValue("@ADRMiasto", textBoxes[2].Text.ToString());
            cmd.Parameters.AddWithValue("@ADRUlica", textBoxes[3].Text.ToString());
            cmd.Parameters.AddWithValue("@ADRNrUlica", textBoxes[4].Text.ToString());            
            cmd.Parameters.AddWithValue("@ADRLokal", textBoxes[5].Text.ToString());           
            cmd.Parameters.AddWithValue("@KlTelefon", textBoxes[6].Text.ToString());
            cmd.Parameters.AddWithValue("@KlEmail", textBoxes[7].Text.ToString());
            cmd.Parameters.AddWithValue("@KLVIP", (bool)VIP.IsChecked ? 1 : 0);

            myconnection.Open();
            transaction = myconnection.BeginTransaction(IsolationLevel.ReadCommitted);
            cmd.Connection = myconnection;
            cmd.Transaction = transaction;
            try
            {
                
                cmd.CommandText = "Update Adres set ADR_miasto=@ADRMiasto , ADR_ulica=@ADRUlica , ADR_nr_ulicy=@ADRNrUlica , ADR_nr_lok=@ADRLokal where ADR_id='"+id_rekordAdress+"'; ";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "Update Klienci set KL_imie=@klImie , KL_nazwisko=@KlNazwisko , KL_telefon=@KlTelefon , KL_email=@KlEmail , KL_VIP=@KLVIP where KL_id='"+id_rekordKlienci+"';";
                cmd.ExecuteNonQuery();
                
                transaction.Commit();
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message);
                transaction.Rollback();
            }
            myconnection.Close();



        }

        #endregion

        #region Kurierzy


        public void WyswietlKuerierow(System.Windows.Controls.DataGrid dataGrid) 
        {
            MySqlConnection myconnection = new MySqlConnection(conect);
            MySqlCommand cmd = new MySqlCommand("SELECT KR_id , KR_imie, KR_nazwisko, KR_telefon , KR_miasto" +
                " FROM Kurier ;", myconnection);
            try
            {
                myconnection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                BindingSource zrodlo = new BindingSource();
                zrodlo.DataSource = dataTable;
                dataGrid.ItemsSource = zrodlo;
                myconnection.Close();

            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message);
            }
            dataGrid.Columns[0].Visibility = Visibility.Hidden;



        }


        public void WyszukajKurierow(System.Windows.Controls.TextBox[] textBoxes, System.Windows.Controls.DataGrid dataGrid) 
        {
            MySqlConnection myconnection = new MySqlConnection(conect);
            MySqlCommand cmd = new MySqlCommand("Select KR_id, KR_imie, KR_nazwisko, KR_miasto, KR_telefon from Kurier where KR_imie like '%"+textBoxes[0].Text+ "%' and KR_nazwisko like '%" + textBoxes[1].Text + "%' and KR_miasto like '%" + textBoxes[2].Text + "%' and KR_telefon like '%" + textBoxes[3].Text + "%';", myconnection);

            try
            {
                myconnection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                BindingSource zrodlo = new BindingSource();
                zrodlo.DataSource = dataTable;
                dataGrid.ItemsSource = zrodlo;
                myconnection.Close();

            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message);
            }
            dataGrid.Columns[0].Visibility = Visibility.Hidden;

        }


        public void DodajKurierow(System.Windows.Controls.TextBox[] textBoxes) 
        {

            MySqlConnection myconnection = new MySqlConnection(conect);
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            
            
            MySqlCommand cmd = new MySqlCommand("insert into Kurier set KR_imie=@KRImie , KR_nazwisko=@KRNazwisko,KR_miasto=@KRMiasto ,KR_telefon=@KRTelefon ;");
            cmd.Parameters.AddWithValue("@KRImie", textBoxes[0].Text);
            cmd.Parameters.AddWithValue("@KRNazwisko", textBoxes[1].Text.ToString());
            cmd.Parameters.AddWithValue("@KRMiasto", textBoxes[2].Text.ToString());
            cmd.Parameters.AddWithValue("@KRTelefon", textBoxes[3].Text.ToString());
            
            

            try
            {
                myconnection.Open();
                
                adapter.InsertCommand = cmd;
                adapter.InsertCommand.Connection = myconnection;
                
                adapter.InsertCommand.ExecuteNonQuery();



                
                
                myconnection.Close();
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message);
            }
        }

        public void UsunKuriera(int idKuriera) 
        {
            MySqlConnection myconnection = new MySqlConnection(conect);
            MySqlCommand zapytanie = myconnection.CreateCommand();
            MySqlTransaction transaction;

            myconnection.Open();
                
                
                
            transaction = myconnection.BeginTransaction(IsolationLevel.ReadCommitted);
            zapytanie.Transaction = transaction;
            zapytanie.Connection = myconnection;
            try
            {
                
                zapytanie.CommandText = "Delete from Kurier where KR_id=" + idKuriera + ";";
                zapytanie.ExecuteNonQuery();
                

                transaction.Commit();


            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                transaction.Rollback();
            }
            myconnection.Close();


        }

        public void EdytujKuriera(System.Windows.Controls.TextBox[] textBoxes, int idKuriera) 
        {
            MySqlConnection myconnection = new MySqlConnection(conect);
            MySqlCommand cmd = myconnection.CreateCommand();
            MySqlTransaction transaction;
            cmd.Parameters.AddWithValue("@KRImie", textBoxes[0].Text);
            cmd.Parameters.AddWithValue("@KRNazwisko", textBoxes[1].Text.ToString());
            cmd.Parameters.AddWithValue("@KRMiasto", textBoxes[2].Text.ToString());
            cmd.Parameters.AddWithValue("@KRTelefon", textBoxes[3].Text.ToString());
            
            

            myconnection.Open();
            transaction = myconnection.BeginTransaction(IsolationLevel.ReadCommitted);
            cmd.Connection = myconnection;
            cmd.Transaction = transaction;
            try
            {

                cmd.CommandText = "Update Kurier set KR_imie=@KRImie, KR_nazwisko=@KRNazwisko, KR_miasto=@KRMiasto,KR_telefon=@KRTelefon where KR_id='" + idKuriera + "'; ";
                cmd.ExecuteNonQuery();
                

                transaction.Commit();
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message);
                transaction.Rollback();
            }
            myconnection.Close();
        }

        #endregion

        #region ZmianaHasla

        public bool SprawdzPoprzednieHaslo(string stareHaslo, int id_pracownika)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(conect);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Parameters.AddWithValue("@stareHaslo",stareHaslo);
            cmd.Parameters.AddWithValue("@id_pracownika", id_pracownika);
            cmd.CommandText = "Select * from Pracownicy where PRC_id=@id_pracownika and PRC_haslo=@stareHaslo;  ";
            cmd.Connection = mySqlConnection;
            mySqlConnection.Open();
            try
            {
                
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    
                    return true;
                }
                else 
                {
                    
                    return false;
                } 
            }
            catch (Exception ex) 
            {
                System.Windows.MessageBox.Show(ex.Message);
                
            }
            mySqlConnection.Close();
            return false;
            
        }

        public void ZmienHasloUzytkownika(string haslo, int id_pracownika)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(conect) ;
            MySqlCommand cmd = new MySqlCommand();
            string noweHaslo = Szyfruj(haslo);
            cmd.Parameters.AddWithValue("@noweHaslo", noweHaslo);
            cmd.Parameters.AddWithValue("@id_pracownika", id_pracownika);
            cmd.CommandText = "Update Pracownicy set PRC_haslo=@noweHaslo where PRC_id=@id_pracownika;";
            mySqlConnection.Open();
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.UpdateCommand = cmd;
                adapter.UpdateCommand.Connection = mySqlConnection;
                cmd.ExecuteNonQuery();

                
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);

            }
            mySqlConnection.Close();

        }

        public string Szyfruj(string haslo)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(conect);
            MySqlCommand szyfr = new MySqlCommand("select md5('" + haslo + "');", mySqlConnection);
            MySqlDataReader dr;

            string szyfrowaneHaslo = "";
            mySqlConnection.Open();
            try
            {
                dr = szyfr.ExecuteReader();
            if (dr.Read())
            {
                szyfrowaneHaslo = dr["md5('" + haslo + "')"].ToString();

            }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);

            }
            mySqlConnection.Close();
            return szyfrowaneHaslo;

        }
        public bool sprawdz_login(string login)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(conect);
            MySqlCommand nowe = new MySqlCommand("SELECT Count(PRC_id) FROM Pracownicy WHERE PRC_login='" + login + "';", mySqlConnection);
            MySqlDataReader dr;

            mySqlConnection.Open();
            dr = nowe.ExecuteReader();

            if (dr.Read())
            {
                int check = dr.GetInt32(0);

                if (check == 0)
                {
                    mySqlConnection.Close();
                    return true;
                }
                else
                {
                    mySqlConnection.Close();
                    return false;
                }

            }
            else
            {
                mySqlConnection.Close();
                return false;

            }



        }



        #endregion

        #region Zamowinie

        public void WyszukajNadawca(System.Windows.Controls.TextBox textBox, System.Windows.Controls.DataGrid dataGrid) 
        {
            MySqlConnection myconnection = new MySqlConnection(conect);
            MySqlCommand cmd = new MySqlCommand("SELECT KL_id , KL_imie, ADR_id , KL_nazwisko , ADR_miasto , ADR_ulica, ADR_nr_ulicy , ADR_nr_lok, KL_telefon , KL_email ," +
                " KL_VIP FROM Klienci INNER JOIN Adres ON Klienci.KL_adres_id = Adres.ADR_id where CONCAT(KL_imie, ' ',KL_nazwisko ) LIKE '%" + textBox.Text + "%' ORDER BY KL_nazwisko , KL_imie ;", myconnection);

            try
            {
                myconnection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                BindingSource zrodlo = new BindingSource();
                zrodlo.DataSource = dataTable;
                dataGrid.ItemsSource = zrodlo;
                myconnection.Close();


            }
            catch (Exception e) 
            {

                System.Windows.MessageBox.Show(e.Message);
            
            }
            
            
            
            dataGrid.Columns[0].Visibility = Visibility.Hidden;

        }


        public void DodajZamowienie(int id_Nadawcy) 
        {
            MySqlConnection myconnection = new MySqlConnection(conect);
            MySqlDataAdapter adapter = new MySqlDataAdapter();


            MySqlCommand cmd = new MySqlCommand("insert into Zamówienie set ZAM_klient_id=@Klid , ZAM_status='W trakcie realizacji' ;",myconnection);
            cmd.Parameters.AddWithValue("@KLid", id_Nadawcy);
            MySqlDataReader dd;
            MySqlCommand cmd1 = new MySqlCommand("Select last_insert_id() from Zamówienie ;",myconnection);
           





            
            try
            {
                myconnection.Open();
                
                adapter.InsertCommand = cmd;
                adapter.InsertCommand.Connection = myconnection;

                adapter.InsertCommand.ExecuteNonQuery();
                dd = cmd1.ExecuteReader();
                if (dd.Read())
                {
                    id_zamowienia = dd.GetInt32(0);
                }
                

                myconnection.Close();
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message);
            }


            
        }

        public void DodajPaczki(int iloscPaczek, int idNadawcy) 
        {
            MySqlConnection myconnection = new MySqlConnection(conect);
            MySqlDataAdapter adapter = new MySqlDataAdapter();


            MySqlCommand cmd = new MySqlCommand("insert into Paczka set PCK_zamowienie_id=@id_zamowienia, PCK_adr_nadawcy_id=(SELECT KL_adres_id FROM sql11479040.Klienci where KL_id = @idKl);", myconnection);

            cmd.Parameters.AddWithValue("@id_zamowienia" ,id_zamowienia);
            cmd.Parameters.AddWithValue("@idKl", idNadawcy);

            for (int i=0; i<iloscPaczek; i++)
            {
                try
                {
                    myconnection.Open();

                    adapter.InsertCommand = cmd;
                    adapter.InsertCommand.Connection = myconnection;

                    adapter.InsertCommand.ExecuteNonQuery();

                    myconnection.Close();
                }
                catch (Exception e)
                {
                    System.Windows.MessageBox.Show(e.Message);
                    break;
                }

            }

        }


        public void WyswietlZamowienia(System.Windows.Controls.DataGrid dataGrid) 
        {
            MySqlConnection myconnection = new MySqlConnection(conect);
            MySqlCommand cmd = new MySqlCommand("SELECT ZAM_id , ZAM_status, ZAM_klient_id, ZAM_znizka, ZAM_wartoscKoncowa FROM Zamówienie ;", myconnection);
            try
            {
                myconnection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                BindingSource zrodlo = new BindingSource();
                zrodlo.DataSource = dataTable;
                dataGrid.ItemsSource = zrodlo;
                myconnection.Close();

            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message);
            }

        }
        public void UaktualnijZamowienie() 
        {
            MySqlConnection myconnection = new MySqlConnection(conect);
            MySqlCommand zapytanie = myconnection.CreateCommand();
            MySqlTransaction transaction;

            myconnection.Open();



            transaction = myconnection.BeginTransaction(IsolationLevel.ReadCommitted);
            zapytanie.Transaction = transaction;
            zapytanie.Connection = myconnection;
            try
            {

                zapytanie.CommandText = "Update Zamówienie set ZAM_wartoscKoncowa=(Select sum(RPCK_cena) from Paczka inner join RodzajPaczki on PCK_rodzaj_id=RPCK_id where PCK_zamowienie_id = '"+id_zamowienia+"') where ZAM_id='"+id_zamowienia+"' ;";
                zapytanie.ExecuteNonQuery();


                transaction.Commit();


            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                transaction.Rollback();
            }
            myconnection.Close();




        }

        public void NadawanieVIPKlientomZPromocji(int idKlienta) 
        {
            MySqlConnection myconnection = new MySqlConnection(conect);
            MySqlCommand zapytanie = myconnection.CreateCommand();
            MySqlTransaction transaction;

            myconnection.Open();



            transaction = myconnection.BeginTransaction(IsolationLevel.ReadCommitted);
            zapytanie.Transaction = transaction;
            zapytanie.Connection = myconnection;
            try
            {

                zapytanie.CommandText = "Update Klienci set KL_VIP='1' where KL_id='"+idKlienta+"' ;";
                zapytanie.ExecuteNonQuery();


                transaction.Commit();


            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                transaction.Rollback();
            }
            myconnection.Close();



        }

        public void WyswietlPaczki(System.Windows.Controls.DataGrid dataGrid) 
        {

            MySqlConnection myconnection = new MySqlConnection(conect);
            MySqlCommand cmd = new MySqlCommand("SELECT PCK_id , RPCK_wielkosc, PCK_zamowienie_id, ADR_miasto , ADR_ulica , RPCK_cena "+
                "FROM Paczka"+
                " left join Adres on Paczka.PCK_adr_id = Adres.ADR_id"+
                " left join RodzajPaczki on  Paczka.PCK_rodzaj_id = RodzajPaczki.RPCK_id where PCK_zamowienie_id ='"+id_zamowienia+"' ; ", myconnection);

            try 
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                
                DataTable dataTable = new DataTable();
                BindingSource zrodlo = new BindingSource();

                    myconnection.Open();
                    adapter.SelectCommand = cmd;
                    adapter.Fill(dataTable);
                    zrodlo.DataSource = dataTable;
                    dataGrid.ItemsSource = zrodlo;
                    
                     myconnection.Close();

            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message);
            }


        }
        public void WyswietlPaczki(System.Windows.Controls.DataGrid dataGrid,int id_zamowienia)
        {

            MySqlConnection myconnection = new MySqlConnection(conect);
            MySqlCommand cmd = new MySqlCommand("SELECT PCK_id , RPCK_wielkosc, PCK_zamowienie_id, ADR_miasto , ADR_ulica , RPCK_cena " +
                "FROM Paczka" +
                " left join Adres on Paczka.PCK_adr_id = Adres.ADR_id" +
                " left join RodzajPaczki on  Paczka.PCK_rodzaj_id = RodzajPaczki.RPCK_id where PCK_zamowienie_id ='" + id_zamowienia + "' ; ", myconnection);

            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter();

                DataTable dataTable = new DataTable();
                BindingSource zrodlo = new BindingSource();

                myconnection.Open();
                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);
                zrodlo.DataSource = dataTable;
                dataGrid.ItemsSource = zrodlo;

                myconnection.Close();

            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message);
            }


        }
        public void WyswietlDane(System.Windows.Controls.TextBlock textblock, int id_zamowienia)
        {
            MySqlConnection myconnection = new MySqlConnection(conect);
            MySqlCommand cmd = new MySqlCommand("SELECT concat( KL_imie,' ', KL_nazwisko,', ', ADR_miasto,' ul. ', ADR_ulica,' ', ADR_nr_ulicy,' m.', ADR_nr_lok) as dane from Klienci inner join Adres on KL_adres_id=ADR_id where KL_id=(SELECT ZAM_klient_id FROM Zamówienie where ZAM_id=@zamID);", myconnection);
            try
            {
                myconnection.Open();
                cmd.Parameters.AddWithValue("@zamID", id_zamowienia);
                MySqlDataReader da = cmd.ExecuteReader();
                while(da.Read())
                {
                    textblock.Text = da.GetValue(0).ToString();
                }

                myconnection.Close();

            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message);
            }

        }
        public void WypLnijstatusZamowienia(System.Windows.Controls.ComboBox comboBox) 
        {
            MySqlConnection myconnection = new MySqlConnection(conect);
            MySqlCommand cmd = new MySqlCommand("Select * from RodzajPaczki ;", myconnection);
            try
            {
                myconnection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                BindingSource zrodlo = new BindingSource();
                zrodlo.DataSource = dataTable;
                comboBox.ItemsSource = zrodlo;
                myconnection.Close();
            }
            catch (Exception e) 
            {
                System.Windows.MessageBox.Show(e.Message);
            }

        }

        public int SprawdzAdres(string miasto, string ulica, string nrUlicy, string lokal)
        {
            int idAdr = 0;
            
            MySqlConnection myconnection = new MySqlConnection(conect);
            MySqlCommand nowe = new MySqlCommand("Select ADR_id from Adres where ADR_miasto = '" + miasto + "' AND ADR_ulica = '" + ulica + "' AND ADR_nr_ulicy='" + nrUlicy + "' AND ADR_nr_lok='" + lokal + "';", myconnection);
            MySqlDataReader dd;

            try
            {
                myconnection.Open();
                dd = nowe.ExecuteReader();
                if (dd.Read())
                {
                    idAdr = dd.GetInt32(0);

                }
                else
                {
                    idAdr = 0;
                }
                dd.Close();
                myconnection.Close();
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message);
            }
            return idAdr;
        }

        public void UaktualinijPaczki(string miasto, string ulica, string nrUlicy,string lokal, int id_kuriera,int id_paczki,int id_statusu) 
        {
            MySqlConnection myconnection = new MySqlConnection(conect);
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand cmd;
            if (SprawdzAdres(miasto, ulica, nrUlicy, lokal) == 0)
            {
                MySqlCommand cmd1 = new MySqlCommand("Insert into Adres set ADR_miasto=@ADRMiasto , ADR_ulica=@ADRUlica , ADR_nr_ulicy=@ADRNrUlica , ADR_nr_lok=@ADRLokal ");
                cmd1.Parameters.AddWithValue("@ADRMiasto", miasto);
                cmd1.Parameters.AddWithValue("@ADRUlica", ulica);
                cmd1.Parameters.AddWithValue("@ADRNrUlica", nrUlicy);
                cmd1.Parameters.AddWithValue("@ADRLokal", lokal);
                try
                {
                    myconnection.Open();
                    adapter.InsertCommand = cmd1;
                    adapter.InsertCommand.Connection = myconnection;
                    adapter.InsertCommand.ExecuteNonQuery();
                    myconnection.Close();
                }
                catch (Exception e)
                {
                    System.Windows.MessageBox.Show(e.Message);
                }
            }
            
                int idADR = SprawdzAdres(miasto, ulica, nrUlicy, lokal);
                cmd = new MySqlCommand("Update Paczka set  PCK_rodzaj_id=@PCK_rodzaj, PCK_adr_id=@PCK_adr_id , PCK_kurier_id=@PCK_kurier_id  where PCK_id=@id;");
                cmd.Parameters.AddWithValue("@PCK_adr_id", idADR);
                cmd.Parameters.AddWithValue("@PCK_rodzaj", id_statusu);
                cmd.Parameters.AddWithValue("@PCK_kurier_id", id_kuriera);
                cmd.Parameters.AddWithValue("@id", id_paczki);




                try
                {
                    myconnection.Open();
                    adapter.InsertCommand = cmd;
                    adapter.InsertCommand.Connection = myconnection;
                    adapter.InsertCommand.ExecuteNonQuery();
                    myconnection.Close();
                }
                catch (Exception e)
                {
                    System.Windows.MessageBox.Show(e.Message);
                }
            




        }
        public void UsunPaczke(int id_paczki) 
        {
            MySqlConnection myconnection = new MySqlConnection(conect);
            MySqlCommand zapytanie = myconnection.CreateCommand();
            MySqlTransaction transaction;

            myconnection.Open();



            transaction = myconnection.BeginTransaction(IsolationLevel.ReadCommitted);
            zapytanie.Transaction = transaction;
            zapytanie.Connection = myconnection;
            try
            {

                zapytanie.CommandText = "Delete from Paczka where PCK_id=" + id_paczki + " and PCK_zamowienie_id='"+id_zamowienia+"' ;";
                zapytanie.ExecuteNonQuery();


                transaction.Commit();


            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                transaction.Rollback();
            }
            myconnection.Close();



        }


        public void DodawanieZnizki(System.Windows.Controls.ComboBox comboBoxZnizka, int id_WybranegoZamowienia) 
        {
            MySqlConnection myconnection = new MySqlConnection(conect);
            MySqlCommand zapytanie = myconnection.CreateCommand();
            MySqlTransaction transaction;

            myconnection.Open();



            transaction = myconnection.BeginTransaction(IsolationLevel.ReadCommitted);
            zapytanie.Transaction = transaction;
            zapytanie.Connection = myconnection;
            try
            {

                zapytanie.CommandText = "Update Zamówienie set  ZAM_znizka='"+ comboBoxZnizka.SelectedItem + "', ZAM_wartoscKoncowa=ZAM_wartoscKoncowa - (ZAM_wartoscKoncowa * (" + comboBoxZnizka.SelectedItem+"/100)) where ZAM_id='" +id_WybranegoZamowienia +"'  ;";
                zapytanie.ExecuteNonQuery();


                transaction.Commit();


            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                transaction.Rollback();
            }
            myconnection.Close();



        }

        public void DodawnieStatusu(System.Windows.Controls.ComboBox comboBoxStatus, int id_WybranegoZamowienia) 
        {
            MySqlConnection myconnection = new MySqlConnection(conect);
            MySqlCommand zapytanie = myconnection.CreateCommand();
            MySqlTransaction transaction;

            myconnection.Open();



            transaction = myconnection.BeginTransaction(IsolationLevel.ReadCommitted);
            zapytanie.Transaction = transaction;
            zapytanie.Connection = myconnection;
            try
            {

                zapytanie.CommandText = "Update Zamówienie set ZAM_status='"+comboBoxStatus.SelectedItem+"'  where ZAM_id='" + id_WybranegoZamowienia + "'  ;";
                zapytanie.ExecuteNonQuery();


                transaction.Commit();


            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                transaction.Rollback();
            }
            myconnection.Close();

        }

        public void UsunZamowienie(int idWybranegoZamowienia) 
        {
            MySqlConnection myconnection = new MySqlConnection(conect);
            MySqlCommand zapytanie = myconnection.CreateCommand();
            MySqlTransaction transaction;

            myconnection.Open();



            transaction = myconnection.BeginTransaction(IsolationLevel.ReadCommitted);
            zapytanie.Transaction = transaction;
            zapytanie.Connection = myconnection;
            try
            {
                zapytanie.CommandText = "Delete from Paczka where PCK_zamowienie_id='" + idWybranegoZamowienia + "';";
                zapytanie.ExecuteNonQuery();

                zapytanie.CommandText = "Delete from Zamówienie where ZAM_id='" + idWybranegoZamowienia + "';";
                zapytanie.ExecuteNonQuery();


                transaction.Commit();


            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                transaction.Rollback();
            }
            myconnection.Close();


        }

        public bool SprawdzStatusKlienta(int idWybranegoZamowienia) 
        {
            MySqlConnection mySqlConnection = new MySqlConnection(conect);
            MySqlDataReader dd;
            MySqlCommand cmd = new MySqlCommand("Select KL_VIP from Klienci inner join Zamówienie on KL_id=ZAM_klient_id where Zamówienie.ZAM_id='"+idWybranegoZamowienia+"'; ",mySqlConnection);
            try
            {
                mySqlConnection.Open();
                dd = cmd.ExecuteReader();
                if (dd.Read())
                {

                    return Convert.ToBoolean(dd.GetInt32(0));


                }
                mySqlConnection.Close();
            }
            catch (Exception e) 
            {
                System.Windows.MessageBox.Show(e.Message);
            
            }
            return false;
        
        
        }


    #endregion
        #region Pracownicy
        public void WyswietlPracownikow(System.Windows.Controls.DataGrid dataGrid)
        {
            MySqlConnection myconnection = new MySqlConnection(conect);

            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT PRC_id, PRC_imie, PRC_nazwisko, PRC_login, STN_stanowisko, PRC_haslo FROM Pracownicy INNER JOIN Stanowisko ON PRC_STN_id = STN_id;", myconnection);
                DataTable dt = new DataTable();
                myconnection.Open();
                MySqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                myconnection.Close();
                dataGrid.ItemsSource = dt.DefaultView;

            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message);
            }

        }
        public void WyszukajPracownicy(string[] dane, System.Windows.Controls.DataGrid dataGrid)
        {
            if (dane is null)
            {
                throw new ArgumentNullException(nameof(dane));
            }

            if (dataGrid is null)
            {
                throw new ArgumentNullException(nameof(dataGrid));
            }

            MySqlConnection myconnection = new MySqlConnection(conect);
            MySqlCommand cmd = new MySqlCommand("SELECT PRC_id, PRC_imie, PRC_nazwisko, PRC_login, STN_stanowisko, PRC_haslo  FROM Pracownicy INNER JOIN Stanowisko ON PRC_STN_id = STN_id where PRC_imie like '%" + dane[0] + "%' and PRC_nazwisko like '%" + dane[1] + "%' and PRC_login like '%" + dane[2] + "%' and STN_stanowisko like '%" + dane[3] + "%';", myconnection);

            try
            {
                myconnection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                BindingSource zrodlo = new BindingSource();
                zrodlo.DataSource = dataTable;
                dataGrid.ItemsSource = zrodlo;
                myconnection.Close();

            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message);
            }



        }
        public void DodajPracownika(string[] dane)
        {


            MySqlConnection myconnection = new MySqlConnection(conect);
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand("insert into Pracownicy set PRC_imie=@PRC_imie , PRC_nazwisko=@PRC_nazwisko , PRC_login=@PRC_login , PRC_STN_id=@PRC_stanowisko , PRC_haslo=@PRC_haslo;");
            cmd.Parameters.AddWithValue("@PRC_imie", dane[0]);
            cmd.Parameters.AddWithValue("@PRC_nazwisko", dane[1]);
            cmd.Parameters.AddWithValue("@PRC_login", dane[2]);
            cmd.Parameters.AddWithValue("@PRC_haslo", dane[3]);
            cmd.Parameters.AddWithValue("@PRC_stanowisko", dane[4]);


            try
            {
                myconnection.Open();
                adapter.InsertCommand = cmd;
                adapter.InsertCommand.Connection = myconnection;
                adapter.InsertCommand.ExecuteNonQuery();
                myconnection.Close();
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message);
            }

        }
        public void ZaladujStanowiskaDoCBX(System.Windows.Controls.ComboBox comboBox)
        {
            MySqlConnection myconnection = new MySqlConnection(conect);
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM Stanowisko", myconnection);
            try
            {
                myconnection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                BindingSource zrodlo = new BindingSource();
                zrodlo.DataSource = dataTable;
                comboBox.ItemsSource = zrodlo;
                myconnection.Close();

            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message);
            }

        }

        public void UsunPracownika(int id_pracownika)
        {

            MySqlConnection myconnection = new MySqlConnection(conect);
            MySqlCommand zapytanie = myconnection.CreateCommand();
            MySqlTransaction transaction;

            myconnection.Open();
            transaction = myconnection.BeginTransaction(IsolationLevel.ReadCommitted);
            zapytanie.Connection = myconnection;
            zapytanie.Transaction = transaction;

            try
            {

                zapytanie.CommandText = "Delete from Pracownicy where PRC_id=" + id_pracownika + "; ";
                zapytanie.ExecuteNonQuery();
                transaction.Commit();


            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                transaction.Rollback();
            }
            myconnection.Close();


        }

        public void EdytujPracownika(int id_pracownika, string[] dane)
        {
            Helper helper = new Helper();
            MySqlConnection myconnection = new MySqlConnection(conect);
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand("Update Pracownicy set PRC_imie=@PRC_imie , PRC_nazwisko=@PRC_nazwisko , PRC_login=@PRC_login , PRC_STN_id=@PRC_stanowisko , PRC_haslo=@PRC_haslo where PRC_id=@id;");
            cmd.Parameters.AddWithValue("@PRC_imie", dane[0]);
            cmd.Parameters.AddWithValue("@PRC_nazwisko", dane[1]);
            cmd.Parameters.AddWithValue("@PRC_login", dane[2]);
            cmd.Parameters.AddWithValue("@PRC_haslo", Szyfruj(dane[3]));
            cmd.Parameters.AddWithValue("@PRC_stanowisko", dane[4]);
            cmd.Parameters.AddWithValue("@id", id_pracownika);


            try
            {
                myconnection.Open();
                adapter.InsertCommand = cmd;
                adapter.InsertCommand.Connection = myconnection;
                adapter.InsertCommand.ExecuteNonQuery();
                myconnection.Close();
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message);
            }
        }
        public void EdytujPracownikaBezHasla(int id_pracownika, string[] dane)
        {
            Helper helper = new Helper();
            MySqlConnection myconnection = new MySqlConnection(conect);
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand("Update Pracownicy set PRC_imie=@PRC_imie , PRC_nazwisko=@PRC_nazwisko , PRC_login=@PRC_login , PRC_STN_id=@PRC_stanowisko where PRC_id=@id;");
            cmd.Parameters.AddWithValue("@PRC_imie", dane[0]);
            cmd.Parameters.AddWithValue("@PRC_nazwisko", dane[1]);
            cmd.Parameters.AddWithValue("@PRC_login", dane[2]);
            cmd.Parameters.AddWithValue("@PRC_stanowisko", dane[4]);
            cmd.Parameters.AddWithValue("@id", id_pracownika);


            try
            {
                myconnection.Open();
                adapter.InsertCommand = cmd;
                adapter.InsertCommand.Connection = myconnection;
                adapter.InsertCommand.ExecuteNonQuery();
                myconnection.Close();
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message);
            }
        }

        #endregion

    }




}
