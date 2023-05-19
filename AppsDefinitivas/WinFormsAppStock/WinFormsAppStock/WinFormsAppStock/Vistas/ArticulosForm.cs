using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CodigoComun.Datos.Repository;
using CodigoComun.Modelo;
using CodigoComun.Modelo.DTO;
using CodigoComun.Negocio;

namespace WinFormsAppStock.Vistas
{
    public partial class ArticulosForm : Form
    {
       /******************** 
       *    ATRIBUTOS 
       *********************/
        ArticuloServices articuloServices = new ArticuloServices();
       /******************** 
       * CONSTRUCTORES 
       *********************/
        public ArticulosForm()
        {
            InitializeComponent();
            CargarArticulos();
        }

        /************* 
         * METODOS 
         *************/
        /// <summary>
        ///     Toma la una lista de articulos desde la base de datos
        ///     los agrega al GridView gvArticulos
        /// </summary>
        private void CargarArticulos()
        {
            ArticuloServices articuloAux = new ArticuloServices();
            List <ArticuloDTO> articulosEnlaDb = articuloAux.GetAll();
            gvArticulos.DataSource = articulosEnlaDb;
        }


        /************ 
         * BOTONES 
         ************/
        /// <summary>
        ///     Boton que entrega el Formulario para poder Agregar un Articulo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregarArticulo_Click(object sender, EventArgs e)
        {
            ArticulosABM articulosABM = new ArticulosABM();
            articulosABM.Show();
        }

        /// <summary>
        ///     Al precionar el Boton se elimina el articulo pasado por Id
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminarArticulo_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtIdArticulo.Text) || articuloServices.GetByID(Convert.ToInt32(txtIdArticulo.Text)) == null)
                {
                    MessageBox.Show("Por favor, ingrese un numero de Id correspondiente a un Articulo.", "Cuidado!");
                }
                else
                {
                    int idArticuloAEliminar = Convert.ToInt32(txtIdArticulo.Text);
                    ArticuloServices articuloServices = new ArticuloServices();
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;
                    result = MessageBox.Show("¿Realmente desea eliminar el Articulo?", "Confirmar", buttons);
                    if (result == DialogResult.Yes)
                    {
                        ArticuloDTO articuloToDelete = articuloServices.Delete(idArticuloAEliminar);
                        if (articuloToDelete.HuboError == false)
                        {
                            MessageBox.Show(articuloToDelete.Mensaje, "Operación Exitosa");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show(articuloToDelete.Mensaje, "Hubo un Problema");
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
        ///     Boton que redirije al Formulario ArticulosABM
        ///     Modifica un Articulo, siempre y cuando se haya 
        ///     ingresado un ID
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModificarArticulo_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtIdArticulo.Text) || articuloServices.GetByID(Convert.ToInt32(txtIdArticulo.Text)) == null)
                {
                    MessageBox.Show("Por favor, ingrese un numero de Id correspondiente a un Articulo.","Cuidado!");
                }
                else
                {
                    int IdArticuloAModificar = Convert.ToInt32(txtIdArticulo.Text);
                    ArticulosABM articuloABMModoModificación = new ArticulosABM(IdArticuloAModificar);
                    articuloABMModoModificación.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrio una Excepcion: {ex.Message}. \n Verifique si el Id es numerico", "Excepción");
            }
        }

        private void gvArticulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
