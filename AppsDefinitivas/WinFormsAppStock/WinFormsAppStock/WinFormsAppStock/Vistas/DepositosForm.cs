using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Codigo_Comun.Negocio;
using CodigoComun.Entities.DTO;
using CodigoComun.Modelo;
using CodigoComun.Negocio;

namespace WinFormsAppStock.Vistas
{
    public partial class DepositosForm : Form
    {
        /******************* 
         *   ATRIBUTOS 
         *******************/
        DepositoServices depositoServices = new DepositoServices();
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
            gvDepositos.DataSource = depositoServices.GetAll();            
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
            try
            {
                if (string.IsNullOrEmpty(txtIdDeposito.Text) || depositoServices.GetById(Convert.ToInt32(txtIdDeposito.Text)) == null)
                {
                    MessageBox.Show("Por favor, ingrese un numero de Id correspondiente a un Deposito.", "Cuidado!");
                }
                else
                {
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;
                    result = MessageBox.Show("¿Realmente desea eliminar el Deposito?", "Confirmar", buttons);
                    if (result == DialogResult.Yes)
                    {

                        int idDepositoAEliminar = Convert.ToInt32(txtIdDeposito.Text);

                        DepositoDTO depositoDTO = depositoServices.Delete(idDepositoAEliminar);
                        if (depositoDTO.HuboError == false)
                        {
                            MessageBox.Show(depositoDTO.Mensaje, "Operación Exitosa!");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show(depositoDTO.Mensaje, "Cuidado!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrio una Excepcion: {ex.Message}. \n Verifique si el Id es numerico", "Excepción");
            }

        }

        /// <summary>
        ///     Modifica el deposito correspondiente con los datos indicados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModificarDeposito_Click(object sender, EventArgs e)
        {
            try { 
            
                if (string.IsNullOrEmpty(txtIdDeposito.Text) || depositoServices.GetById(Convert.ToInt32(txtIdDeposito.Text)) == null)
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
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrio una Excepcion: {ex.Message}.", "Excepción");
            }
        }

        private void gvDepositos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
