namespace WinFormsAppAlumnos.Vistas
{
    partial class ProfesoresABM
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            BtnGuardarProfesor = new Button();
            txtId = new TextBox();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            txtDocumento = new TextBox();
            txtTelefono = new TextBox();
            txtMail = new TextBox();
            txtSueldo = new TextBox();
            txtFechaNAcimiento = new DateTimePicker();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(67, 36);
            label1.Name = "label1";
            label1.Size = new Size(18, 15);
            label1.TabIndex = 1;
            label1.Text = "ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(67, 71);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 2;
            label2.Text = "Nombre";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(66, 109);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 3;
            label3.Text = "Apellido";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(66, 148);
            label4.Name = "label4";
            label4.Size = new Size(70, 15);
            label4.TabIndex = 4;
            label4.Text = "Documento";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(66, 186);
            label5.Name = "label5";
            label5.Size = new Size(52, 15);
            label5.TabIndex = 5;
            label5.Text = "Telefono";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(66, 229);
            label6.Name = "label6";
            label6.Size = new Size(30, 15);
            label6.TabIndex = 6;
            label6.Text = "Mail";
            label6.Click += label6_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(66, 270);
            label7.Name = "label7";
            label7.Size = new Size(43, 15);
            label7.TabIndex = 7;
            label7.Text = "Sueldo";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(66, 310);
            label8.Name = "label8";
            label8.Size = new Size(103, 15);
            label8.TabIndex = 8;
            label8.Text = "Fecha Nacimiento";
            // 
            // BtnGuardarProfesor
            // 
            BtnGuardarProfesor.Location = new Point(176, 358);
            BtnGuardarProfesor.Margin = new Padding(3, 2, 3, 2);
            BtnGuardarProfesor.Name = "BtnGuardarProfesor";
            BtnGuardarProfesor.Size = new Size(151, 22);
            BtnGuardarProfesor.TabIndex = 17;
            BtnGuardarProfesor.Text = "Guardar";
            BtnGuardarProfesor.UseVisualStyleBackColor = true;
            BtnGuardarProfesor.Click += BtnGuardarProfesor_Click;
            // 
            // txtId
            // 
            txtId.Location = new Point(176, 36);
            txtId.Margin = new Padding(3, 2, 3, 2);
            txtId.Name = "txtId";
            txtId.Size = new Size(79, 23);
            txtId.TabIndex = 18;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(176, 71);
            txtNombre.Margin = new Padding(3, 2, 3, 2);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(155, 23);
            txtNombre.TabIndex = 19;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(176, 109);
            txtApellido.Margin = new Padding(3, 2, 3, 2);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(155, 23);
            txtApellido.TabIndex = 20;
            // 
            // txtDocumento
            // 
            txtDocumento.Location = new Point(176, 148);
            txtDocumento.Margin = new Padding(3, 2, 3, 2);
            txtDocumento.Name = "txtDocumento";
            txtDocumento.Size = new Size(155, 23);
            txtDocumento.TabIndex = 21;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(176, 186);
            txtTelefono.Margin = new Padding(3, 2, 3, 2);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(155, 23);
            txtTelefono.TabIndex = 22;
            // 
            // txtMail
            // 
            txtMail.Location = new Point(176, 229);
            txtMail.Margin = new Padding(3, 2, 3, 2);
            txtMail.Name = "txtMail";
            txtMail.Size = new Size(155, 23);
            txtMail.TabIndex = 23;
            // 
            // txtSueldo
            // 
            txtSueldo.Location = new Point(176, 270);
            txtSueldo.Margin = new Padding(3, 2, 3, 2);
            txtSueldo.Name = "txtSueldo";
            txtSueldo.Size = new Size(155, 23);
            txtSueldo.TabIndex = 24;
            // 
            // txtFechaNAcimiento
            // 
            txtFechaNAcimiento.Location = new Point(176, 310);
            txtFechaNAcimiento.Margin = new Padding(3, 2, 3, 2);
            txtFechaNAcimiento.Name = "txtFechaNAcimiento";
            txtFechaNAcimiento.Size = new Size(219, 23);
            txtFechaNAcimiento.TabIndex = 25;
            // 
            // ProfesoresABM
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(533, 450);
            Controls.Add(txtFechaNAcimiento);
            Controls.Add(txtSueldo);
            Controls.Add(txtMail);
            Controls.Add(txtTelefono);
            Controls.Add(txtDocumento);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Controls.Add(txtId);
            Controls.Add(BtnGuardarProfesor);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ProfesoresABM";
            Text = "ProfesoresABM";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Button BtnGuardarProfesor;
        private TextBox txtId;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtDocumento;
        private TextBox txtTelefono;
        private TextBox txtMail;
        private TextBox txtSueldo;
        private DateTimePicker txtFechaNAcimiento;
    }
}