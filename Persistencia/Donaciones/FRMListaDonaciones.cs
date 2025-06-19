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

namespace ExamenProyectos.Persistencia.Donaciones
{
    public partial class FRMListaDonaciones : Form
    {
        private Aplicacion.DonacionService _donacionService = new Aplicacion.DonacionService();
        private List<DonacionDTO> _listaDonaciones;

        public FRMListaDonaciones()
        {
            InitializeComponent();
            this.Load += FRMListaDonaciones_Load;  // Suscribir evento Load
        }

        private void FRMListaDonaciones_Load(object sender, EventArgs e)
        {
            CargarLista();
        }

        private void CargarLista()
        {
            _listaDonaciones = _donacionService.todos();
            dgvListaDonaciones.DataSource = null;
            dgvListaDonaciones.DataSource = _listaDonaciones;

            // Opcionalmente: renombrar columnas para una mejor presentación
            dgvListaDonaciones.Columns["IdDonacion"].HeaderText = "ID";
            dgvListaDonaciones.Columns["IdDonante"].HeaderText = "Donante";
            dgvListaDonaciones.Columns["IdProyecto"].HeaderText = "Proyecto";
            dgvListaDonaciones.Columns["Monto"].HeaderText = "Monto ($)";
            dgvListaDonaciones.Columns["FechaDonacion"].HeaderText = "Fecha";
            dgvListaDonaciones.Columns["MetodoPago"].HeaderText = "Método de Pago";
            dgvListaDonaciones.Columns["Comentario"].HeaderText = "Comentario";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim().ToLower();

            var resultado = _listaDonaciones
                .Where(d => d.Comentario != null && d.Comentario.ToLower().Contains(filtro))
                .ToList();

            dgvListaDonaciones.DataSource = null;
            dgvListaDonaciones.DataSource = resultado;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            CargarLista();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            var frm = new FRMNuevaDonacion();
            frm.ShowDialog();
            CargarLista();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvListaDonaciones.CurrentRow != null)
            {
                DonacionDTO seleccionada = (DonacionDTO)dgvListaDonaciones.CurrentRow.DataBoundItem;
                var frm = new FRMEditarDonacion(seleccionada);
                frm.ShowDialog();
                CargarLista();
            }
            else
            {
                MessageBox.Show("Seleccione una donación para editar.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvListaDonaciones.CurrentRow != null)
            {
                DonacionDTO seleccionada = (DonacionDTO)dgvListaDonaciones.CurrentRow.DataBoundItem;

                var confirmacion = MessageBox.Show("¿Está seguro de eliminar esta donación?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmacion == DialogResult.Yes)
                {
                    string resultado = _donacionService.eliminar(seleccionada.IdDonacion);
                    if (resultado == "ok")
                    {
                        MessageBox.Show("Donación eliminada con éxito.");
                        CargarLista();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar la donación.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione una donación para eliminar.");
            }
        }
    }
}