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
        public bool SprawdzHaslo(string haslo)
        {
            if (haslo.Length < 8 || haslo.Length > 14)
            {
                MessageBox.Show("Hasło musi mieć minimum 8 znaków, maksymalnie 14.");
                return false;
            }
            else if (!haslo.Any(char.IsUpper))
            {
                MessageBox.Show("Hasło musi mieć conajmniej 1 wielką literę");
                return false;
            }
            else if (!haslo.Any(char.IsLower))
            {
                MessageBox.Show("Hasło musi mieć conajmniej 1 małą literę");
                return false;
            }
            else if (haslo.Contains(" "))
            {
                MessageBox.Show("Hasło nie może zawierać spacji");
                return false;
            }
            bool isspecjal = false;
            string specialCh = @"%!@#$%^&*()?/>.<,:;'\|}]{[_~`+=-" + "\"";
            char[] specialChh = specialCh.ToCharArray();
            foreach (char ch in specialChh)
            {
                if (haslo.Contains(ch))
                {
                    isspecjal = true;
                }

            }
            if (!isspecjal)
            {
                MessageBox.Show("Hasło musi zawierać znak specjalny");
                return false;
            }
            return true;
            
        }
         
    }

    }

