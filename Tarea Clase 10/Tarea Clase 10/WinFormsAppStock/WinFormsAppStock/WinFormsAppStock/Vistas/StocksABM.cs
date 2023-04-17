using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CodigoComun.Negocio;
using CodigoComun.Datos.Repository;
using CodigoComun.Modelo;
using Codigo_Comun.Negocio;
using CodigoComun.Entities;

namespace WinFormsAppStock.Vistas
{
    public partial class StocksABM : Form
    {
        /* 
        * ATRIBUTOS 
        */
        private ArticuloServices articuloServices = new ArticuloServices();
        private StockServices stockServices = new StockServices();
        private DepositoServices depositoServices = new DepositoServices();
        
        private bool EstoyModificando { get; set; }
       
        private Stock stockAux = new Stock();
        private Articulo articuloAux = new Articulo();
        private Deposito depositoAux = new Deposito();


        /* 
        * CONSTRUCTORES
        */
        public StocksABM()
        {
            InitializeComponent();
            CargarControlBox();
            EstoyModificando = false;
        }
        public StocksABM(int idStockAModificar)
        {
            InitializeComponent();
            CargarControlBox();
            EstoyModificando = true;
            CargarDatosSockParaModificar(idStockAModificar);
        }


        /* 
        * METODOS
        */

        /// <summary>
        ///     Carga  los datos en los textBox y control Box
        ///     de el Stock pasado por id
        /// </summary>
        /// <param name="idStockAModificar"></param>
        private void CargarDatosSockParaModificar(int idStockAModificar) 
        {            
            stockAux = stockServices.GetDeposito(idStockAModificar);

            txtId.Text = Convert.ToString(idStockAModificar);
            txtCantidad.Text = stockAux.Cantidad.ToString();
            cbArticulo.Text = stockAux.IdArticulo.ToString();
            cbDeposito.Text = stockAux.IdDeposito.ToString();
        }

        /// <summary>
        ///     Carga los datos de los articulos y los depositos en los control box.
        /// </summary>
        private void CargarControlBox()
        {
            List <Deposito> depositosAux = new List<Deposito>();    
            List<Articulo> articulosAux = new List<Articulo>();
                                    
            articulosAux = articuloServices.GetTodosPorID();
            depositosAux = depositoServices.GetTodosLosDepositos();

            cbArticulo.DataSource = new BindingSource(articulosAux, null);
            cbArticulo.DisplayMember = "Nombre";
            cbArticulo.ValueMember = "Id";
            cbDeposito.DataSource = new BindingSource(depositosAux, null);
            cbDeposito.DisplayMember = "Nombre";
            cbDeposito.ValueMember = "Id";
        }


        /// <summary>
        ///     Agrega los datos del formulario 
        ///     a la base de datos
        /// </summary>
        private void AgregarStock()
        {
            var articuloSeleccionado = cbArticulo.SelectedItem;
            var depositoSeleccionado = cbDeposito.SelectedItem;

            articuloAux = (Articulo)articuloSeleccionado;
            depositoAux = (Deposito)depositoSeleccionado;

            stockAux.Cantidad = Convert.ToDecimal(txtCantidad.Text);
            stockAux.IdArticulo = articuloAux.Id;
            stockAux.IdDeposito = depositoAux.Id;

            string mensaje = stockServices.AddStock(stockAux);
           
            if (mensaje == "Stock Agregado con exito")
            {
                MessageBox.Show(mensaje, "Operación Exitosa");
                this.Close();
            }
            else
            {
                MessageBox.Show(mensaje, "Hubo un problema");
            }
        }

        /// <summary>
        ///     Modifica los datos del stock pasado
        ///     segun los textBox  y control box del formulario
        /// </summary>
        private void ModificarStock()
        {
            var articuloSeleccionado = cbArticulo.SelectedItem;
            var depositoSeleccionado = cbDeposito.SelectedItem;

            articuloAux = (Articulo)articuloSeleccionado;
            depositoAux = (Deposito)depositoSeleccionado;
            
            stockAux.Id = Convert.ToInt32(txtId.Text);
            stockAux.Cantidad = Convert.ToDecimal(txtCantidad.Text);
            stockAux.IdArticulo = Convert.ToInt32(articuloAux.Id);
            stockAux.IdDeposito = Convert.ToInt32(depositoAux.Id);
            

            string mensaje = stockServices.UpdateStock(stockAux);
            
            if (mensaje == "Stock Modificado con exito")
            {
                MessageBox.Show(mensaje, "Operación Exitosa");
                this.Close();
            }
            else
            {
                MessageBox.Show(mensaje, "Hubo un problema");
            }
        }



        /* 
        * BOTONES
        */
        /// <summary>
        ///   El boton agrega o modifica un deposito
        ///     segun de donde se ejecute ek formuladio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardarStock_Click(object sender, EventArgs e)
        {
            if (EstoyModificando == true)
            {
                ModificarStock();
            }
            else
            {
                AgregarStock();
            }
        }
    
    
    }
}
