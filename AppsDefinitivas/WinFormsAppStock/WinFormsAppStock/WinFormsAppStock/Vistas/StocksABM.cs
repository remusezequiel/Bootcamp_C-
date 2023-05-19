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
using CodigoComun.Entities.DTO;
using CodigoComun.Modelo.DTO;

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
       
        private StockDTO stockAux = new StockDTO();
        private ArticuloDTO articuloAux = new ArticuloDTO();
        private DepositoDTO depositoAux = new DepositoDTO();

        private List<DepositoDTO> depositosList = new List<DepositoDTO>();
        private List<ArticuloDTO> articulosList = new List<ArticuloDTO>();


        /* 
        * CONSTRUCTORES
        */
        #region CONSTRUCTORES
        public StocksABM()
        {
            InitializeComponent();
            CargarControlBox();
            EstoyModificando = false;
        }
        public StocksABM(int idStockAModificar)
        {
            if (stockServices.GetById(idStockAModificar) != null)
            {
                InitializeComponent();
                EstoyModificando = true;
                CargarDatosSockParaModificar(idStockAModificar);
                
            }
            else {
                MessageBox.Show("No existe El Stock", "Hubo un Problema");
            }          
        }
        #endregion

        /* 
        * METODOS
        */
        /// <summary>
        ///     Carga  los datos en los textBox y control Box
        ///     de el Stock pasado por id. Se utiliza en el ABM 
        ///     del Metodo Modificar.
        /// </summary>
        /// <param name="idStockAModificar"></param>
        private void CargarDatosSockParaModificar(int idStockAModificar) 
        {
            articulosList = articuloServices.GetAll();
            depositosList = depositoServices.GetAll();

            stockAux = stockServices.GetById(idStockAModificar);            
            articuloAux = articuloServices.GetByID((int)stockAux.IdArticulo);
            depositoAux = depositoServices.GetById((int)stockAux.IdDeposito);

            txtId.Text = Convert.ToString(idStockAModificar);
            txtCantidad.Text = stockAux.Cantidad.ToString();

            cbArticulo.DataSource = new BindingSource(articulosList, null);
            cbArticulo.DisplayMember = "Nombre";
            cbArticulo.ValueMember = "Id";
            cbArticulo.Text = articuloAux.Nombre.ToString();

            cbDeposito.DataSource = new BindingSource(depositosList, null);
            cbDeposito.DisplayMember = "Nombre";
            cbDeposito.ValueMember = "Id";
            cbDeposito.Text = depositoAux.Nombre.ToString();

        }

        /// <summary>
        ///     Carga los datos de los articulos y los depositos en los control box
        ///     para el ABM del Metodo Add.
        /// </summary>
        private void CargarControlBox()
        {
            List <DepositoDTO> depositosAux = new List<DepositoDTO>();    
            List<ArticuloDTO> articulosAux = new List<ArticuloDTO>();
                                    
            articulosAux = articuloServices.GetAll();
            depositosAux = depositoServices.GetAll();

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
            try
            {
                var articuloSeleccionado = cbArticulo.SelectedItem;
                var depositoSeleccionado = cbDeposito.SelectedItem;

                articuloAux = (ArticuloDTO)articuloSeleccionado;
                depositoAux = (DepositoDTO)depositoSeleccionado;
                StockDTO stockDTO = new StockDTO();
                stockDTO.Cantidad = Convert.ToDecimal(txtCantidad.Text);
                stockDTO.IdArticulo = articuloAux.Id;
                stockDTO.IdDeposito = depositoAux.Id;

                stockDTO = stockServices.Add(stockDTO);
           
                if (stockDTO.HuboError == false)
                {
                    MessageBox.Show(stockDTO.Mensaje, "Operación Exitosa");
                    this.Close();
                }
                else
                {
                    MessageBox.Show(stockDTO.Mensaje, "Cuidado!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Verifique si tiene campos vacios o agrego valores no numericos en el capo Cantidad",
                    "Cuidado!");
            }

        }

        /// <summary>
        ///     Modifica los datos del stock pasado
        ///     segun los textBox  y control box del formulario
        /// </summary>
        private void ModificarStock()
        {
            try {
            
                var articuloSeleccionado = cbArticulo.SelectedItem;
                var depositoSeleccionado = cbDeposito.SelectedItem;

                articuloAux = (ArticuloDTO)articuloSeleccionado;
                depositoAux = (DepositoDTO)depositoSeleccionado;
            
                stockAux.Id = Convert.ToInt32(txtId.Text);
                stockAux.Cantidad = Convert.ToDecimal(txtCantidad.Text);
                stockAux.IdArticulo = Convert.ToInt32(articuloAux.Id);
                stockAux.IdDeposito = Convert.ToInt32(depositoAux.Id);
            

                StockDTO stockDTOToUpdate = stockServices.Update(stockAux);
            
                if (stockDTOToUpdate.HuboError == false)
                {
                    MessageBox.Show(stockDTOToUpdate.Mensaje, "Operación Exitosa");
                    this.Close();
                }
                else
                {
                    MessageBox.Show(stockDTOToUpdate.Mensaje, "Cuidado!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Verifique si tiene campos vacios o agrego un valores numericos en el capo Cantidad",
                    "Cuidado!");
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
