namespace Presentacion_UI
{
    partial class InicioSesion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cU_TxtContraseña1 = new Presentacion_UI.userControls.CU_TxtContraseña();
            this.CU_TxtUsuario = new Presentacion_UI.userControls.CU_TxtTextocs();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(48, 190);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(202, 29);
            this.button1.TabIndex = 0;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(92, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "USUARIO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(88, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "Contraseña";
            // 
            // cU_TxtContraseña1
            // 
            this.cU_TxtContraseña1.Location = new System.Drawing.Point(48, 154);
            this.cU_TxtContraseña1.Name = "cU_TxtContraseña1";
            this.cU_TxtContraseña1.Size = new System.Drawing.Size(202, 20);
            this.cU_TxtContraseña1.TabIndex = 7;
            this.cU_TxtContraseña1.UseSystemPasswordChar = true;
            this.cU_TxtContraseña1.TextChanged += new System.EventHandler(this.cU_TxtContraseña1_TextChanged);
            this.cU_TxtContraseña1.Leave += new System.EventHandler(this.cU_TxtContraseña1_Leave);
            // 
            // CU_TxtUsuario
            // 
            this.CU_TxtUsuario.Location = new System.Drawing.Point(48, 79);
            this.CU_TxtUsuario.Name = "CU_TxtUsuario";
            this.CU_TxtUsuario.Size = new System.Drawing.Size(202, 20);
            this.CU_TxtUsuario.TabIndex = 5;
            // 
            // InicioSesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 254);
            this.Controls.Add(this.cU_TxtContraseña1);
            this.Controls.Add(this.CU_TxtUsuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "InicioSesion";
            this.Text = "InicioSesion";
            this.Load += new System.EventHandler(this.InicioSesion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private userControls.CU_TxtTextocs CU_TxtUsuario;
        private userControls.CU_TxtContraseña cU_TxtContraseña1;
    }
}