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
    public partial class FRMEditarProyecto : Form
    {
        private ProyectoService _proyectoService = new ProyectoService();
        private ProyectoDTO _proyectoActual;

        public FRMEditarProyecto(ProyectoDTO proyecto)
        {
            InitializeComponent();
            _proyectoActual = proyecto;
        }

        private void FRMEditarProyecto_Load(object sender, EventArgs e)
        {
            cmbEstado.Items.Clear();
            cmbEstado.Items.AddRange(new string[] { "En ejecución", "Finalizado", "Pendiente", "Cancelado" });

            if (_proyectoActual != null)
            {
                txtNombre.Text = _proyectoActual.NombreProyecto;
                txtDescripcion.Text = _proyectoActual.Descripcion;
                dtpInicio.Value = _proyectoActual.FechaInicio;
                dtpFin.Value = _proyectoActual.FechaFin;
                cmbEstado.SelectedItem = _proyectoActual.Estado;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || cmbEstado.SelectedIndex == -1)
            {
                MessageBox.Show("Complete los campos requeridos.");
                return;
            }

            _proyectoActual.NombreProyecto = txtNombre.Text.Trim();
            _proyectoActual.Descripcion = txtDescripcion.Text.Trim();
            _proyectoActual.FechaInicio = dtpInicio.Value;
            _proyectoActual.FechaFin = dtpFin.Value;
            _proyectoActual.Estado = cmbEstado.SelectedItem.ToString();

            string resultado = _proyectoService.actualizar(_proyectoActual);

            if (resultado == "ok")
            {
                MessageBox.Show("Proyecto actualizado correctamente.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al actualizar el proyecto.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
