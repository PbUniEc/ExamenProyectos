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
    public partial class FRMNuevaDonacion : Form
    {
        private Aplicacion.DonacionService _donacionService = new Aplicacion.DonacionService();
        private Aplicacion.DonanteService _donanteService = new Aplicacion.DonanteService();
        private Aplicacion.ProyectoService _proyectoService = new Aplicacion.ProyectoService();

        public FRMNuevaDonacion()
        {
            InitializeComponent();
            CargarDatosIniciales();
        }

        private void CargarDatosIniciales()
        {
            List<DonanteDTO> donantes = _donanteService.todos();
            cmbDonante.DataSource = donantes;
            cmbDonante.DisplayMember = "Nombre";   
            cmbDonante.ValueMember = "DonanteId";   

            List<ProyectoDTO> proyectos = _proyectoService.todos();
            cmbProyecto.DataSource = proyectos;
            cmbProyecto.DisplayMember = "NombreProyecto";
            cmbProyecto.ValueMember = "IdProyecto";

            cmbMetodoPago.Items.Clear();
            cmbMetodoPago.Items.AddRange(new string[] { "Efectivo", "Tarjeta", "Transferencia", "Cheque" });
            cmbMetodoPago.SelectedIndex = 0;

            dtpFecha.Value = DateTime.Now;
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

                var nuevaDonacion = new DonacionDTO
                {
                    IdDonante = (int)cmbDonante.SelectedValue,
                    IdProyecto = (int)cmbProyecto.SelectedValue,
                    Monto = monto,
                    FechaDonacion = dtpFecha.Value,
                    MetodoPago = cmbMetodoPago.SelectedItem.ToString(),
                    Comentario = txtDonacion.Text
                };

                string resultado = _donacionService.insertar(nuevaDonacion);

                if (resultado == "ok")
                {
                    MessageBox.Show("Donación guardada con éxito.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al guardar la donación.");
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