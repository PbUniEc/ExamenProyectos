using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenProyectos.Datos
{
    public class DonacionDTO
    {
        public int IdDonacion { get; set; }
        public int IdDonante { get; set; }
        public int IdProyecto { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaDonacion { get; set; }
        public string MetodoPago { get; set; }
        public string Comentario { get; set; }
    }
}