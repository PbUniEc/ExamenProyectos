using ExamenProyectos.AccesoDatos;
using ExamenProyectos.Aplicacion;
using ExamenProyectos.Datos;
using ExamenProyectos.Persistencia.Donantes;
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
    public partial class FRMListaDonantes : Form
    {
        private DonanteService _donanteService = new DonanteService();
        private List<DonanteDTO> _listaDonantes;

        public FRMListaDonantes()
        {
            InitializeComponent();
        }

        private void FRMListaDonantes_Load(object sender, EventArgs e)
        {
            CargarLista();
        }

        private void CargarLista()
        {
            _listaDonantes = _donanteService.todos();
            dgvListaDonantes.DataSource = null;
            dgvListaDonantes.DataSource = _listaDonantes;

            dgvListaDonantes.Columns["DonanteId"].HeaderText = "ID";
            dgvListaDonantes.Columns["Nombre"].HeaderText = "Nombre";
            dgvListaDonantes.Columns["Correo"].HeaderText = "Correo";
            dgvListaDonantes.Columns["Telefono"].HeaderText = "Teléfono";
            dgvListaDonantes.Columns["Direccion"].HeaderText = "Dirección";
            dgvListaDonantes.Columns["TipoDonante"].HeaderText = "Tipo";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim().ToLower();
            var resultado = _listaDonantes
                .Where(d => d.Nombre != null && d.Nombre.ToLower().Contains(filtro))
                .ToList();

            dgvListaDonantes.DataSource = null;
            dgvListaDonantes.DataSource = resultado;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            CargarLista();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            var frm = new FRMNuevoDonante();
            frm.ShowDialog();
            CargarLista();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvListaDonantes.CurrentRow != null)
            {
                DonanteDTO seleccionado = (DonanteDTO)dgvListaDonantes.CurrentRow.DataBoundItem;
                var frm = new FRMEditarDonante(seleccionado);
                frm.ShowDialog();
                CargarLista();
            }
            else
            {
                MessageBox.Show("Seleccione un donante para editar.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvListaDonantes.CurrentRow != null)
            {
                DonanteDTO seleccionado = (DonanteDTO)dgvListaDonantes.CurrentRow.DataBoundItem;

                var confirm = MessageBox.Show("¿Desea eliminar este donante?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    string resultado = _donanteService.eliminar(seleccionado.DonanteId);
                    if (resultado == "ok")
                    {
                        MessageBox.Show("Donante eliminado con éxito.");
                        CargarLista();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el donante.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un donante para eliminar.");
            }
        }
    }
}