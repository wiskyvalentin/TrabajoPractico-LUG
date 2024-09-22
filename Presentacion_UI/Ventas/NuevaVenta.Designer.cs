namespace Presentacion_UI.Ventas
{
    partial class NuevaVenta
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LabelCliente = new System.Windows.Forms.Button();
            this.DatosFacturaForm = new System.Windows.Forms.DataGridView();
            this.PrecioTotalLabel = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.CantidadSelect = new System.Windows.Forms.NumericUpDown();
            this.CodBarrasSelect = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Button2 = new System.Windows.Forms.Button();
            this.Button1 = new System.Windows.Forms.Button();
            this.txtCliente = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DatosFacturaForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CantidadSelect)).BeginInit();
            this.Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LabelCliente
            // 
            this.LabelCliente.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LabelCliente.Location = new System.Drawing.Point(932, 136);
            this.LabelCliente.Name = "LabelCliente";
            this.LabelCliente.Size = new System.Drawing.Size(243, 36);
            this.LabelCliente.TabIndex = 23;
            this.LabelCliente.Text = "Cobrar";
            this.LabelCliente.UseVisualStyleBackColor = true;
            this.LabelCliente.Click += new System.EventHandler(this.BtnTerminarVentas_Click);
            // 
            // DatosFacturaForm
            // 
            this.DatosFacturaForm.AllowUserToDeleteRows = false;
            this.DatosFacturaForm.AllowUserToResizeRows = false;
            this.DatosFacturaForm.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.DatosFacturaForm.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DatosFacturaForm.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DatosFacturaForm.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DatosFacturaForm.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.DatosFacturaForm.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(20)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.MenuBar;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(20)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.MenuBar;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DatosFacturaForm.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.DatosFacturaForm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DatosFacturaForm.EnableHeadersVisualStyles = false;
            this.DatosFacturaForm.GridColor = System.Drawing.SystemColors.Control;
            this.DatosFacturaForm.Location = new System.Drawing.Point(155, 136);
            this.DatosFacturaForm.MultiSelect = false;
            this.DatosFacturaForm.Name = "DatosFacturaForm";
            this.DatosFacturaForm.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DatosFacturaForm.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.DatosFacturaForm.RowHeadersVisible = false;
            this.DatosFacturaForm.RowHeadersWidth = 15;
            this.DatosFacturaForm.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DatosFacturaForm.RowTemplate.Height = 25;
            this.DatosFacturaForm.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DatosFacturaForm.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DatosFacturaForm.Size = new System.Drawing.Size(716, 162);
            this.DatosFacturaForm.TabIndex = 22;
            this.DatosFacturaForm.TabStop = false;
            this.DatosFacturaForm.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DatosFacturaForm_CellContentClick);
            // 
            // PrecioTotalLabel
            // 
            this.PrecioTotalLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PrecioTotalLabel.AutoSize = true;
            this.PrecioTotalLabel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.PrecioTotalLabel.Location = new System.Drawing.Point(1198, 19);
            this.PrecioTotalLabel.Name = "PrecioTotalLabel";
            this.PrecioTotalLabel.Size = new System.Drawing.Size(19, 21);
            this.PrecioTotalLabel.TabIndex = 21;
            this.PrecioTotalLabel.Text = "0";
            // 
            // Label8
            // 
            this.Label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label8.AutoSize = true;
            this.Label8.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.Label8.Location = new System.Drawing.Point(1109, 19);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(42, 21);
            this.Label8.TabIndex = 20;
            this.Label8.Text = "Total";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(221, 44);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(49, 13);
            this.Label2.TabIndex = 19;
            this.Label2.Text = "Cantidad";
            // 
            // CantidadSelect
            // 
            this.CantidadSelect.Location = new System.Drawing.Point(219, 64);
            this.CantidadSelect.Name = "CantidadSelect";
            this.CantidadSelect.Size = new System.Drawing.Size(52, 20);
            this.CantidadSelect.TabIndex = 18;
            this.CantidadSelect.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // CodBarrasSelect
            // 
            this.CodBarrasSelect.Location = new System.Drawing.Point(308, 64);
            this.CodBarrasSelect.Name = "CodBarrasSelect";
            this.CodBarrasSelect.Size = new System.Drawing.Size(109, 20);
            this.CodBarrasSelect.TabIndex = 17;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(326, 44);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(73, 13);
            this.Label1.TabIndex = 16;
            this.Label1.Text = "Codigo Barras";
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.Button2);
            this.Panel1.Controls.Add(this.Button1);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(141, 363);
            this.Panel1.TabIndex = 24;
            // 
            // Button2
            // 
            this.Button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.Button2.Location = new System.Drawing.Point(0, 40);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(141, 40);
            this.Button2.TabIndex = 5;
            this.Button2.Text = "Clientes";
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // Button1
            // 
            this.Button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Button1.Location = new System.Drawing.Point(0, 0);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(141, 40);
            this.Button1.TabIndex = 4;
            this.Button1.Text = "Buscar Producto";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // txtCliente
            // 
            this.txtCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCliente.AutoSize = true;
            this.txtCliente.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtCliente.Location = new System.Drawing.Point(151, 333);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(0, 21);
            this.txtCliente.TabIndex = 26;
            // 
            // NuevaVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1249, 363);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.LabelCliente);
            this.Controls.Add(this.DatosFacturaForm);
            this.Controls.Add(this.PrecioTotalLabel);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.CantidadSelect);
            this.Controls.Add(this.CodBarrasSelect);
            this.Controls.Add(this.Label1);
            this.Name = "NuevaVenta";
            this.Text = "Ventas";
            this.Load += new System.EventHandler(this.NuevaVenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DatosFacturaForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CantidadSelect)).EndInit();
            this.Panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button LabelCliente;
        internal System.Windows.Forms.DataGridView DatosFacturaForm;
        internal System.Windows.Forms.Label PrecioTotalLabel;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.NumericUpDown CantidadSelect;
        internal System.Windows.Forms.TextBox CodBarrasSelect;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Button Button2;
        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.Label txtCliente;
    }
}