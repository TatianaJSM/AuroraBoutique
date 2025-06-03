using Npgsql;
using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.DA.DataAccess
{
    public class ClienteDA
    {
        public void Insertar(Cliente c)
        {
            const string sql = "CALL auroraschema.sp_insert_cliente(@p_nombre,@p_ap1,@p_ap2)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();

                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@p_nombre", c.Nombre);
                cmd.Parameters.AddWithValue("@p_ap1", c.PrimerApellido);
                cmd.Parameters.AddWithValue("@p_ap2", c.SegundoApellido);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ClienteDA.Insertar] {ex.Message}");
            }
        }

        public void Modificar(Cliente c)
        {
            const string sql = "CALL auroraschema.sp_update_cliente(@p_id, @p_nombre, @p_ap1, @p_ap2)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();

                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@p_id", c.IdCliente);
                cmd.Parameters.AddWithValue("@p_nombre", c.Nombre);
                cmd.Parameters.AddWithValue("@p_ap1", c.PrimerApellido);
                cmd.Parameters.AddWithValue("@p_ap2", c.SegundoApellido);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ClienteDA.Modificar] {ex.Message}");
            }
        }

        public void Eliminar(int idCliente)
        {
            const string sql = "CALL auroraschema.sp_delete_cliente(@p_id)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();

                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@p_id", idCliente);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ClienteDA.Eliminar] {ex.Message}");
            }
        }

        public IEnumerable<Cliente> Listar()
        {
            const string sql = "SELECT * FROM auroraschema.fn_listar_clientes()";
            var lista = new List<Cliente>();

            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();

                using var cmd = new NpgsqlCommand(sql, conn);
                using var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new Cliente
                    {
                        IdCliente = dr.GetInt32(0),
                        Nombre = dr.GetString(1),
                        PrimerApellido = dr.GetString(2),
                        SegundoApellido = dr.GetString(3)
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ClienteDA.Listar] {ex.Message}");
            }

            return lista;
        }
    }
}
