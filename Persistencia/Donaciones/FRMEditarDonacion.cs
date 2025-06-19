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

namespace ExamenProyectos.Persistencia.Donaciones
{
    public partial class FRMEditarDonacion : Form
    {
        private DonacionService _donacionService = new DonacionService();
        private DonanteService _donanteService = new DonanteService();
        private ProyectoService _proyectoService = new ProyectoService();

        private DonacionDTO _donacionActual;

        // Constructor que recibe la donación a editar
        public FRMEditarDonacion(DonacionDTO donacion)
        {
            InitializeComponent();
            _donacionActual = donacion;
        }

        private void FRMEditarDonacion_Load(object sender, EventArgs e)
        {
            CargarDatosIniciales();
            CargarDatosDonacion();
        }

        private void CargarDatosIniciales()
        {
            // Cargar donantes
            List<DonanteDTO> donantes = _donanteService.todos();
            cmbDonante.DataSource = donantes;
            cmbDonante.DisplayMember = "Nombre";
            cmbDonante.ValueMember = "DonanteId";

            // Cargar proyectos
            List<ProyectoDTO> proyectos = _proyectoService.todos();
            cmbProyecto.DataSource = proyectos;
            cmbProyecto.DisplayMember = "NombreProyecto";
            cmbProyecto.ValueMember = "IdProyecto";

            // Cargar métodos de pago
            cmbMetodoPago.Items.Clear();
            cmbMetodoPago.Items.AddRange(new string[] { "Efectivo", "Tarjeta", "Transferencia", "Cheque" });
        }

        private void CargarDatosDonacion()
        {
            if (_donacionActual != null)
            {
                cmbDonante.SelectedValue = _donacionActual.IdDonante;
                cmbProyecto.SelectedValue = _donacionActual.IdProyecto;
                txtMonto.Text = _donacionActual.Monto.ToString("F2");
                dtpFecha.Value = _donacionActual.FechaDonacion;
                cmbMetodoPago.SelectedItem = _donacionActual.MetodoPago;
                cmbDonacion.Text = _donacionActual.Comentario;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (decimal.TryParse(txtMonto.Text.Trim(), out decimal monto) == false)
                {
                    MessageBox.Show("Ingrese un monto válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (cmbDonante.SelectedValue == null || cmbProyecto.SelectedValue == null)
                {
                    MessageBox.Show("Seleccione un donante y un proyecto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Actualizar datos del objeto donacion
                _donacionActual.IdDonante = (int)cmbDonante.SelectedValue;
                _donacionActual.IdProyecto = (int)cmbProyecto.SelectedValue;
                _donacionActual.Monto = monto;
                _donacionActual.FechaDonacion = dtpFecha.Value;
                _donacionActual.MetodoPago = cmbMetodoPago.SelectedItem.ToString();
                _donacionActual.Comentario = cmbDonacion.Text;

                // Aquí debes implementar el método actualizar en DonacionService
                string resultado = _donacionService.actualizar(_donacionActual);

                if (resultado == "ok")
                {
                    MessageBox.Show("Donación actualizada con éxito.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al actualizar la donación.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}