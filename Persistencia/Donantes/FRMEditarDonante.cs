using ExamenProyectos.AccesoDatos;
using ExamenProyectos.Aplicacion;
using ExamenProyectos.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamenProyectos.Persistencia.Donantes
{
    public partial class FRMEditarDonante : Form
    {
        private DonanteService _donanteService = new DonanteService();
        private DonanteDTO _donanteActual;

        public FRMEditarDonante(DonanteDTO donante)
        {
            InitializeComponent();
            _donanteActual = donante;
        }

        private void FRMEditarDonante_Load(object sender, EventArgs e)
        {
            cmbTipo.Items.Clear();
            cmbTipo.Items.AddRange(new string[] { "Individual", "Empresa", "Anónimo" });

            if (_donanteActual != null)
            {
                txtNombre.Text = _donanteActual.Nombre;
                txtCorreo.Text = _donanteActual.Correo;
                txtTelefono.Text = _donanteActual.Telefono;
                txtDireccion.Text = _donanteActual.Direccion;
                cmbTipo.SelectedItem = _donanteActual.TipoDonante;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || cmbTipo.SelectedIndex == -1)
            {
                MessageBox.Show("Complete los campos requeridos.");
                return;
            }

            _donanteActual.Nombre = txtNombre.Text.Trim();
            _donanteActual.Correo = txtCorreo.Text.Trim();
            _donanteActual.Telefono = txtTelefono.Text.Trim();
            _donanteActual.Direccion = txtDireccion.Text.Trim();
            _donanteActual.TipoDonante = cmbTipo.SelectedItem.ToString();

            string resultado = _donanteService.actualizar(_donanteActual);

            if (resultado == "ok")
            {
                MessageBox.Show("Donante actualizado correctamente.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al actualizar el donante.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
