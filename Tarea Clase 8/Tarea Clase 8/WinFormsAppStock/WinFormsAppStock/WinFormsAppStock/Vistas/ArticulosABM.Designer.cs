namespace WinFormsAppStock.Vistas
{
    partial class ArticulosABM
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
            lblId = new Label();
            lblNombre = new Label();
            lblMarca = new Label();
            lblProveedor = new Label();
            lblMinimoStock = new Label();
            lblPrecio = new Label();
            BtnGuardarArticulo = new Button();
            txtId = new TextBox();
            txtNombre = new TextBox();
            txtMarca = new TextBox();
            txtMinimoStock = new TextBox();
            txtProveedor = new TextBox();
            txtPrecio = new TextBox();
            lblTitulo = new Label();
            txtCodigo = new TextBox();
            lblCodigo = new Label();
            SuspendLayout();
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(60, 98);
            lblId.Name = "lblId";
            lblId.Size = new Size(18, 15);
            lblId.TabIndex = 2;
            lblId.Text = "ID";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(60, 131);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(51, 15);
            lblNombre.TabIndex = 3;
            lblNombre.Text = "Nombre";
            // 
            // lblMarca
            // 
            lblMarca.AutoSize = true;
            lblMarca.Location = new Point(60, 164);
            lblMarca.Name = "lblMarca";
            lblMarca.Size = new Size(40, 15);
            lblMarca.TabIndex = 4;
            lblMarca.Text = "Marca";
            // 
            // lblProveedor
            // 
            lblProveedor.AutoSize = true;
            lblProveedor.Location = new Point(60, 225);
            lblProveedor.Name = "lblProveedor";
            lblProveedor.Size = new Size(61, 15);
            lblProveedor.TabIndex = 5;
            lblProveedor.Text = "Proveedor";
            // 
            // lblMinimoStock
            // 
            lblMinimoStock.AutoSize = true;
            lblMinimoStock.Location = new Point(60, 194);
            lblMinimoStock.Name = "lblMinimoStock";
            lblMinimoStock.Size = new Size(81, 15);
            lblMinimoStock.TabIndex = 6;
            lblMinimoStock.Text = "Minimo Stock";
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Location = new Point(60, 262);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(40, 15);
            lblPrecio.TabIndex = 7;
            lblPrecio.Text = "Precio";
            // 
            // BtnGuardarArticulo
            // 
            BtnGuardarArticulo.Location = new Point(184, 332);
            BtnGuardarArticulo.Margin = new Padding(3, 2, 3, 2);
            BtnGuardarArticulo.Name = "BtnGuardarArticulo";
            BtnGuardarArticulo.Size = new Size(151, 22);
            BtnGuardarArticulo.TabIndex = 18;
            BtnGuardarArticulo.Text = "Guardar";
            BtnGuardarArticulo.UseVisualStyleBackColor = true;
            BtnGuardarArticulo.Click += BtnGuardarArticulo_Click;
            // 
            // txtId
            // 
            txtId.Location = new Point(184, 98);
            txtId.Margin = new Padding(3, 2, 3, 2);
            txtId.Name = "txtId";
            txtId.Size = new Size(79, 23);
            txtId.TabIndex = 19;
            txtId.TextChanged += txtId_TextChanged;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(184, 131);
            txtNombre.Margin = new Padding(3, 2, 3, 2);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(155, 23);
            txtNombre.TabIndex = 20;
            // 
            // txtMarca
            // 
            txtMarca.Location = new Point(184, 164);
            txtMarca.Margin = new Padding(3, 2, 3, 2);
            txtMarca.Name = "txtMarca";
            txtMarca.Size = new Size(155, 23);
            txtMarca.TabIndex = 21;
            // 
            // txtMinimoStock
            // 
            txtMinimoStock.Location = new Point(184, 194);
            txtMinimoStock.Margin = new Padding(3, 2, 3, 2);
            txtMinimoStock.Name = "txtMinimoStock";
            txtMinimoStock.Size = new Size(155, 23);
            txtMinimoStock.TabIndex = 22;
            // 
            // txtProveedor
            // 
            txtProveedor.Location = new Point(184, 225);
            txtProveedor.Margin = new Padding(3, 2, 3, 2);
            txtProveedor.Name = "txtProveedor";
            txtProveedor.Size = new Size(155, 23);
            txtProveedor.TabIndex = 23;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(184, 259);
            txtPrecio.Margin = new Padding(3, 2, 3, 2);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(155, 23);
            txtPrecio.TabIndex = 24;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.Location = new Point(92, 30);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(247, 22);
            lblTitulo.TabIndex = 25;
            lblTitulo.Text = "Ingrese los datos del Articulo";
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(184, 289);
            txtCodigo.Margin = new Padding(3, 2, 3, 2);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(155, 23);
            txtCodigo.TabIndex = 26;
            // 
            // lblCodigo
            // 
            lblCodigo.AutoSize = true;
            lblCodigo.Location = new Point(60, 289);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new Size(46, 15);
            lblCodigo.TabIndex = 27;
            lblCodigo.Text = "Codigo";
            // 
            // ArticulosABM
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(546, 450);
            Controls.Add(lblCodigo);
            Controls.Add(txtCodigo);
            Controls.Add(lblTitulo);
            Controls.Add(txtPrecio);
            Controls.Add(txtProveedor);
            Controls.Add(txtMinimoStock);
            Controls.Add(txtMarca);
            Controls.Add(txtNombre);
            Controls.Add(txtId);
            Controls.Add(BtnGuardarArticulo);
            Controls.Add(lblPrecio);
            Controls.Add(lblMinimoStock);
            Controls.Add(lblProveedor);
            Controls.Add(lblMarca);
            Controls.Add(lblNombre);
            Controls.Add(lblId);
            Name = "ArticulosABM";
            Text = "ArticulosABM";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblId;
        private Label lblNombre;
        private Label lblMarca;
        private Label lblProveedor;
        private Label lblMinimoStock;
        private Label lblPrecio;
        private Button BtnGuardarArticulo;
        private TextBox txtId;
        private TextBox txtNombre;
        private TextBox txtMarca;
        private TextBox txtMinimoStock;
        private TextBox txtProveedor;
        private TextBox txtPrecio;
        private Label lblTitulo;
        private TextBox txtCodigo;
        private Label lblCodigo;
    }
}