using Npgsql;
using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.DA.DataAccess
{
    public class DistritoDA
    {
        public void Insertar(Distrito distrito)
        {
            const string sql = "CALL auroraschema.sp_insert_distrito(@p_canton, @p_nombre)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@p_canton", distrito.IdCanton);
                cmd.Parameters.AddWithValue("@p_nombre", distrito.Nombre);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DistritoDA.Insertar] {ex.Message}");
            }
        }

        public void Modificar(Distrito distrito)
        {
            const string sql = "CALL auroraschema.sp_update_distrito(@p_distrito, @p_canton, @p_nombre)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@p_distrito", distrito.IdDistrito);
                cmd.Parameters.AddWithValue("@p_canton", distrito.IdCanton);
                cmd.Parameters.AddWithValue("@p_nombre", distrito.Nombre);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DistritoDA.Modificar] {ex.Message}");
            }
        }

        public void Eliminar(int idDistrito)
        {
            const string sql = "CALL auroraschema.sp_delete_distrito(@p_distrito)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@p_distrito", idDistrito);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DistritoDA.Eliminar] {ex.Message}");
            }
        }

        public IEnumerable<Distrito> Listar()
        {
            const string sql = "SELECT * FROM auroraschema.fn_listar_distrito()";
            var lista = new List<Distrito>();

            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                using var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new Distrito
                    {
                        IdDistrito = dr.GetInt32(0),
                        IdCanton = dr.GetInt32(1),
                        Nombre = dr.GetString(2)
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DistritoDA.Listar] {ex.Message}");
            }

            return lista;
        }
    }
}
