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
    public partial class ArticulosABM : Form
    {
        /*************** 
         * ATRIBUTOS 
         ***************/
        public bool EstoyModificando { get; set; }

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
            InitializeComponent();
            EstoyModificando = true;
            CargarDatosArticuloParaModificar(idArticuloAModificar);
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
            ArticulosRepository articuloAux = new ArticulosRepository();
            //Articulo articuloAux = new Articulo();
            Articulo articuloEnDb = articuloAux.GetArticuloById(idArticuloAModificar);

            //txtId.Text = articuloEnDb.ToString();
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
            Articulo articuloAGuardar = new Articulo();
            articuloAGuardar.Nombre = txtNombre.Text;
            articuloAGuardar.Marca = txtMarca.Text;
            articuloAGuardar.MinimoStock = Convert.ToDecimal(txtMinimoStock.Text);
            articuloAGuardar.Proveedor = txtProveedor.Text;
            articuloAGuardar.Precio = Convert.ToDecimal(txtPrecio.Text);
            articuloAGuardar.Codigo = txtCodigo.Text;

            // Instancio el servicio
            ArticuloServices articuloServices = new ArticuloServices();
            string mensaje = articuloServices.AgregarArticulo(articuloAGuardar);
            if (mensaje == "Articulo Agregado con Exito")
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
        ///     Modifica los datos del articulo pasado
        ///     segun los textBox del formulario
        /// </summary>
        private void ModificarArticulo()
        {
            Articulo articuloAModificar = new Articulo();
            Articulo articuloAux = new Articulo();

            articuloAModificar.Id = Convert.ToInt32(txtId.Text);
            articuloAModificar.Nombre = txtNombre.Text;
            articuloAModificar.Marca = txtMarca.Text;
            articuloAModificar.MinimoStock = Convert.ToDecimal(txtMinimoStock.Text);
            articuloAModificar.Proveedor = txtProveedor.Text;
            articuloAModificar.Precio = Convert.ToDecimal(txtPrecio.Text);
            articuloAModificar.Codigo = txtCodigo.Text;

            // Instancio el servicio
            ArticuloServices articuloServices = new ArticuloServices();
            string mensaje = articuloServices.ModificarArticulo(articuloAModificar);
            if (mensaje == "El Articulo fue modificado con exito")
            {
                MessageBox.Show("El Articulo fue modificado con exito", "Operación Exitosa");
                this.Close();
            }
            else
            {
                MessageBox.Show(mensaje, "Hubo un problema");
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
