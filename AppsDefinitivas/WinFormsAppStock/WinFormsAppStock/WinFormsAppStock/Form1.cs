using WinFormsAppStock.Vistas;
using CodigoComun.Modelo;

namespace WinFormsAppStock
{
    public partial class Form1 : Form
    {
        /****************** 
         * CONSTRUCTOR 
         ******************/
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /************ 
         * BOTONES 
         ************/

        /// <summary>
        ///     Boton inicial que nos lleva al formulario de Articulos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnArticulos_Click(object sender, EventArgs e)
        {
            ArticulosForm articulosForm = new ArticulosForm();
            articulosForm.Show();
        }

        /// <summary>
        ///     Boton inicial que nos lleva al formulario de Depositos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDepositos_Click(object sender, EventArgs e)
        {
            DepositosForm depositosForm = new DepositosForm();
            depositosForm.Show();
        }

        /// <summary>
        ///     Boton inicial que nos lleva al formulario de stock
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStocks_Click(object sender, EventArgs e)
        {
            StocksForm stocksForm = new StocksForm();
            stocksForm.Show();
        }
    }
}