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
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string login = txtLogin.Text;
            string password = txtPassword.Password;
            SQLconnection lacz = new SQLconnection();
            id_uzytkownika = lacz.Sprawdz_uzytkownika(login, password);
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

            WindowFirma windowFirma = new WindowFirma(id_uzytkownika);
            windowFirma.Show();
            this.Close();
        
        
        }
    }
}
