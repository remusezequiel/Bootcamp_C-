using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsAppAlumnos.Clases;

namespace WinFormsAppAlumnos.Vistas
{
    public partial class ProfesoresABM : Form
    {
        public bool EstoyModificanto { get; set; }
        public ProfesoresABM()
        {
            InitializeComponent();
            EstoyModificanto = true;
        }

        public ProfesoresABM(int idProfesorAModificar)
        {
            InitializeComponent();
            EstoyModificanto = true;
            CargarDatosProfesorParaModificar(idProfesorAModificar);
        }

        public void CargarDatosProfesorParaModificar(int idProfesorAModificar)
        {
            Profesor profesorAuxiliar = new Profesor();
            Profesor profesorDb = profesorAuxiliar.GetProfesorPorId(idProfesorAModificar);

            // Cargo Datos en Pantalla
            txtId.Text = profesorDb.Id.ToString();
            txtNombre.Text = profesorDb.Nombre;
            txtApellido.Text = profesorDb.Apellido;
            txtDocumento.Text = profesorDb.Documento;
            txtMail.Text = profesorDb.Mail;
            txtTelefono.Text = profesorDb.Telefono;
            txtSueldo.Text = profesorDb.Sueldo.ToString();
            txtFechaNAcimiento.Value = profesorDb.FechaNAcimiento;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void BtnGuardarProfesor_Click(object sender, EventArgs e)
        {
            if (EstoyModificanto == true)
            {
                ModificarProfesor();
            }
            else
            {
                AgregarProfesor();
            }
        }

        private void AgregarProfesor() 
        {
            Profesor profesorAGuardar = new Profesor();
            profesorAGuardar.Nombre = txtNombre.Text;
            profesorAGuardar.Apellido = txtApellido.Text;
            profesorAGuardar.Documento = txtDocumento.Text;
            profesorAGuardar.Telefono = txtTelefono.Text;
            profesorAGuardar.Mail = txtMail.Text;
            profesorAGuardar.Sueldo = Convert.ToDecimal(txtSueldo.Text);
            profesorAGuardar.FechaNAcimiento = txtFechaNAcimiento.Value;

            int resultado = profesorAGuardar.AgregarEnDb();

            if (resultado == 1)
            {
                MessageBox.Show("Profesor Agregado con exito");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error guardando profesor");
            }
        }

        private void ModificarProfesor() 
        {
            Profesor profesorAModificar = new Profesor();
            profesorAModificar.Nombre = txtNombre.Text;
            profesorAModificar.Apellido = txtApellido.Text;
            profesorAModificar.Documento = txtDocumento.Text;
            profesorAModificar.Telefono = txtTelefono.Text;
            profesorAModificar.Mail = txtMail.Text;
            profesorAModificar.Sueldo = Convert.ToDecimal(txtSueldo.Text);
            profesorAModificar.FechaNAcimiento = txtFechaNAcimiento.Value;
            profesorAModificar.Id = Convert.ToInt32(txtId.Text);

            Profesor profesorAux = new Profesor();
            int respuesta = profesorAux.ActualizarEnDb(profesorAModificar);
            if (respuesta == 1)
            {
                MessageBox.Show("Profesor Modificado con exito");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error Modificando Profesor");
            }

        }


    }
}
