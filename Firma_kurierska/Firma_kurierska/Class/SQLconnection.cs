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


        private const string conect = "datasource=sql11.freesqldatabase.com ; port=3306; username=sql11479040; password=TFWPBFQEvA; database=sql11479040";
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        public SQLconnection()
        {
            Initialize();
        }

        private void Initialize()
        {
            server = "sql11.freesqldatabase.com";
            database = "sql11479040";
            uid = "sql11479040";
            password = "TFWPBFQEvA";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }



        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {

                Console.WriteLine(ex);
                return false;
            }
        }

        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public int Sprawdz_uzytkownika(string login, string haslo)
        {
            MySqlCommand nowe = new MySqlCommand("SELECT PRC_id FROM sql11479040.Pracownicy WHERE PRC_login='" + login + "' AND PRC_haslo='" + haslo + "';", connection);
            MySqlDataReader dd;
            int id;
            OpenConnection();
            dd = nowe.ExecuteReader();
            if (dd.Read())
            {
                id = dd.GetInt32(0);
            }
            else
            {
                id = 0;
            }
            dd.Close();
            CloseConnection();
            return id;
        }


        public void WyswietlKlientow(System.Windows.Controls.DataGrid dataGrid)
        {
            MySqlConnection myconnection = new MySqlConnection(conect);
            MySqlCommand cmd = new MySqlCommand("SELECT KL_id , KL_imie , KL_nazwisko , ADR_miasto , ADR_ulica, ADR_nr_ulicy , ADR_nr_lok, KL_telefon , KL_email , KL_VIP FROM Klienci INNER JOIN Adres ON Klienci.KL_adres_id = Adres.ADR_id;", myconnection);      
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
        public void WyszukajKlienci(System.Windows.Controls.TextBox[] textBoxes, System.Windows.Controls.DataGrid dataGrid)
        {
            MySqlConnection myconnection = new MySqlConnection(conect);
            MySqlCommand cmd = new MySqlCommand("SELECT KL_id , KL_imie , KL_nazwisko , ADR_miasto , ADR_ulica, ADR_nr_ulicy , ADR_nr_lok, KL_telefon , KL_email , KL_VIP FROM Klienci INNER JOIN Adres ON Klienci.KL_adres_id = Adres.ADR_id where KL_imie like '%" + textBoxes[0].Text + "%' and KL_nazwisko like '%" + textBoxes[1].Text + "%' and ADR_miasto like '%" + textBoxes[2].Text + "%' and ADR_ulica like '%" + textBoxes[3].Text + "%' and ADR_nr_lok like '%" + textBoxes[4].Text + "%' and KL_telefon like '%" + textBoxes[5].Text + "%' and KL_email like '%" + textBoxes[6].Text + "%';", myconnection);

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
            cmd.Parameters.AddWithValue("@KlNazwisko", textBoxes[1].Text);
            cmd.Parameters.AddWithValue("@ADRMiasto", textBoxes[2].Text);
            cmd1.Parameters.AddWithValue("@ADRMiasto", textBoxes[2].Text);
            cmd.Parameters.AddWithValue("@ADRUlica", textBoxes[3].Text);
            cmd1.Parameters.AddWithValue("@ADRUlica", textBoxes[3].Text);
            cmd.Parameters.AddWithValue("@ADRNrUlica", textBoxes[4].Text);
            cmd1.Parameters.AddWithValue("@ADRNrUlica", textBoxes[4].Text);
            cmd.Parameters.AddWithValue("@ADRLokal", textBoxes[5].Text);
            cmd1.Parameters.AddWithValue("@ADRLokal", textBoxes[5].Text);
            cmd.Parameters.AddWithValue("@KlTelefon", textBoxes[6].Text);
            cmd.Parameters.AddWithValue("@KlEmail", textBoxes[7].Text);
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
   
    
    
    
        
    }



   
}
