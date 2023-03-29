using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsAppAlumnos.Vistas;

namespace WinFormsAppAlumnos
{
    public partial class InicioForm : Form
    {
        public InicioForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AlumnosForm alumnosForm = new AlumnosForm();
            alumnosForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProfesoresForm profesoresForm = new ProfesoresForm();
            profesoresForm.Show();
        }
    }
}
