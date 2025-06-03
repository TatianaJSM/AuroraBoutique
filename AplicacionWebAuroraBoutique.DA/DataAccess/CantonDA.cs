using Npgsql;
using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.DA.DataAccess
{
    public class CantonDA
    {
        public void Insertar(Canton canton)
        {
            const string sql = "CALL auroraschema.sp_insert_canton(@p_provincia, @p_nombre)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@p_provincia", canton.IdProvincia);
                cmd.Parameters.AddWithValue("@p_nombre", canton.Nombre);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[CantonDA.Insertar] {ex.Message}");
            }
        }

        public void Modificar(Canton canton)
        {
            const string sql = "CALL auroraschema.sp_update_canton(@p_canton, @p_provincia, @p_nombre)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@p_canton", canton.IdCanton);
                cmd.Parameters.AddWithValue("@p_provincia", canton.IdProvincia);
                cmd.Parameters.AddWithValue("@p_nombre", canton.Nombre);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[CantonDA.Modificar] {ex.Message}");
            }
        }

        public void Eliminar(int idCanton)
        {
            const string sql = "CALL auroraschema.sp_delete_canton(@p_canton)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@p_canton", idCanton);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[CantonDA.Eliminar] {ex.Message}");
            }
        }

        public IEnumerable<Canton> Listar()
        {
            const string sql = "SELECT * FROM auroraschema.fn_listar_cantones()";
            var lista = new List<Canton>();

            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                using var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new Canton
                    {
                        IdCanton = dr.GetInt32(0),
                        IdProvincia = dr.GetInt32(1),
                        Nombre = dr.GetString(2)
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[CantonDA.Listar] {ex.Message}");
            }

            return lista;
        }
    }
}

