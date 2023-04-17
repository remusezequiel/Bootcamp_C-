namespace WinFormsAppStock.Vistas
{
    partial class StocksABM
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
            cbArticulo = new ComboBox();
            cbDeposito = new ComboBox();
            txtCantidad = new TextBox();
            txtId = new TextBox();
            label1 = new Label();
            btnGuardarStock = new Button();
            lblCantidad = new Label();
            lblArticulo = new Label();
            lblDeposito = new Label();
            lblTitulo = new Label();
            SuspendLayout();
            // 
            // cbArticulo
            // 
            cbArticulo.FormattingEnabled = true;
            cbArticulo.Location = new Point(162, 223);
            cbArticulo.Margin = new Padding(3, 2, 3, 2);
            cbArticulo.Name = "cbArticulo";
            cbArticulo.Size = new Size(155, 23);
            cbArticulo.TabIndex = 35;
            // 
            // cbDeposito
            // 
            cbDeposito.FormattingEnabled = true;
            cbDeposito.Location = new Point(162, 265);
            cbDeposito.Margin = new Padding(3, 2, 3, 2);
            cbDeposito.Name = "cbDeposito";
            cbDeposito.Size = new Size(155, 23);
            cbDeposito.TabIndex = 36;
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(162, 180);
            txtCantidad.Margin = new Padding(3, 2, 3, 2);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(155, 23);
            txtCantidad.TabIndex = 37;
            // 
            // txtId
            // 
            txtId.Location = new Point(162, 134);
            txtId.Margin = new Padding(3, 2, 3, 2);
            txtId.Name = "txtId";
            txtId.Size = new Size(79, 23);
            txtId.TabIndex = 38;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(92, 134);
            label1.Name = "label1";
            label1.Size = new Size(18, 15);
            label1.TabIndex = 39;
            label1.Text = "ID";
            // 
            // btnGuardarStock
            // 
            btnGuardarStock.Location = new Point(162, 316);
            btnGuardarStock.Margin = new Padding(3, 2, 3, 2);
            btnGuardarStock.Name = "btnGuardarStock";
            btnGuardarStock.Size = new Size(155, 22);
            btnGuardarStock.TabIndex = 40;
            btnGuardarStock.Text = "Guardar";
            btnGuardarStock.UseVisualStyleBackColor = true;
            btnGuardarStock.Click += btnGuardarStock_Click;
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(92, 180);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(55, 15);
            lblCantidad.TabIndex = 41;
            lblCantidad.Text = "Cantidad";
            // 
            // lblArticulo
            // 
            lblArticulo.AutoSize = true;
            lblArticulo.Location = new Point(92, 223);
            lblArticulo.Name = "lblArticulo";
            lblArticulo.Size = new Size(49, 15);
            lblArticulo.TabIndex = 42;
            lblArticulo.Text = "Articulo";
            // 
            // lblDeposito
            // 
            lblDeposito.AutoSize = true;
            lblDeposito.Location = new Point(92, 265);
            lblDeposito.Name = "lblDeposito";
            lblDeposito.Size = new Size(54, 15);
            lblDeposito.TabIndex = 43;
            lblDeposito.Text = "Deposito";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.Location = new Point(92, 40);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(229, 22);
            lblTitulo.TabIndex = 44;
            lblTitulo.Text = "Ingrese los datos del Stock";
            // 
            // StocksABM
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(464, 450);
            Controls.Add(lblTitulo);
            Controls.Add(lblDeposito);
            Controls.Add(lblArticulo);
            Controls.Add(lblCantidad);
            Controls.Add(btnGuardarStock);
            Controls.Add(label1);
            Controls.Add(txtId);
            Controls.Add(txtCantidad);
            Controls.Add(cbDeposito);
            Controls.Add(cbArticulo);
            Name = "StocksABM";
            Text = "StocksABM";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbArticulo;
        private ComboBox cbDeposito;
        private TextBox txtCantidad;
        private TextBox txtId;
        private Label label1;
        private Button btnGuardarStock;
        private Label lblCantidad;
        private Label lblArticulo;
        private Label lblDeposito;
        private Label lblTitulo;
    }
}