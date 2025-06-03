using AplicacionWebAuroraBoutique.Modelo;
using Npgsql;
using System;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.DA.DataAccess
{
    public class TelefonoDA
    {
        public void Insertar(Telefono telefono)
        {
            const string sql = "CALL auroraschema.sp_insert_telefono(@p_id_cliente, @p_numero)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@p_id_cliente", telefono.IdCliente);
                cmd.Parameters.AddWithValue("@p_numero", telefono.Numero);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[TelefonoDA.Insertar] {ex.Message}");
            }
        }

        public void Modificar(Telefono telefono)
        {
            const string sql = "CALL auroraschema.sp_update_telefono(@p_id_telefono, @p_id_cliente, @p_numero)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@p_id_telefono", telefono.IdTelefono);
                cmd.Parameters.AddWithValue("@p_id_cliente", telefono.IdCliente);
                cmd.Parameters.AddWithValue("@p_numero", telefono.Numero);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[TelefonoDA.Modificar] {ex.Message}");
            }
        }

        public void Eliminar(int idTelefono)
        {
            const string sql = "CALL auroraschema.sp_delete_telefono(@p_id_telefono)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@p_id_telefono", idTelefono);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[TelefonoDA.Eliminar] {ex.Message}");
            }
        }

        public IEnumerable<Telefono> Listar()
        {
            const string sql = "SELECT * FROM auroraschema.fn_listar_telefono()";
            var lista = new List<Telefono>();

            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                using var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new Telefono
                    {
                        IdTelefono = dr.GetInt32(0),
                        IdCliente = dr.GetInt32(1),
                        Numero = dr.GetString(2)
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[TelefonoDA.Listar] {ex.Message}");
            }

            return lista;
        }
    }
}
