using ExamenProyectos.AccesoDatos;
using ExamenProyectos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenProyectos.Aplicacion
{
    public class ProyectoService
    {
        private readonly ProyectoDAO _proyectoDAO = new ProyectoDAO();

        public List<ProyectoDTO> todos()
        {
            return _proyectoDAO.todos();
        }

        public string insertar(ProyectoDTO proyectoDTO)
        {
            return _proyectoDAO.insertar(proyectoDTO);
        }

        public string eliminar(int idProyecto)
        {
            return _proyectoDAO.eliminar(idProyecto);
        }
        public string actualizar(ProyectoDTO proyectoDTO)
        {
            return _proyectoDAO.actualizar(proyectoDTO);
        }
    }
}