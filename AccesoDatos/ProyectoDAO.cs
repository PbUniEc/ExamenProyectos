using ExamenProyectos.Datos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenProyectos.AccesoDatos
{
    internal class ProyectoDAO
    {
        private Conexion _conexion = new Conexion();

        internal List<ProyectoDTO> todos()
        {
            List<ProyectoDTO> listaProyectos = new List<ProyectoDTO>();
            using (MySqlConnection cn = _conexion.AbrirConexion())
            {
                string query = "SELECT id_proyecto, nombre_proyecto, descripcion, fecha_inicio, fecha_fin, estado FROM proyectos";
                using (MySqlCommand cmd = new MySqlCommand(query, cn))
                {
                    using (MySqlDataReader lector = cmd.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            ProyectoDTO proyecto = new ProyectoDTO
                            {
                                IdProyecto = lector.GetInt32("id_proyecto"),
                                NombreProyecto = lector.GetString("nombre_proyecto"),
                                Descripcion = lector.GetString("descripcion"),
                                FechaInicio = lector.GetDateTime("fecha_inicio"),
                                FechaFin = lector.GetDateTime("fecha_fin"),
                                Estado = lector.GetString("estado")
                            };
                            listaProyectos.Add(proyecto);
                        }
                    }
                }
            }
            return listaProyectos;
        }

        internal string insertar(ProyectoDTO proyectoDTO)
        {
            using (MySqlConnection cn = _conexion.AbrirConexion())
            {
                string query = @"INSERT INTO proyectos (nombre_proyecto, descripcion, fecha_inicio, fecha_fin, estado) 
                                 VALUES (@nombre_proyecto, @descripcion, @fecha_inicio, @fecha_fin, @estado)";
                using (MySqlCommand cmd = new MySqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@nombre_proyecto", proyectoDTO.NombreProyecto);
                    cmd.Parameters.AddWithValue("@descripcion", proyectoDTO.Descripcion);
                    cmd.Parameters.AddWithValue("@fecha_inicio", proyectoDTO.FechaInicio);
                    cmd.Parameters.AddWithValue("@fecha_fin", proyectoDTO.FechaFin);
                    cmd.Parameters.AddWithValue("@estado", proyectoDTO.Estado);

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0 ? "ok" : "error";
                }
            }
        }

        internal string eliminar(int idProyecto)
        {
            using (MySqlConnection cn = _conexion.AbrirConexion())
            {
                string query = "DELETE FROM proyectos WHERE id_proyecto = @id_proyecto";
                using (MySqlCommand cmd = new MySqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@id_proyecto", idProyecto);

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0 ? "ok" : "error";
                }
            }
        }

        internal string actualizar(ProyectoDTO proyectoDTO)
        {
            using (MySqlConnection cn = _conexion.AbrirConexion())
            {
                string sql = @"UPDATE proyectos SET 
                         nombre_proyecto = @nombre, 
                         descripcion = @descripcion, 
                         fecha_inicio = @inicio, 
                         fecha_fin = @fin, 
                         estado = @estado 
                       WHERE id_proyecto = @id";

                MySqlCommand cmd = new MySqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@nombre", proyectoDTO.NombreProyecto);
                cmd.Parameters.AddWithValue("@descripcion", proyectoDTO.Descripcion);
                cmd.Parameters.AddWithValue("@inicio", proyectoDTO.FechaInicio);
                cmd.Parameters.AddWithValue("@fin", proyectoDTO.FechaFin);
                cmd.Parameters.AddWithValue("@estado", proyectoDTO.Estado);
                cmd.Parameters.AddWithValue("@id", proyectoDTO.IdProyecto);

                int result = cmd.ExecuteNonQuery();
                return result > 0 ? "ok" : "error";
            }
        }
    }
}