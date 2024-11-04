using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace Presentacion_UI.userControls
{
    public class CU_TxtTextocs: TextBox
    {
        public Boolean Validar()
        {
            Regex re = new Regex("/^/w$/");

            return re.IsMatch(base.Text.Trim());

        }
    }
}
