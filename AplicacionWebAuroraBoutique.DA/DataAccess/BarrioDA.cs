using Npgsql;
using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.DA.DataAccess
{
    public class BarrioDA
    {
        public void Insertar(Barrio barrio)
        {
            const string sql = "CALL auroraschema.sp_insert_barrio(@p_distrito, @p_nombre)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@p_distrito", barrio.IdDistrito);
                cmd.Parameters.AddWithValue("@p_nombre", barrio.Nombre);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[BarrioDA.Insertar] {ex.Message}");
            }
        }

        public void Modificar(Barrio barrio)
        {
            const string sql = "CALL auroraschema.sp_update_barrio(@p_barrio, @p_distrito, @p_nombre)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@p_barrio", barrio.IdBarrio);
                cmd.Parameters.AddWithValue("@p_distrito", barrio.IdDistrito);
                cmd.Parameters.AddWithValue("@p_nombre", barrio.Nombre);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[BarrioDA.Modificar] {ex.Message}");
            }
        }

        public void Eliminar(int idBarrio)
        {
            const string sql = "CALL auroraschema.sp_delete_barrio(@p_barrio)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@p_barrio", idBarrio);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[BarrioDA.Eliminar] {ex.Message}");
            }
        }

        public IEnumerable<Barrio> Listar()
        {
            const string sql = "SELECT * FROM auroraschema.fn_list_barrio()";
            var lista = new List<Barrio>();

            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                using var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new Barrio
                    {
                        IdBarrio = dr.GetInt32(0),
                        IdDistrito = dr.GetInt32(1),
                        Nombre = dr.GetString(2)
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[BarrioDA.Listar] {ex.Message}");
            }

            return lista;
        }
    }
}
