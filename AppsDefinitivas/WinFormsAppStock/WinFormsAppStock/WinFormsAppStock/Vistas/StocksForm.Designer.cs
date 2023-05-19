namespace WinFormsAppStock.Vistas
{
    partial class StocksForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            gvStocks = new DataGridView();
            btnAgregarStock = new Button();
            btnModificarStock = new Button();
            btnEliminarStock = new Button();
            txtIdStock = new TextBox();
            IdStock = new Label();
            lblTitulo = new Label();
            ((System.ComponentModel.ISupportInitialize)gvStocks).BeginInit();
            SuspendLayout();
            // 
            // gvStocks
            // 
            gvStocks.AllowUserToAddRows = false;
            gvStocks.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gvStocks.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            gvStocks.BackgroundColor = SystemColors.GradientActiveCaption;
            gvStocks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gvStocks.Location = new Point(101, 161);
            gvStocks.Margin = new Padding(3, 2, 3, 2);
            gvStocks.Name = "gvStocks";
            gvStocks.ReadOnly = true;
            gvStocks.RowHeadersWidth = 51;
            gvStocks.RowTemplate.Height = 29;
            gvStocks.Size = new Size(599, 247);
            gvStocks.TabIndex = 13;
            gvStocks.CellContentClick += gvStocks_CellContentClick;
            // 
            // btnAgregarStock
            // 
            btnAgregarStock.BackColor = Color.FromArgb(128, 255, 128);
            btnAgregarStock.Location = new Point(522, 110);
            btnAgregarStock.Margin = new Padding(3, 2, 3, 2);
            btnAgregarStock.Name = "btnAgregarStock";
            btnAgregarStock.Size = new Size(178, 44);
            btnAgregarStock.TabIndex = 12;
            btnAgregarStock.Text = "Agregar Stock";
            btnAgregarStock.UseVisualStyleBackColor = false;
            btnAgregarStock.Click += btnAgregarStock_Click;
            // 
            // btnModificarStock
            // 
            btnModificarStock.BackColor = Color.FromArgb(128, 255, 255);
            btnModificarStock.Location = new Point(327, 135);
            btnModificarStock.Margin = new Padding(3, 2, 3, 2);
            btnModificarStock.Name = "btnModificarStock";
            btnModificarStock.Size = new Size(125, 22);
            btnModificarStock.TabIndex = 11;
            btnModificarStock.Text = "Modificar Stock";
            btnModificarStock.UseVisualStyleBackColor = false;
            btnModificarStock.Click += btnModificarStock_Click;
            // 
            // btnEliminarStock
            // 
            btnEliminarStock.BackColor = Color.FromArgb(255, 128, 128);
            btnEliminarStock.Location = new Point(327, 109);
            btnEliminarStock.Margin = new Padding(3, 2, 3, 2);
            btnEliminarStock.Name = "btnEliminarStock";
            btnEliminarStock.Size = new Size(125, 22);
            btnEliminarStock.TabIndex = 10;
            btnEliminarStock.Text = "Eliminar Stock";
            btnEliminarStock.UseVisualStyleBackColor = false;
            btnEliminarStock.Click += btnEliminarStock_Click;
            // 
            // txtIdStock
            // 
            txtIdStock.Location = new Point(169, 110);
            txtIdStock.Name = "txtIdStock";
            txtIdStock.Size = new Size(100, 23);
            txtIdStock.TabIndex = 9;
            // 
            // IdStock
            // 
            IdStock.AutoSize = true;
            IdStock.Location = new Point(101, 113);
            IdStock.Name = "IdStock";
            IdStock.Size = new Size(49, 15);
            IdStock.TabIndex = 8;
            IdStock.Text = "Id Stock";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.Location = new Point(269, 43);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(187, 22);
            lblTitulo.TabIndex = 7;
            lblTitulo.Text = "Formulario de Stocks";
            lblTitulo.Click += lblTitulo_Click;
            // 
            // StocksForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(gvStocks);
            Controls.Add(btnAgregarStock);
            Controls.Add(btnModificarStock);
            Controls.Add(btnEliminarStock);
            Controls.Add(txtIdStock);
            Controls.Add(IdStock);
            Controls.Add(lblTitulo);
            Name = "StocksForm";
            Text = "StocksForm";
            ((System.ComponentModel.ISupportInitialize)gvStocks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView gvStocks;
        private Button btnAgregarStock;
        private Button btnModificarStock;
        private Button btnEliminarStock;
        private TextBox txtIdStock;
        private Label IdStock;
        private Label lblTitulo;
    }
}