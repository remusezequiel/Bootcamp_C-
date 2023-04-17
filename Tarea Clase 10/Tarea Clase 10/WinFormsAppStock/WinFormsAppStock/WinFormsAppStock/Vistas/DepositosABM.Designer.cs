namespace WinFormsAppStock.Vistas
{
    partial class DepositosABM
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
            lblCapacidad = new Label();
            label1 = new Label();
            txtId = new TextBox();
            txtCapacidad = new TextBox();
            label3 = new Label();
            lblDireccion = new Label();
            txtNombre = new TextBox();
            txtDireccion = new TextBox();
            BtnGuardarDeposito = new Button();
            lblTitulo = new Label();
            SuspendLayout();
            // 
            // lblCapacidad
            // 
            lblCapacidad.AutoSize = true;
            lblCapacidad.Location = new Point(50, 117);
            lblCapacidad.Name = "lblCapacidad";
            lblCapacidad.Size = new Size(63, 15);
            lblCapacidad.TabIndex = 4;
            lblCapacidad.Text = "Capacidad";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(50, 82);
            label1.Name = "label1";
            label1.Size = new Size(18, 15);
            label1.TabIndex = 3;
            label1.Text = "ID";
            // 
            // txtId
            // 
            txtId.Location = new Point(150, 82);
            txtId.Margin = new Padding(3, 2, 3, 2);
            txtId.Name = "txtId";
            txtId.Size = new Size(79, 23);
            txtId.TabIndex = 19;
            // 
            // txtCapacidad
            // 
            txtCapacidad.Location = new Point(150, 117);
            txtCapacidad.Margin = new Padding(3, 2, 3, 2);
            txtCapacidad.Name = "txtCapacidad";
            txtCapacidad.Size = new Size(155, 23);
            txtCapacidad.TabIndex = 20;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(50, 151);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 22;
            label3.Text = "Nombre";
            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.Location = new Point(50, 187);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(57, 15);
            lblDireccion.TabIndex = 21;
            lblDireccion.Text = "Dirección";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(150, 151);
            txtNombre.Margin = new Padding(3, 2, 3, 2);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(155, 23);
            txtNombre.TabIndex = 23;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(150, 187);
            txtDireccion.Margin = new Padding(3, 2, 3, 2);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(155, 23);
            txtDireccion.TabIndex = 24;
            // 
            // BtnGuardarDeposito
            // 
            BtnGuardarDeposito.Location = new Point(150, 255);
            BtnGuardarDeposito.Margin = new Padding(3, 2, 3, 2);
            BtnGuardarDeposito.Name = "BtnGuardarDeposito";
            BtnGuardarDeposito.Size = new Size(155, 22);
            BtnGuardarDeposito.TabIndex = 25;
            BtnGuardarDeposito.Text = "Guardar";
            BtnGuardarDeposito.UseVisualStyleBackColor = true;
            BtnGuardarDeposito.Click += BtnGuardarDeposito_Click_1;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.Location = new Point(94, 26);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(254, 22);
            lblTitulo.TabIndex = 26;
            lblTitulo.Text = "Ingrese los datos del Deposito";
            // 
            // DepositosABM
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(440, 333);
            Controls.Add(lblTitulo);
            Controls.Add(BtnGuardarDeposito);
            Controls.Add(txtDireccion);
            Controls.Add(txtNombre);
            Controls.Add(label3);
            Controls.Add(lblDireccion);
            Controls.Add(txtCapacidad);
            Controls.Add(txtId);
            Controls.Add(lblCapacidad);
            Controls.Add(label1);
            Name = "DepositosABM";
            Text = "DepositosABM";
            ResumeLayout(false);
            PerformLayout();
        }

        private void BtnGuardarDeposito_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Label lblCapacidad;
        private Label label1;
        private TextBox txtId;
        private TextBox txtCapacidad;
        private Label label3;
        private Label lblDireccion;
        private TextBox txtNombre;
        private TextBox txtDireccion;
        private Button BtnGuardarDeposito;
        private Label lblTitulo;
    }
}