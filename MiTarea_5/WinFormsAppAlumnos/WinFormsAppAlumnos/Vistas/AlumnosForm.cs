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
    public partial class AlumnosForm : Form
    {
        public AlumnosForm()
        {
            InitializeComponent();
            //llamo al metodo que carga los alumnos en la DB
            CargarAlumnos();
        }

        /// <summary>
        ///     Toma la una lista de alumnos desde la base de datos
        ///     los agrega al GridView gvAlumnos
        /// </summary>
        private void CargarAlumnos()
        {
            Alumno alumnoAuxiliar = new Alumno();
            List<Alumno> alumnosEnlaDb = alumnoAuxiliar.GetTodosLosAlumnos();
            gvAlumnos.DataSource = alumnosEnlaDb;

        }

        /// <summary>
        ///     Boton que nos manda al formulario AlumnosABM
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            AlumnosABM alumnosABM = new AlumnosABM();
            alumnosABM.Show();
        }


        /// <summary>
        ///     Elimina un alumno de la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            int idAlumnoAEliminar = Convert.ToInt32(this.txtIdAlumno.Text);
            Alumno alumnoAuxiliar = new Alumno();
            int r = alumnoAuxiliar.EliminarEnDb(idAlumnoAEliminar);

            if (r == 1)
            {
                MessageBox.Show("Alumno eliminado");
            }
            else
            {
                MessageBox.Show("No se pudo eliminar alumno");
            }
        }

        private void gvAlumnos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int IdAlumnoAModificar = Convert.ToInt32(txtIdAlumno.Text);
            AlumnosABM alumnosABMModoModificación = new AlumnosABM(IdAlumnoAModificar);
            alumnosABMModoModificación.Show();
        }
    }
}
