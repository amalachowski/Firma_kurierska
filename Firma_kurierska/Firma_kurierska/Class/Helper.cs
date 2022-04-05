using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Firma_kurierska.Class
{
    class Helper
    {
        

        public Boolean WalidacjaKlienciDodawanie(TextBox[] TxtlistaKlienci ) 
        {
            foreach (var item in TxtlistaKlienci) 
            {
                if (item.Text.Equals("") || item.Text.Length < 3)
                {
                    return false;



                }
                else 
                {
                    continue;
                }
            
            }

            return true;
        }
        public void WyczyscFormatke(System.Windows.Controls.TextBox[] textBoxes) 
        {
            foreach (var item in textBoxes) 
            {
                item.Text = "";
            }
        }

        public bool PoprawnoscHaslaStaregoINowego(string nowe1, string nowe2) 
        {
            if (nowe1.Equals(nowe2))
            {

                return true;
            }
            else
            {
                MessageBox.Show("Hasla nie sa takie same");
                return false;
            }
        }

    }
}
