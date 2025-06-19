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
    public partial class FRMNuevoDonante : Form
    {
        private DonanteService _donanteService = new DonanteService();

        public FRMNuevoDonante()
        {
            InitializeComponent();
        }

        private void FRMNuevoDonante_Load(object sender, EventArgs e)
        {
            cmbTipo.Items.Clear();
            cmbTipo.Items.AddRange(new string[] { "Individual", "Empresa", "Anónimo" });
            cmbTipo.SelectedIndex = 0;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validación básica
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || cmbTipo.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, complete los campos requeridos.");
                return;
            }

            DonanteDTO nuevo = new DonanteDTO
            {
                Nombre = txtNombre.Text.Trim(),
                Correo = txtCorreo.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                Direccion = txtDireccion.Text.Trim(),
                TipoDonante = cmbTipo.SelectedItem.ToString()
            };

            string resultado = _donanteService.insertar(nuevo);

            if (resultado == "ok")
            {
                MessageBox.Show("Donante registrado exitosamente.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al registrar el donante.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}