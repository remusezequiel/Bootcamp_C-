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

namespace WinFormsAppStock.Vistas
{
    public partial class StocksForm : Form
    {
        /******************** 
         * CONSTRUCTORES 
         ********************/
        public StocksForm()
        {
            InitializeComponent();
            CargarStocks();
        }


        /************ 
         * METODOS
         ************/
        /// <summary>
        ///     Carga los datos de la base de datos de stock
        ///     en el GridView
        /// </summary>
        private void CargarStocks()
        {
            Stock stockAux = new Stock();
            List<Stock> StockAMostrar = stockAux.GetTodosLosStocks();

            gvStocks.Columns.Add("0","id");
            gvStocks.Columns.Add("1", "Articulo");
            gvStocks.Columns.Add("2", "Deposito");
            gvStocks.Columns.Add("3", "Cantidad");
            for (int i = 1; i <= StockAMostrar.Count; i++)
            {
                int n = gvStocks.Rows.Add();
                gvStocks.Rows[n].Cells[0].Value = StockAMostrar[n].Id.ToString();
                gvStocks.Rows[n].Cells[1].Value = StockAMostrar[n].ArticuloGuardado.Id.ToString();
                gvStocks.Rows[n].Cells[2].Value = StockAMostrar[n].DepositoDondeEstaGuardado.Id.ToString();
                gvStocks.Rows[n].Cells[3].Value = StockAMostrar[n].Cantidad.ToString();
            }
            //  Si borramos el codigo anterior y dejamos solo esta linea funciona pero 
            // los datos del articulo y el deposito no se toman correctamente
            //gvStocks.DataSource = StockAMostrar;
        }


        /************ 
         * BOTONES
         ************/
        /// <summary>
        ///     Elimina un Stock una vez indicado el id en
        ///     el textBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminarStock_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdStock.Text))
            {
                MessageBox.Show("Por favor, ingrese un numero de Id correspondiente a un Stock.", "Cuidado!");
            }
            else
            {
                int idStockAEliminar = Convert.ToInt32(txtIdStock.Text);
                Stock StockAux = new Stock();
                if (StockAux.EliminarEnDb(idStockAEliminar) == 1)
                {
                    MessageBox.Show("Stock Eliminado con Existo.", "Operación Exitosa");
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el Stock.", "Hubo un Problema");
                }
            }
        }

        /// <summary>
        ///     Abre el StockABM para asi Agregar un nuevo Stock
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregarStock_Click(object sender, EventArgs e)
        {
            StocksABM stocksABM = new StocksABM();
            stocksABM.Show();
        }

        /// <summary>
        ///     Abre el StockABM siempre y cuando se haya pasado un id
        ///     en el textBox. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModificarStock_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdStock.Text))
            {
                MessageBox.Show("Por favor, ingrese un numero de Id correspondiente a un Stock.", "Cuidado!");
            }
            else
            {
                int IdStockAModificar = Convert.ToInt32(txtIdStock.Text);
                StocksABM stockABMModoModificacion = new StocksABM(IdStockAModificar);
                stockABMModoModificacion.Show();
            }
        }
      
        private void gvStocks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}
