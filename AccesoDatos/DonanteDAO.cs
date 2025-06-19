using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamenProyectos.Datos;
using MySql.Data.MySqlClient;

namespace ExamenProyectos.AccesoDatos
{
    public class DonanteDAO
    {
        private Conexion _conexion = new Conexion();

        internal List<DonanteDTO> todos()
        {
            List<DonanteDTO> listaDonantes = new List<DonanteDTO>();
            using (MySqlConnection cn = _conexion.AbrirConexion())
            {
                string cadena = "SELECT * FROM donantes";
                using (MySqlCommand cmd = new MySqlCommand(cadena, cn))
                {
                    using (MySqlDataReader lector = cmd.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            DonanteDTO donante = new DonanteDTO
                            {
                                DonanteId = lector.GetInt32("id_donante"),
                                Nombre = lector.GetString("nombre"),
                                Correo = lector.GetString("correo"),
                                Direccion = lector.GetString("direccion"),
                                Telefono = lector.GetString("telefono"),
                                TipoDonante = lector.GetString("tipo_donante")
                            };
                            listaDonantes.Add(donante);
                        }
                    }
                }
            }
            return listaDonantes;
        }

        internal string insertar(DonanteDTO donanteDTO)
        {
            using (MySqlConnection cn = _conexion.AbrirConexion())
            {
                string cadena = @"INSERT INTO donantes (nombre, correo, direccion, telefono, tipo_donante) 
                                  VALUES (@nombre, @correo, @direccion, @telefono, @tipo_donante)";
                using (MySqlCommand cmd = new MySqlCommand(cadena, cn))
                {
                    cmd.Parameters.AddWithValue("@nombre", donanteDTO.Nombre);
                    cmd.Parameters.AddWithValue("@correo", donanteDTO.Correo);
                    cmd.Parameters.AddWithValue("@direccion", donanteDTO.Direccion);
                    cmd.Parameters.AddWithValue("@telefono", donanteDTO.Telefono);
                    cmd.Parameters.AddWithValue("@tipo_donante", donanteDTO.TipoDonante);

                    int filasAfectadas = cmd.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                        return "ok";
                    else
                        return "error";
                }
            }
        }

        internal string eliminar(int donanteId)
        {
            using (MySqlConnection cn = _conexion.AbrirConexion())
            {
                string cadena = "DELETE FROM donantes WHERE DonanteId = @DonanteId";
                using (MySqlCommand cmd = new MySqlCommand(cadena, cn))
                {
                    cmd.Parameters.AddWithValue("@DonanteId", donanteId);
                    int filasAfectadas = cmd.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                        return "ok";
                    else
                        return "error";
                }
            }
        }

        internal string actualizar(DonanteDTO donanteDTO)
        {
            using (MySqlConnection cn = _conexion.AbrirConexion())
            {
                string sql = @"UPDATE donantes SET 
                        nombre = @nombre, 
                        correo = @correo, 
                        telefono = @telefono, 
                        direccion = @direccion, 
                        tipo_donante = @tipo
                       WHERE id_donante = @id";

                MySqlCommand cmd = new MySqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@nombre", donanteDTO.Nombre);
                cmd.Parameters.AddWithValue("@correo", donanteDTO.Correo);
                cmd.Parameters.AddWithValue("@telefono", donanteDTO.Telefono);
                cmd.Parameters.AddWithValue("@direccion", donanteDTO.Direccion);
                cmd.Parameters.AddWithValue("@tipo", donanteDTO.TipoDonante);
                cmd.Parameters.AddWithValue("@id", donanteDTO.DonanteId);

                int result = cmd.ExecuteNonQuery();
                return result > 0 ? "ok" : "error";
            }
        }
    }
}