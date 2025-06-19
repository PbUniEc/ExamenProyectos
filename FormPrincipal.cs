using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExamenProyectos.Persistencia.Donantes;
using ExamenProyectos.Persistencia.Proyectos;
using ExamenProyectos.Persistencia.Donaciones;

namespace ExamenProyectos
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {

        }

        // Botón: Gestionar Donantes
        private void btnDonantes_Click(object sender, EventArgs e)
        {
            FRMListaDonantes frm = new FRMListaDonantes();
            frm.ShowDialog();
        }

        // Botón: Gestionar Proyectos
        private void btnProyectos_Click(object sender, EventArgs e)
        {
            FRMListaProyectos frm = new FRMListaProyectos();
            frm.ShowDialog();
        }

        // Botón: Registrar Donaciones
        private void btnDonaciones_Click(object sender, EventArgs e)
        {
            FRMListaDonaciones frm = new FRMListaDonaciones();
            frm.ShowDialog();
        }

        // Botón: Ver Donaciones
        private void btnListaDon_Click(object sender, EventArgs e)
        {
            FRMListaDonaciones frm = new FRMListaDonaciones();
            frm.ShowDialog();
        }

        // Botón: Salir
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
