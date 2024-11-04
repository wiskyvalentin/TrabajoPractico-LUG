using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Presentacion_UI.userControls
{
    public class CU_TxtCorreo : TextBox
    {
        public Boolean Validar()
        {
            Regex re = new Regex("(\\W|^)[\\w.\\-]{0,25}@(yahoo|hotmail|gmail)\\.com(\\W|$)");

            return re.IsMatch(base.Text.Trim());

        }
    }
}
