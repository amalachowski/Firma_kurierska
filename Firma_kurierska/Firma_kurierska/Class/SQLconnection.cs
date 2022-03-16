using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Data;
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
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM sql11479040.Klienci;",myconnection);
            
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
    }
}
