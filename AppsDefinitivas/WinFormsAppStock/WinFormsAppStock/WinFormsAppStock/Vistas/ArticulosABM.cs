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
    public partial class ArticulosABM : Form
    {
        /*************** 
         * ATRIBUTOS 
         ***************/
        private bool EstoyModificando { get; set; }
        private ArticuloServices articuloServices = new ArticuloServices();
        private ArticulosRepository articuloRepository = new ArticulosRepository();
        /********************* 
        * CONSTRUCTORES 
        *********************/
        public ArticulosABM()
        {
            InitializeComponent();
            EstoyModificando = false;
        }
        public ArticulosABM(int idArticuloAModificar)
        {
            if (articuloServices.GetByID(idArticuloAModificar) != null) {
                InitializeComponent();
                EstoyModificando = true;
                CargarDatosArticuloParaModificar(idArticuloAModificar);
            }
            else
            {
                MessageBox.Show("No Existe el Articulo", "Hubo un problema");
            }
        }


        /************** 
         * METODOS 
         **************/
        /// <summary>
        ///     Carga los datos del articulo pedido en los textBox
        ///     del formulario
        /// </summary>
        /// <param name="idArticuloAModificar"></param>
        public void CargarDatosArticuloParaModificar(int idArticuloAModificar)
        {            
            Articulo articuloEnDb = articuloRepository.GetById(idArticuloAModificar);
            
            txtId.Text = idArticuloAModificar.ToString();
            txtNombre.Text = articuloEnDb.Nombre;
            txtMarca.Text = articuloEnDb.Marca;
            txtMinimoStock.Text = articuloEnDb.MinimoStock.ToString();
            txtProveedor.Text = articuloEnDb.Proveedor;
            txtPrecio.Text = articuloEnDb.Precio.ToString();
            txtCodigo.Text = articuloEnDb.Codigo;                                  
        }

        /// <summary>
        ///     Agrega los datos del formulario 
        ///     a la base de datos
        /// </summary>
        private void AgregarArticulo()
        {
            try
            {
                ArticuloDTO articuloAGuardar = new ArticuloDTO();
                articuloAGuardar.Nombre = txtNombre.Text;
                articuloAGuardar.Marca = txtMarca.Text;
                articuloAGuardar.MinimoStock = Convert.ToDecimal(txtMinimoStock.Text);
                articuloAGuardar.Proveedor = txtProveedor.Text;
                articuloAGuardar.Precio = Convert.ToDecimal(txtPrecio.Text);
                articuloAGuardar.Codigo = txtCodigo.Text;

                // Instancio el servicio
                articuloAGuardar = articuloServices.Add(articuloAGuardar);
                if (articuloAGuardar.HuboError == false)
                {
                    MessageBox.Show(articuloAGuardar.Mensaje, "Operación Exitosa");
                    this.Close();
                }
                else
                {
                    MessageBox.Show(articuloAGuardar.Mensaje, "Hubo un problema");
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"Verifique si los campos Minimo Stock o Cantidad poseen caracteres no numericos", "Cuidado!");
            }
        }

        /// <summary>
        ///     Modifica los datos del articulo pasado
        ///     segun los textBox del formulario
        /// </summary>
        private void ModificarArticulo()
        {
            try
            {

                ArticuloDTO articuloAModificar = new ArticuloDTO();

                articuloAModificar.Id = Convert.ToInt32(txtId.Text);
                articuloAModificar.Nombre = txtNombre.Text;
                articuloAModificar.Marca = txtMarca.Text;
                articuloAModificar.MinimoStock = Convert.ToDecimal(txtMinimoStock.Text);
                articuloAModificar.Proveedor = txtProveedor.Text;
                articuloAModificar.Precio = Convert.ToDecimal(txtPrecio.Text);
                articuloAModificar.Codigo = txtCodigo.Text;

                // Instancio el servicio
                articuloAModificar = articuloServices.Update(articuloAModificar);
                if (articuloAModificar.HuboError == false)
                {
                    MessageBox.Show(articuloAModificar.Mensaje, "Operación Exitosa");
                    this.Close();
                }
                else
                {
                    MessageBox.Show(articuloAModificar.Mensaje, "Cuidado!");
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"Verifique si el campo id esta vacio y/o los campos Minimo Stock o Cantidad poseen caracteres no numericos", "Cuidado!");
            }
        }


        /************** 
         * BOTONES 
         **************/
        /// <summary>
        ///     El boton Agrega o modifica segun sea de 
        ///     donde se llame al Formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnGuardarArticulo_Click(object sender, EventArgs e)
        {
            if (EstoyModificando == true)
            {
                ModificarArticulo();
            }
            else
            {
                AgregarArticulo();
            }
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
