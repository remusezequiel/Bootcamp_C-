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
using CodigoComun.Negocio;

namespace WinFormsAppStock.Vistas
{
    public partial class ArticulosForm : Form
    {
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
            List <Articulo> articulosEnlaDb = articuloAux.GetTodosPorID();
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

            if (string.IsNullOrEmpty(txtIdArticulo.Text))
            {
                MessageBox.Show("Por favor, ingrese un numero de Id correspondiente a un Articulo.", "Cuidado!");
            }
            else
            {
                int idArticuloAEliminar = Convert.ToInt32(txtIdArticulo.Text);
                ArticuloServices articuloServices = new ArticuloServices();
                
                string mensaje = articuloServices.EliminarArticulo(idArticuloAEliminar);
                if (mensaje == "Articulo Eliminado con Exito")
                {
                    MessageBox.Show(mensaje, "Operación Exitosa");
                }
                else
                {
                    MessageBox.Show(mensaje, "Hubo un Problema");
                }
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
            if (string.IsNullOrEmpty(txtIdArticulo.Text))
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

        private void gvArticulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
