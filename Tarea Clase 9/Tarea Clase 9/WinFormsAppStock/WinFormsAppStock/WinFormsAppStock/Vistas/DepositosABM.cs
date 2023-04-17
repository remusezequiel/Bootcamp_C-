using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CodigoComun.Entities;
using CodigoComun.Modelo;
using CodigoComun.Negocio;

namespace WinFormsAppStock.Vistas
{
    public partial class DepositosABM : Form
    {
        /************** 
         * ATRIBUTOS 
         **************/
        public bool EstoyModificando { get; set; }


        /******************* 
        * CONSTRUCTORES 
        ********************/
        public DepositosABM()
        {
            InitializeComponent();
            EstoyModificando = false;
        }

        public DepositosABM(int idDepositoAModificar)
        {
            InitializeComponent();
            EstoyModificando = true;
            CargarDatosDepositoParaModificar(idDepositoAModificar);
        }

        /************ 
         * METODOS
         ************/
        /// <summary>
        ///     Carga los datos del deposito pedido en los textBox
        ///     del formulario
        /// </summary>
        /// <param name="idDepositoAModificar"></param>
        public void CargarDatosDepositoParaModificar(int idDepositoAModificar)
        {
            // Instancio un DepositoServices
            DepositoServices depositoServices = new DepositoServices();
            // Instancio un Deposito 
            CodigoComun.Entities.Deposito depositoEnDb = new CodigoComun.Entities.Deposito();
            
            // Guardo el deposito
            depositoEnDb = depositoServices.GetDeposito(idDepositoAModificar);
            
            txtId.Text = idDepositoAModificar.ToString();
            txtCapacidad.Text = depositoEnDb.Capacidad.ToString();
            txtNombre.Text = depositoEnDb.Nombre;
            txtDireccion.Text = depositoEnDb.Direccion;
        }

        /// <summary>
        ///     Agrega los datos del formulario 
        ///     a la base de datos
        /// </summary>
        private void AgregarDeposito()
        {
            DepositoServices depositoServices = new DepositoServices();
            CodigoComun.Entities.Deposito depositoAGuardar = new CodigoComun.Entities.Deposito();

            depositoAGuardar.Capacidad = Convert.ToDecimal(txtCapacidad.Text);
            depositoAGuardar.Nombre = txtNombre.Text;
            depositoAGuardar.Direccion = txtDireccion.Text;

            string mensaje = depositoServices.AddDeposito(depositoAGuardar);
            if (mensaje == "Deposito Agregado con exito")
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
        ///     Modifica los datos del deposito pasado
        ///     segun los textBox del formulario
        /// </summary>
        private void ModificarDeposito()
        {
            CodigoComun.Modelo.Deposito depositoAModificar = new CodigoComun.Modelo.Deposito();
            CodigoComun.Modelo.Deposito depositoAux = new CodigoComun.Modelo.Deposito();

            depositoAModificar.Id = Convert.ToInt32(txtId.Text);
            depositoAModificar.Capacidad = Convert.ToDecimal(txtCapacidad.Text);
            depositoAModificar.Nombre = txtNombre.Text;
            depositoAModificar.Direccion = txtDireccion.Text;

            if (depositoAux.ActualizarEnDb(depositoAModificar) == 1)
            {
                MessageBox.Show("Deposito Modificado con Exito.", "Operación Exitosa");
                this.Close();
            }
            else
            {
                MessageBox.Show("No se pudo modificar el Deposito.", "Hubo un problema");
            }
        }

        /************ 
         * BOTONES 
         ************/
        /// <summary>
        ///     El boton agrega o modifica un deposito
        ///     segun de donde se ejecute ek formuladio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnGuardarDeposito_Click_1(object sender, EventArgs e)
        {
            if (EstoyModificando == true)
            {
                ModificarDeposito();
            }
            else
            {
                AgregarDeposito();
            }
        }


        

    }
}
