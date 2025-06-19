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

namespace ExamenProyectos.Persistencia.Proyectos
{
    public partial class FRMListaProyectos : Form
    {
        private ProyectoService _proyectoService = new ProyectoService();
        private List<ProyectoDTO> _listaProyectos;

        public FRMListaProyectos()
        {
            InitializeComponent();
        }

        private void FRMListaProyectos_Load(object sender, EventArgs e)
        {
            CargarLista();
        }

        private void CargarLista()
        {
            _listaProyectos = _proyectoService.todos();
            dgvListaProyectos.DataSource = null;
            dgvListaProyectos.DataSource = _listaProyectos;

            dgvListaProyectos.Columns["IdProyecto"].HeaderText = "ID";
            dgvListaProyectos.Columns["NombreProyecto"].HeaderText = "Nombre";
            dgvListaProyectos.Columns["Descripcion"].HeaderText = "Descripción";
            dgvListaProyectos.Columns["FechaInicio"].HeaderText = "Inicio";
            dgvListaProyectos.Columns["FechaFin"].HeaderText = "Fin";
            dgvListaProyectos.Columns["Estado"].HeaderText = "Estado";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim().ToLower();
            var resultado = _listaProyectos
                .Where(p => p.NombreProyecto != null && p.NombreProyecto.ToLower().Contains(filtro))
                .ToList();

            dgvListaProyectos.DataSource = null;
            dgvListaProyectos.DataSource = resultado;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            CargarLista();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            var frm = new FRMNuevoProyecto();
            frm.ShowDialog();
            CargarLista();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvListaProyectos.CurrentRow != null)
            {
                ProyectoDTO seleccionado = (ProyectoDTO)dgvListaProyectos.CurrentRow.DataBoundItem;
                var frm = new FRMEditarProyecto(seleccionado);
                frm.ShowDialog();
                CargarLista();
            }
            else
            {
                MessageBox.Show("Seleccione un proyecto para editar.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvListaProyectos.CurrentRow != null)
            {
                ProyectoDTO seleccionado = (ProyectoDTO)dgvListaProyectos.CurrentRow.DataBoundItem;

                var confirmar = MessageBox.Show("¿Desea eliminar este proyecto?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmar == DialogResult.Yes)
                {
                    string resultado = _proyectoService.eliminar(seleccionado.IdProyecto);
                    if (resultado == "ok")
                    {
                        MessageBox.Show("Proyecto eliminado correctamente.");
                        CargarLista();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el proyecto.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un proyecto para eliminar.");
            }
        }
    }
}