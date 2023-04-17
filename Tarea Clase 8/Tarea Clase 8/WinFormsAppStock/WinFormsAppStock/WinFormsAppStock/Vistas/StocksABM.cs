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

namespace WinFormsAppStock.Vistas
{
    public partial class StocksABM : Form
    {
        /* 
        * ATRIBUTOS 
        */
        public bool EstoyModificando { get; set; }

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
            Stock stockAux = new Stock();
            Stock stockEnDb = stockAux.GetStockPorId(idStockAModificar);

            //txtId.Text = articuloEnDb.ToString();
            txtId.Text = Convert.ToString(idStockAModificar);
            txtCantidad.Text = stockEnDb.Cantidad.ToString();
            cbArticulo.Text = stockEnDb.ArticuloGuardado.Nombre;
            cbDeposito.Text = stockEnDb.DepositoDondeEstaGuardado.Nombre;
        }

        /// <summary>
        ///     Carga los datos de los articulos y los depositos en los control box.
        /// </summary>
        private void CargarControlBox()
        {
            List<Articulo> articulos = new List<Articulo>();
            List<Deposito> depositos = new List<Deposito>();
            ArticuloServices articulosAux = new ArticuloServices();
            //Articulo articulosAux = new Articulo();
            Deposito depositosAux = new Deposito();

            articulos = articulosAux.GetTodosPorID();
            depositos = depositosAux.GetTodosLosDepositos();
            cbArticulo.DataSource = new BindingSource(articulos, null);
            cbArticulo.DisplayMember = "Nombre";
            cbArticulo.ValueMember = "Id";
            cbDeposito.DataSource = new BindingSource(depositos, null);
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

            Stock stockAAgregar = new Stock();
            stockAAgregar.Cantidad = Convert.ToDecimal(txtCantidad.Text);
            stockAAgregar.ArticuloGuardado = (Articulo)articuloSeleccionado;
            stockAAgregar.DepositoDondeEstaGuardado = (Deposito)depositoSeleccionado;

            int respuesta = stockAAgregar.AgregarEnDb();
            if (respuesta != -1)
            {
                MessageBox.Show("Stock Agregado con exito", "Operación Exitosa");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error Agregando Stock", "Hubo un problema");
            }
        }

        /// <summary>
        ///     Modifica los datos del stock pasado
        ///     segun los textBox  y control box del formulario
        /// </summary>
        private void ModificarStock()
        {
            Stock stockAModificar = new Stock();
            Stock stockAux = new Stock();
            var articuloSeleccionado = cbArticulo.SelectedItem;
            var depositoSeleccionado = cbDeposito.SelectedItem;

            stockAModificar.Id = Convert.ToInt32(txtId.Text);
            stockAModificar.Cantidad = Convert.ToDecimal(txtCantidad.Text);
            stockAModificar.ArticuloGuardado = (Articulo)articuloSeleccionado;
            stockAModificar.DepositoDondeEstaGuardado = (Deposito)depositoSeleccionado;

            if (stockAux.ActualizarEnDb(stockAModificar) == 1)
            {
                MessageBox.Show("Stock Modificado con Exito.", "Operación Exitosa");
                this.Close();
            }
            else
            {
                MessageBox.Show("No se pudo modificar el Stock.", "Hubo un problema");
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
