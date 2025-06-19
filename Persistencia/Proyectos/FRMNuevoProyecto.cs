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
    public partial class FRMNuevoProyecto : Form
    {
        private ProyectoService _proyectoService = new ProyectoService();

        public FRMNuevoProyecto()
        {
            InitializeComponent();
        }

        private void FRMNuevoProyecto_Load(object sender, EventArgs e)
        {
            cmbEstado.Items.Clear();
            cmbEstado.Items.AddRange(new string[] { "En ejecución", "Finalizado", "Pendiente", "Cancelado" });
            cmbEstado.SelectedIndex = 0;

            dtpInicio.Value = DateTime.Now;
            dtpFin.Value = DateTime.Now;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || cmbEstado.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, complete los campos obligatorios.");
                return;
            }

            var nuevoProyecto = new ProyectoDTO
            {
                NombreProyecto = txtNombre.Text.Trim(),
                Descripcion = txtDescripcion.Text.Trim(),
                FechaInicio = dtpInicio.Value,
                FechaFin = dtpFin.Value,
                Estado = cmbEstado.SelectedItem.ToString()
            };

            string resultado = _proyectoService.insertar(nuevoProyecto);

            if (resultado == "ok")
            {
                MessageBox.Show("Proyecto guardado correctamente.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al guardar el proyecto.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}