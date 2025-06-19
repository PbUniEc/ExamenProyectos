using ExamenProyectos.AccesoDatos;
using ExamenProyectos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenProyectos.Aplicacion
{
    class DonacionService
    {
        private readonly DonacionDAO _donacionDAO = new DonacionDAO();

        public List<DonacionDTO> todos()
        {
            return _donacionDAO.todos();
        }

        public string insertar(DonacionDTO donacionDTO)
        {
            return _donacionDAO.insertar(donacionDTO);
        }

        public string eliminar(int idDonacion)
        {
            return _donacionDAO.eliminar(idDonacion);
        }

        public string actualizar(DonacionDTO donacionDTO)
        {
            return _donacionDAO.actualizar(donacionDTO);
        }
    }
}