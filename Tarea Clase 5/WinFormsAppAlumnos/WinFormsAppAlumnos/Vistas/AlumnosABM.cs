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
    public partial class AlumnosABM : Form
    {
        public bool EstoyModificando { get; set;  }
        
        public AlumnosABM()
        {
            InitializeComponent();
            EstoyModificando = false;
        }

        public AlumnosABM(int idAlumnoAModificar)
        {
            InitializeComponent();
            CargarDatosAlumnoParaModificar(idAlumnoAModificar);
            EstoyModificando = true;
        }

        public void CargarDatosAlumnoParaModificar(int idAlumnoAModificar) 
        { 
            Alumno alumnoAuxiliar = new Alumno();
            Alumno alumnoDb = alumnoAuxiliar.GetAlumnoPorId(idAlumnoAModificar);

            // Cargo Datos en Pantalla
            txtId.Text = alumnoDb.Id.ToString();
            txtNombre.Text = alumnoDb.Nombre;
            txtApellido.Text = alumnoDb.Apellido;
            txtDocumento.Text = alumnoDb.Documento;
            txtEmail.Text = alumnoDb.Mail;
            txtTelefono.Text = alumnoDb.Telefono;
            txtCuota.Text = alumnoDb.Cuota.ToString();
            txtFechaNAcimiento.Value = alumnoDb.FechaNAcimiento;


        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (EstoyModificando == true)
            {
                ModificarAlumno();
            }
            else {
                AgregarAlumno();
            }
        }


        private void AgregarAlumno() 
        {
            Alumno alumnoAGuardar = new Alumno();
            alumnoAGuardar.Nombre = txtCuota.Text;
            alumnoAGuardar.Apellido = txtApellido.Text;
            alumnoAGuardar.Documento = txtDocumento.Text;
            alumnoAGuardar.Telefono = txtTelefono.Text;
            alumnoAGuardar.Mail = txtEmail.Text;
            alumnoAGuardar.Cuota = Convert.ToDecimal(txtCuota.Text);
            alumnoAGuardar.FechaNAcimiento = txtFechaNAcimiento.Value;

            int resultado = alumnoAGuardar.AgregarEnDb();

            if (resultado == 1)
            {
                MessageBox.Show("Alumno Agregado con exito");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error guardando alumno");
            }
        }

        private void ModificarAlumno()
        {
            Alumno alumnoAModificar = new Alumno();
            Alumno alumnoAux = new Alumno();

            
            alumnoAModificar.Nombre = txtNombre.Text;
            alumnoAModificar.Apellido = txtApellido.Text;
            alumnoAModificar.Documento = txtDocumento.Text;
            alumnoAModificar.Telefono = txtTelefono.Text;
            alumnoAModificar.Mail = txtEmail.Text;
            alumnoAModificar.Cuota = Convert.ToDecimal(txtCuota.Text);
            alumnoAModificar.FechaNAcimiento = txtFechaNAcimiento.Value;
            alumnoAModificar.Id = Convert.ToInt32(txtId.Text);

            int respuesta = alumnoAux.ActualizarEnDb(alumnoAModificar);
            if (respuesta == 1)
            {
                MessageBox.Show("Alumno Modificado con exito");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error Modificando alumno");
            }
        }
    }
}
