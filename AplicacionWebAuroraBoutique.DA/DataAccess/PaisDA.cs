using Npgsql;
using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.DA.DataAccess
{
    public class PaisDA
    {
        public void Insertar(Pais pais)
        {
            const string sql = "CALL auroraschema.sp_insert_pais(@p_nombre)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@p_nombre", pais.Nombre);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[PaisDA.Insertar] {ex.Message}");
            }
        }

        public void Modificar(Pais pais)
        {
            const string sql = "CALL auroraschema.sp_update_pais(@p_id, @p_nombre)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@p_id", pais.IdPais);
                cmd.Parameters.AddWithValue("@p_nombre", pais.Nombre);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[PaisDA.Modificar] {ex.Message}");
            }
        }

        public void Eliminar(int idPais)
        {
            const string sql = "CALL auroraschema.sp_delete_pais(@p_id)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@p_id", idPais);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[PaisDA.Eliminar] {ex.Message}");
            }
        }

        public IEnumerable<Pais> Listar()
        {
            const string sql = "SELECT * FROM auroraschema.fn_listar_pais()";
            var lista = new List<Pais>();

            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                using var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new Pais
                    {
                        IdPais = dr.GetInt32(0),
                        Nombre = dr.GetString(1)
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[PaisDA.Listar] {ex.Message}");
            }

            return lista;
        }
    }
}
