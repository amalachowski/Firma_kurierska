using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    }
}
