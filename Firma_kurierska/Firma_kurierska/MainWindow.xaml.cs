using Firma_kurierska.Class;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Firma_kurierska
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int id_uzytkownika;
        int[] daneUzytkowinka;
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string login = txtLogin.Text;
            string password = txtPassword.Password;
            SQLconnection lacz = new SQLconnection();
            daneUzytkowinka = lacz.Sprawdz_uzytkownika(login, password);
            id_uzytkownika = daneUzytkowinka[0];
            if (id_uzytkownika == 0)
            {
                MessageBox.Show("Błąd danych");

            }
            else
            {
                OpenApplication();
            }






        }




        public void OpenApplication() 
        {

            WindowFirma windowFirma = new WindowFirma(daneUzytkowinka[0],daneUzytkowinka[1]);
            windowFirma.Show();
            this.Close();
        
        
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
