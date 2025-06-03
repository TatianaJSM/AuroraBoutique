using Npgsql;
using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.DA.DataAccess
{
    public class EstadoDA
    {
        public void Insertar(Estado estado)
        {
            const string sql = "CALL auroraschema.sp_insert_estado(@p_nombre, @p_descripcion)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@p_nombre", estado.Nombre);
                cmd.Parameters.AddWithValue("@p_descripcion", estado.Descripcion);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[EstadoDA.Insertar] {ex.Message}");
            }
        }

        public void Modificar(Estado estado)
        {
            const string sql = "CALL auroraschema.sp_update_estado(@p_estado, @p_nombre, @p_descripcion)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@p_estado", estado.IdEstado);
                cmd.Parameters.AddWithValue("@p_nombre", estado.Nombre);
                cmd.Parameters.AddWithValue("@p_descripcion", estado.Descripcion);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[EstadoDA.Modificar] {ex.Message}");
            }
        }

        public void Eliminar(int idEstado)
        {
            const string sql = "CALL auroraschema.sp_delete_estado(@p_estado)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@p_estado", idEstado);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[EstadoDA.Eliminar] {ex.Message}");
            }
        }

        public IEnumerable<Estado> Listar()
        {
            const string sql = "SELECT * FROM auroraschema.fn_listar_estado()";
            var lista = new List<Estado>();

            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                using var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new Estado
                    {
                        IdEstado = dr.GetInt32(0),
                        Nombre = dr.GetString(1),
                        Descripcion = dr.GetString(2)
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[EstadoDA.Listar] {ex.Message}");
            }

            return lista;
        }
    }
}
