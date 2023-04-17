namespace WinFormsAppStock.Vistas
{
    partial class DepositosForm
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
            gvDepositos = new DataGridView();
            btnAgregarDeposito = new Button();
            btnModificarDeposito = new Button();
            btnEliminarDeposito = new Button();
            txtIdDeposito = new TextBox();
            IdDeposito = new Label();
            ((System.ComponentModel.ISupportInitialize)gvDepositos).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(268, 9);
            label1.Name = "label1";
            label1.Size = new Size(212, 22);
            label1.TabIndex = 1;
            label1.Text = "Formulario de Depositos";
            // 
            // gvDepositos
            // 
            gvDepositos.AllowUserToAddRows = false;
            gvDepositos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gvDepositos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            gvDepositos.BackgroundColor = SystemColors.GradientActiveCaption;
            gvDepositos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gvDepositos.Location = new Point(94, 137);
            gvDepositos.Margin = new Padding(3, 2, 3, 2);
            gvDepositos.Name = "gvDepositos";
            gvDepositos.ReadOnly = true;
            gvDepositos.RowHeadersWidth = 51;
            gvDepositos.RowTemplate.Height = 29;
            gvDepositos.Size = new Size(599, 228);
            gvDepositos.TabIndex = 12;
            gvDepositos.CellContentClick += gvDepositos_CellContentClick;
            // 
            // btnAgregarDeposito
            // 
            btnAgregarDeposito.BackColor = Color.FromArgb(128, 255, 128);
            btnAgregarDeposito.Location = new Point(515, 86);
            btnAgregarDeposito.Margin = new Padding(3, 2, 3, 2);
            btnAgregarDeposito.Name = "btnAgregarDeposito";
            btnAgregarDeposito.Size = new Size(178, 44);
            btnAgregarDeposito.TabIndex = 11;
            btnAgregarDeposito.Text = "Agregar Deposito";
            btnAgregarDeposito.UseVisualStyleBackColor = false;
            btnAgregarDeposito.Click += btnAgregarDeposito_Click;
            // 
            // btnModificarDeposito
            // 
            btnModificarDeposito.BackColor = Color.FromArgb(128, 255, 255);
            btnModificarDeposito.Location = new Point(320, 111);
            btnModificarDeposito.Margin = new Padding(3, 2, 3, 2);
            btnModificarDeposito.Name = "btnModificarDeposito";
            btnModificarDeposito.Size = new Size(125, 22);
            btnModificarDeposito.TabIndex = 10;
            btnModificarDeposito.Text = "Modificar Deposito";
            btnModificarDeposito.UseVisualStyleBackColor = false;
            btnModificarDeposito.Click += btnModificarDeposito_Click;
            // 
            // btnEliminarDeposito
            // 
            btnEliminarDeposito.BackColor = Color.FromArgb(255, 128, 128);
            btnEliminarDeposito.Location = new Point(320, 85);
            btnEliminarDeposito.Margin = new Padding(3, 2, 3, 2);
            btnEliminarDeposito.Name = "btnEliminarDeposito";
            btnEliminarDeposito.Size = new Size(125, 22);
            btnEliminarDeposito.TabIndex = 9;
            btnEliminarDeposito.Text = "Eliminar Deposito";
            btnEliminarDeposito.UseVisualStyleBackColor = false;
            btnEliminarDeposito.Click += btnEliminarDeposito_Click;
            // 
            // txtIdDeposito
            // 
            txtIdDeposito.Location = new Point(162, 86);
            txtIdDeposito.Name = "txtIdDeposito";
            txtIdDeposito.Size = new Size(100, 23);
            txtIdDeposito.TabIndex = 8;
            // 
            // IdDeposito
            // 
            IdDeposito.AutoSize = true;
            IdDeposito.Location = new Point(94, 89);
            IdDeposito.Name = "IdDeposito";
            IdDeposito.Size = new Size(67, 15);
            IdDeposito.TabIndex = 7;
            IdDeposito.Text = "Id Deposito";
            // 
            // DepositosForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(gvDepositos);
            Controls.Add(btnAgregarDeposito);
            Controls.Add(btnModificarDeposito);
            Controls.Add(btnEliminarDeposito);
            Controls.Add(txtIdDeposito);
            Controls.Add(IdDeposito);
            Controls.Add(label1);
            Name = "DepositosForm";
            Text = "DepositosForm";
            ((System.ComponentModel.ISupportInitialize)gvDepositos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView gvDepositos;
        private Button btnAgregarDeposito;
        private Button btnModificarDeposito;
        private Button btnEliminarDeposito;
        private TextBox txtIdDeposito;
        private Label IdDeposito;
    }
}