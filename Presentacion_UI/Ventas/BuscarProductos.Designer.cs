namespace Presentacion_UI.Ventas
{
    partial class BuscarProducto
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cU_DatagridviewProductos1 = new Presentacion_UI.userControls.CU_DatagridviewProductos();
            this.cU_TxtTextocs2 = new Presentacion_UI.userControls.CU_TxtTextocs();
            this.cU_TxtTextocs1 = new Presentacion_UI.userControls.CU_TxtTextocs();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Descripcion";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(710, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Codigo";
            // 
            // cU_DatagridviewProductos1
            // 
            this.cU_DatagridviewProductos1.Location = new System.Drawing.Point(12, 172);
            this.cU_DatagridviewProductos1.Name = "cU_DatagridviewProductos1";
            this.cU_DatagridviewProductos1.Size = new System.Drawing.Size(892, 305);
            this.cU_DatagridviewProductos1.TabIndex = 4;
            // 
            // cU_TxtTextocs2
            // 
            this.cU_TxtTextocs2.Location = new System.Drawing.Point(687, 81);
            this.cU_TxtTextocs2.Name = "cU_TxtTextocs2";
            this.cU_TxtTextocs2.Size = new System.Drawing.Size(144, 20);
            this.cU_TxtTextocs2.TabIndex = 3;
            this.cU_TxtTextocs2.TextChanged += new System.EventHandler(this.cU_TxtTextocs2_TextChanged_1);
            // 
            // cU_TxtTextocs1
            // 
            this.cU_TxtTextocs1.Location = new System.Drawing.Point(39, 81);
            this.cU_TxtTextocs1.Name = "cU_TxtTextocs1";
            this.cU_TxtTextocs1.Size = new System.Drawing.Size(163, 20);
            this.cU_TxtTextocs1.TabIndex = 2;
            this.cU_TxtTextocs1.TextChanged += new System.EventHandler(this.cU_TxtTextocs1_TextChanged);
            // 
            // BuscarProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 489);
            this.Controls.Add(this.cU_DatagridviewProductos1);
            this.Controls.Add(this.cU_TxtTextocs2);
            this.Controls.Add(this.cU_TxtTextocs1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "BuscarProducto";
            this.Text = "BuscarProducto";
            this.Load += new System.EventHandler(this.BuscarProducto_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private userControls.CU_TxtTextocs cU_TxtTextocs1;
        private userControls.CU_TxtTextocs cU_TxtTextocs2;
        private userControls.CU_DatagridviewProductos cU_DatagridviewProductos1;
    }
}