namespace WinFormsAppStock.Vistas
{
    partial class ArticulosForm
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
            label1 = new Label();
            IdArticulo = new Label();
            txtIdArticulo = new TextBox();
            btnEliminarArticulo = new Button();
            btnModificarArticulo = new Button();
            btnAgregarArticulo = new Button();
            gvArticulos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)gvArticulos).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(282, 9);
            label1.Name = "label1";
            label1.Size = new Size(205, 22);
            label1.TabIndex = 0;
            label1.Text = "Formulario de Articulos";
            // 
            // IdArticulo
            // 
            IdArticulo.AutoSize = true;
            IdArticulo.Location = new Point(114, 79);
            IdArticulo.Name = "IdArticulo";
            IdArticulo.Size = new Size(62, 15);
            IdArticulo.TabIndex = 1;
            IdArticulo.Text = "Id Articulo";
            // 
            // txtIdArticulo
            // 
            txtIdArticulo.Location = new Point(182, 76);
            txtIdArticulo.Name = "txtIdArticulo";
            txtIdArticulo.Size = new Size(100, 23);
            txtIdArticulo.TabIndex = 2;
            // 
            // btnEliminarArticulo
            // 
            btnEliminarArticulo.BackColor = Color.FromArgb(255, 128, 128);
            btnEliminarArticulo.Location = new Point(340, 75);
            btnEliminarArticulo.Margin = new Padding(3, 2, 3, 2);
            btnEliminarArticulo.Name = "btnEliminarArticulo";
            btnEliminarArticulo.Size = new Size(125, 22);
            btnEliminarArticulo.TabIndex = 3;
            btnEliminarArticulo.Text = "Eliminar Articulo";
            btnEliminarArticulo.UseVisualStyleBackColor = false;
            btnEliminarArticulo.Click += btnEliminarArticulo_Click;
            // 
            // btnModificarArticulo
            // 
            btnModificarArticulo.BackColor = Color.FromArgb(128, 255, 255);
            btnModificarArticulo.Location = new Point(340, 101);
            btnModificarArticulo.Margin = new Padding(3, 2, 3, 2);
            btnModificarArticulo.Name = "btnModificarArticulo";
            btnModificarArticulo.Size = new Size(125, 22);
            btnModificarArticulo.TabIndex = 4;
            btnModificarArticulo.Text = "Modificar Articulo";
            btnModificarArticulo.UseVisualStyleBackColor = false;
            btnModificarArticulo.Click += btnModificarArticulo_Click;
            // 
            // btnAgregarArticulo
            // 
            btnAgregarArticulo.BackColor = Color.FromArgb(128, 255, 128);
            btnAgregarArticulo.Location = new Point(535, 76);
            btnAgregarArticulo.Margin = new Padding(3, 2, 3, 2);
            btnAgregarArticulo.Name = "btnAgregarArticulo";
            btnAgregarArticulo.Size = new Size(178, 44);
            btnAgregarArticulo.TabIndex = 5;
            btnAgregarArticulo.Text = "Agregar Articulo";
            btnAgregarArticulo.UseVisualStyleBackColor = false;
            btnAgregarArticulo.Click += btnAgregarArticulo_Click;
            // 
            // gvArticulos
            // 
            gvArticulos.AllowUserToAddRows = false;
            gvArticulos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gvArticulos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            gvArticulos.BackgroundColor = SystemColors.GradientActiveCaption;
            gvArticulos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gvArticulos.Location = new Point(114, 127);
            gvArticulos.Margin = new Padding(3, 2, 3, 2);
            gvArticulos.Name = "gvArticulos";
            gvArticulos.ReadOnly = true;
            gvArticulos.RowHeadersWidth = 51;
            gvArticulos.RowTemplate.Height = 29;
            gvArticulos.Size = new Size(599, 247);
            gvArticulos.TabIndex = 6;
            gvArticulos.CellContentClick += gvArticulos_CellContentClick;
            // 
            // ArticulosForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(847, 450);
            Controls.Add(gvArticulos);
            Controls.Add(btnAgregarArticulo);
            Controls.Add(btnModificarArticulo);
            Controls.Add(btnEliminarArticulo);
            Controls.Add(txtIdArticulo);
            Controls.Add(IdArticulo);
            Controls.Add(label1);
            Name = "ArticulosForm";
            Text = "ArticulosForm";
            ((System.ComponentModel.ISupportInitialize)gvArticulos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label IdArticulo;
        private TextBox txtIdArticulo;
        private Button btnEliminarArticulo;
        private Button btnModificarArticulo;
        private Button btnAgregarArticulo;
        private DataGridView gvArticulos;
    }
}