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
            Deposito depositoAux = new Deposito();
            Deposito depositoEnDb = depositoAux.GetDepositoPorId(idDepositoAModificar);

            //txtId.Text = articuloEnDb.ToString();
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
            Deposito depositoAGuardar = new Deposito();

            depositoAGuardar.Capacidad = Convert.ToDecimal(txtCapacidad.Text);
            depositoAGuardar.Nombre = txtNombre.Text;
            depositoAGuardar.Direccion = txtDireccion.Text;

            if (depositoAGuardar.AgregarEnDb() == 1)
            {
                MessageBox.Show("Deposito agregado con Exito.", "Operación Exitosa");
                this.Close();
            }
            else
            {
                MessageBox.Show("No se pudo agregar el Deposito.", "Hubo un problema");
            }
        }

        /// <summary>
        ///     Modifica los datos del deposito pasado
        ///     segun los textBox del formulario
        /// </summary>
        private void ModificarDeposito()
        {
            Deposito depositoAModificar = new Deposito();
            Deposito depositoAux = new Deposito();

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
