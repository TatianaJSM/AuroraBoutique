using AplicacionWebAuroraBoutique.Modelo;
using Npgsql;
using System;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.DA.DataAccess
{
    public class ColorDA
    {
        public void Insertar(Color color)
        {
            const string sql = "CALL auroraschema.sp_insert_color(@p_descripcion)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@p_descripcion", color.Descripcion);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ColorDA.Insertar] {ex}");
            }
        }

        public void Modificar(Color color)
        {
            const string sql = "CALL auroraschema.sp_update_color(@p_id, @p_descripcion)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@p_id", color.IdColor);
                cmd.Parameters.AddWithValue("@p_descripcion", color.Descripcion);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ColorDA.Modificar] {ex}");
            }
        }

        public void Eliminar(int idColor)
        {
            const string sql = "CALL auroraschema.sp_delete_color(@p_id)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@p_id", idColor);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ColorDA.Eliminar] {ex}");
            }
        }

        public IEnumerable<Color> Listar()
        {
            const string sql = "SELECT * FROM auroraschema.fn_listar_colores()";
            var lista = new List<Color>();

            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                using var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new Color
                    {
                        IdColor = dr.GetInt32(0),
                        Descripcion = dr.GetString(1)
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ColorDA.Listar] {ex}");
            }

            return lista;
        }
    }
}
