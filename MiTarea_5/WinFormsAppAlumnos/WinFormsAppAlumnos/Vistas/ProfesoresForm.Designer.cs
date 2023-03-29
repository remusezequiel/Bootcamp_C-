namespace WinFormsAppAlumnos.Vistas
{
    partial class ProfesoresForm
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            btnModificarProfesor = new Button();
            BtnEliminarProfesor = new Button();
            BtnAgregarProfesor = new Button();
            label1 = new Label();
            txtIdProfesor = new TextBox();
            gvProfesores = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)gvProfesores).BeginInit();
            SuspendLayout();
            // 
            // btnModificarProfesor
            // 
            btnModificarProfesor.Location = new Point(330, 72);
            btnModificarProfesor.Name = "btnModificarProfesor";
            btnModificarProfesor.Size = new Size(135, 23);
            btnModificarProfesor.TabIndex = 0;
            btnModificarProfesor.Text = "Modificar Profesor";
            btnModificarProfesor.UseVisualStyleBackColor = true;
            btnModificarProfesor.Click += btnModificarProfesor_Click;
            // 
            // BtnEliminarProfesor
            // 
            BtnEliminarProfesor.Location = new Point(330, 101);
            BtnEliminarProfesor.Name = "BtnEliminarProfesor";
            BtnEliminarProfesor.Size = new Size(135, 23);
            BtnEliminarProfesor.TabIndex = 1;
            BtnEliminarProfesor.Text = "Eliminar Profesor";
            BtnEliminarProfesor.UseVisualStyleBackColor = true;
            BtnEliminarProfesor.Click += BtnEliminarProfesor_Click;
            // 
            // BtnAgregarProfesor
            // 
            BtnAgregarProfesor.Location = new Point(508, 45);
            BtnAgregarProfesor.Name = "BtnAgregarProfesor";
            BtnAgregarProfesor.Size = new Size(181, 50);
            BtnAgregarProfesor.TabIndex = 2;
            BtnAgregarProfesor.Text = "Agregar Profesor";
            BtnAgregarProfesor.UseVisualStyleBackColor = true;
            BtnAgregarProfesor.Click += BtnAgregarProfesor_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(74, 72);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 3;
            label1.Text = "Id Profesor";
            label1.Click += label1_Click;
            // 
            // txtIdProfesor
            // 
            txtIdProfesor.Location = new Point(155, 72);
            txtIdProfesor.Name = "txtIdProfesor";
            txtIdProfesor.Size = new Size(100, 23);
            txtIdProfesor.TabIndex = 4;
            // 
            // gvProfesores
            // 
            gvProfesores.AllowUserToAddRows = false;
            gvProfesores.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvProfesores.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            gvProfesores.BackgroundColor = SystemColors.GradientActiveCaption;
            gvProfesores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gvProfesores.Location = new Point(12, 139);
            gvProfesores.Margin = new Padding(3, 2, 3, 2);
            gvProfesores.Name = "gvProfesores";
            gvProfesores.ReadOnly = true;
            gvProfesores.RowHeadersWidth = 51;
            gvProfesores.RowTemplate.Height = 29;
            gvProfesores.Size = new Size(823, 256);
            gvProfesores.TabIndex = 5;
            // 
            // ProfesoresForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(857, 450);
            Controls.Add(gvProfesores);
            Controls.Add(txtIdProfesor);
            Controls.Add(label1);
            Controls.Add(BtnAgregarProfesor);
            Controls.Add(BtnEliminarProfesor);
            Controls.Add(btnModificarProfesor);
            Name = "ProfesoresForm";
            Text = "ProfesoresForm";
            ((System.ComponentModel.ISupportInitialize)gvProfesores).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnModificarProfesor;
        private Button BtnEliminarProfesor;
        private Button BtnAgregarProfesor;
        private Label label1;
        private TextBox txtIdProfesor;
        private DataGridView gvProfesores;
    }
}