namespace WinFormsAppAlumnos.Vistas
{
    partial class AlumnosForm
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            button1 = new Button();
            gvAlumnos = new DataGridView();
            button2 = new Button();
            button3 = new Button();
            txtIdAlumno = new TextBox();
            IdAlumno = new Label();
            ((System.ComponentModel.ISupportInitialize)gvAlumnos).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(630, 36);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(178, 44);
            button1.TabIndex = 0;
            button1.Text = "Agregar Alumno";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // gvAlumnos
            // 
            gvAlumnos.AllowUserToAddRows = false;
            gvAlumnos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvAlumnos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            gvAlumnos.BackgroundColor = SystemColors.GradientActiveCaption;
            gvAlumnos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gvAlumnos.Location = new Point(14, 112);
            gvAlumnos.Margin = new Padding(3, 2, 3, 2);
            gvAlumnos.Name = "gvAlumnos";
            gvAlumnos.ReadOnly = true;
            gvAlumnos.RowHeadersWidth = 51;
            gvAlumnos.RowTemplate.Height = 29;
            gvAlumnos.Size = new Size(823, 228);
            gvAlumnos.TabIndex = 1;
            gvAlumnos.CellContentClick += gvAlumnos_CellContentClick;
            // 
            // button2
            // 
            button2.Location = new Point(406, 32);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(125, 22);
            button2.TabIndex = 2;
            button2.Text = "Eliminar Alumno";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(406, 58);
            button3.Margin = new Padding(3, 2, 3, 2);
            button3.Name = "button3";
            button3.Size = new Size(125, 22);
            button3.TabIndex = 3;
            button3.Text = "Modificar Alumno";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // txtIdAlumno
            // 
            txtIdAlumno.Location = new Point(223, 32);
            txtIdAlumno.Margin = new Padding(3, 2, 3, 2);
            txtIdAlumno.Name = "txtIdAlumno";
            txtIdAlumno.Size = new Size(110, 23);
            txtIdAlumno.TabIndex = 4;
            // 
            // IdAlumno
            // 
            IdAlumno.AutoSize = true;
            IdAlumno.Location = new Point(142, 32);
            IdAlumno.Name = "IdAlumno";
            IdAlumno.Size = new Size(60, 15);
            IdAlumno.TabIndex = 5;
            IdAlumno.Text = "IdAlumno";
            // 
            // AlumnosForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(865, 375);
            Controls.Add(IdAlumno);
            Controls.Add(txtIdAlumno);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(gvAlumnos);
            Controls.Add(button1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "AlumnosForm";
            Text = "AlumnosForm";
            ((System.ComponentModel.ISupportInitialize)gvAlumnos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private DataGridView gvAlumnos;
        private Button button2;
        private Button button3;
        private TextBox txtIdAlumno;
        private Label IdAlumno;
    }
}