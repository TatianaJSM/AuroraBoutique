using Npgsql;
using AplicacionWebAuroraBoutique.Modelo;
using System;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.DA.DataAccess
{
    public class TallaDA
    {
        public void Insertar(Talla t)
        {
            const string sql = "CALL auroraschema.sp_insert_talla(@p_descripcion)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@p_descripcion", t.Descripcion);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[TallaDA.Insertar] {ex.Message}");
            }
        }

        public void Modificar(Talla t)
        {
            const string sql = "CALL auroraschema.sp_update_talla(@p_id, @p_descripcion)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@p_id", t.IdTalla);
                cmd.Parameters.AddWithValue("@p_descripcion", t.Descripcion);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[TallaDA.Modificar] {ex.Message}");
            }
        }

        public void Eliminar(int idTalla)
        {
            const string sql = "CALL auroraschema.sp_delete_talla(@p_id)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@p_id", idTalla);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[TallaDA.Eliminar] {ex.Message}");
            }
        }

        public IEnumerable<Talla> Listar()
        {
            const string sql = "SELECT * FROM auroraschema.fn_list_talla()";
            var lista = new List<Talla>();

            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                using var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new Talla
                    {
                        IdTalla = dr.GetInt32(0),
                        Descripcion = dr.GetString(1)
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[TallaDA.Listar] {ex.Message}");
            }

            return lista;
        }
    }
}
