using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion_UI.userControls
{
    public class CU_TxtContraseña : TextBox
    {
       
        public Boolean Validar()
        {
            Regex re = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");

            return re.IsMatch(base.Text.Trim());

        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // CU_TxtContraseña
            // 
            this.PasswordChar = '*';
            this.ResumeLayout(false);

        }
    }
}
