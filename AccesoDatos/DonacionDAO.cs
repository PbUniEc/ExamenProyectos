using ExamenProyectos.Datos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenProyectos.AccesoDatos
{
    internal class DonacionDAO
    {
        private Conexion _conexion = new Conexion();

        internal List<DonacionDTO> todos()
        {
            List<DonacionDTO> listaDonaciones = new List<DonacionDTO>();
            using (MySqlConnection cn = _conexion.AbrirConexion())
            {
                string query = "SELECT id_donacion, id_donante, id_proyecto, monto, fecha_donacion, metodo_pago, comentario FROM donaciones";
                using (MySqlCommand cmd = new MySqlCommand(query, cn))
                {
                    using (MySqlDataReader lector = cmd.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            DonacionDTO donacion = new DonacionDTO
                            {
                                IdDonacion = lector.GetInt32("id_donacion"),
                                IdDonante = lector.GetInt32("id_donante"),
                                IdProyecto = lector.GetInt32("id_proyecto"),
                                Monto = lector.GetDecimal("monto"),
                                FechaDonacion = lector.GetDateTime("fecha_donacion"),
                                MetodoPago = lector.GetString("metodo_pago"),
                                Comentario = lector.IsDBNull(lector.GetOrdinal("comentario")) ? null : lector.GetString("comentario")
                            };
                            listaDonaciones.Add(donacion);
                        }
                    }
                }
            }
            return listaDonaciones;
        }

        internal string insertar(DonacionDTO donacionDTO)
        {
            using (MySqlConnection cn = _conexion.AbrirConexion())
            {
                string query = @"INSERT INTO donaciones (id_donante, id_proyecto, monto, fecha_donacion, metodo_pago, comentario) 
                                 VALUES (@id_donante, @id_proyecto, @monto, @fecha_donacion, @metodo_pago, @comentario)";
                using (MySqlCommand cmd = new MySqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@id_donante", donacionDTO.IdDonante);
                    cmd.Parameters.AddWithValue("@id_proyecto", donacionDTO.IdProyecto);
                    cmd.Parameters.AddWithValue("@monto", donacionDTO.Monto);
                    cmd.Parameters.AddWithValue("@fecha_donacion", donacionDTO.FechaDonacion);
                    cmd.Parameters.AddWithValue("@metodo_pago", donacionDTO.MetodoPago);
                    cmd.Parameters.AddWithValue("@comentario", (object)donacionDTO.Comentario ?? DBNull.Value);

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0 ? "ok" : "error";
                }
            }
        }

        internal string eliminar(int idDonacion)
        {
            using (MySqlConnection cn = _conexion.AbrirConexion())
            {
                string query = "DELETE FROM donaciones WHERE id_donacion = @id_donacion";
                using (MySqlCommand cmd = new MySqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@id_donacion", idDonacion);

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0 ? "ok" : "error";
                }
            }
        }
        internal string actualizar(DonacionDTO donacionDTO)
        {
            using (MySqlConnection cn = _conexion.AbrirConexion())
            {
                string query = @"UPDATE donaciones SET 
                                    id_donante = @id_donante, 
                                    id_proyecto = @id_proyecto, 
                                    monto = @monto, 
                                    fecha_donacion = @fecha_donacion, 
                                    metodo_pago = @metodo_pago, 
                                    comentario = @comentario
                                 WHERE id_donacion = @id_donacion";

                using (MySqlCommand cmd = new MySqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@id_donante", donacionDTO.IdDonante);
                    cmd.Parameters.AddWithValue("@id_proyecto", donacionDTO.IdProyecto);
                    cmd.Parameters.AddWithValue("@monto", donacionDTO.Monto);
                    cmd.Parameters.AddWithValue("@fecha_donacion", donacionDTO.FechaDonacion);
                    cmd.Parameters.AddWithValue("@metodo_pago", donacionDTO.MetodoPago);
                    cmd.Parameters.AddWithValue("@comentario", (object)donacionDTO.Comentario ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@id_donacion", donacionDTO.IdDonacion);

                    int filasAfectadas = cmd.ExecuteNonQuery();

                    return filasAfectadas > 0 ? "ok" : "error";
                }
            }
        }
    }
}