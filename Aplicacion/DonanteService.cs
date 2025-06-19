using ExamenProyectos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenProyectos.Aplicacion
{
    class DonanteService
    {
        private readonly AccesoDatos.DonanteDAO _donanteDAO = new AccesoDatos.DonanteDAO();

        public List<Datos.DonanteDTO> todos()
        {
            return _donanteDAO.todos();
        }

        public string insertar(Datos.DonanteDTO donanteDTO)
        {
            return _donanteDAO.insertar(donanteDTO);
        }

        public string eliminar(int idDonacion)
        {
            return _donanteDAO.eliminar(idDonacion);
        }
        public string actualizar(DonanteDTO donanteDTO)
        {
            return _donanteDAO.actualizar(donanteDTO);
        }
    }
}
