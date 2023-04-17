using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CodigoComun.Modelo;
using CodigoComun.Negocio;

namespace WinFormsAppStock.Vistas
{
    public partial class DepositosForm : Form
    {

        /******************* 
         * CONSTRUCTORES 
         *******************/
        public DepositosForm()
        {
            InitializeComponent();
            CargarDepositos();
        }

        /************* 
         * METODOS
         *************/
        /// <summary>
        ///     Toma la una lista de depositos desde la base de datos
        ///     los agrega al GridView gvDepositos
        /// </summary>
        private void CargarDepositos()
        {
            DepositoServices depositos = new DepositoServices();
            gvDepositos.DataSource = depositos.GetTodosLosDepositos();

            //Deposito depositoAux = new Deposito();
            //List<Deposito> depositoEnlaDb = depositoAux.GetTodosLosDepositos();
            //gvDepositos.DataSource = depositoEnlaDb;
        }


        /************ 
         * BOTONES 
         ************/
        /// <summary>
        ///     Agrega un deposito a la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregarDeposito_Click(object sender, EventArgs e)
        {
            DepositosABM depositosABM = new DepositosABM();
            depositosABM.Show();
        }

        /// <summary>
        ///     Elimina un deposito de la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminarDeposito_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdDeposito.Text))
            {
                MessageBox.Show("Por favor, ingrese un numero de Id correspondiente a un Deposito.", "Cuidado!");
            }
            else
            {
                int idDepositoAEliminar = Convert.ToInt32(txtIdDeposito.Text);
                // Instancio un DepositoServices 
                DepositoServices depositoAux = new DepositoServices();
                
                string mensaje = depositoAux.DeleteDeposito(idDepositoAEliminar);              
                if (mensaje == "Deposito Eliminado con exito")
                {
                    MessageBox.Show(mensaje, "Operación Exitosa!");
                }
                else
                {
                    MessageBox.Show(mensaje, "Hubo un problema");
                }
            }

        }

        /// <summary>
        ///     Modifica el deposito correspondiente con los datos indicados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModificarDeposito_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdDeposito.Text))
            {
                MessageBox.Show("Por favor, ingrese un numero de Id correspondiente a un Deposito.", "Cuidado!");
            }
            else
            {
                int IdDepositoAModificar = Convert.ToInt32(txtIdDeposito.Text);
                DepositosABM depositoABMModoModificacion = new DepositosABM(IdDepositoAModificar);
                depositoABMModoModificacion.Show();
            }
        }

        private void gvDepositos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
