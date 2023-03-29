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
    public partial class ProfesoresForm : Form
    {

        public ProfesoresForm()
        {
            InitializeComponent();
            CargarAlumnos();
        }

        private void CargarAlumnos()
        {
            Profesor profesorAuxiliar = new Profesor();
            List<Profesor> profesorEnlaDb = profesorAuxiliar.GetTodosLosProfesores();
            gvProfesores.DataSource = profesorEnlaDb;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BtnEliminarProfesor_Click(object sender, EventArgs e)
        {
            int idProfesorAEliminar = Convert.ToInt32(this.txtIdProfesor.Text);

            Profesor profesorAuxiliar = new Profesor();

            int r = profesorAuxiliar.EliminarEnDb(idProfesorAEliminar);

            if (r == 1)
            {
                MessageBox.Show("Profesor eliminado");
            }
            else
            {
                MessageBox.Show("No se pudo eliminar profesor");
            }
        }

        private void BtnAgregarProfesor_Click(object sender, EventArgs e)
        {
            ProfesoresABM profesorABM = new ProfesoresABM();
            profesorABM.Show();
        }

        private void btnModificarProfesor_Click(object sender, EventArgs e)
        {
            int IdProfesorAModificar = Convert.ToInt32(txtIdProfesor.Text);
            ProfesoresABM profesoresABMModoModificación = new ProfesoresABM(IdProfesorAModificar);
            profesoresABMModoModificación.Show();
        }
    }
}
