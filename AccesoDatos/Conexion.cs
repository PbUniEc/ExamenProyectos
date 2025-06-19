﻿using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace ExamenProyectos.AccesoDatos
{
        class Conexion
        {
            //sqlconnecction    Sirve para abrir o cerar la conexion a la base de datos
            private readonly string cadenaConexion =
                "server=localhost;database=examenproyectos;uid=root;pwd=;";
            private MySqlConnection conexion;

            public MySqlConnection AbrirConexion()
            {
                conexion = new MySqlConnection(cadenaConexion);
                conexion.Open();
                return conexion;
            }

            public void CerrarConexion()
            {
                if (conexion != null && conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

        }
    }
