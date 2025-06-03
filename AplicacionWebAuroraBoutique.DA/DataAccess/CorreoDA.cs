using Npgsql;
using AplicacionWebAuroraBoutique.Modelo;
using System;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.DA.DataAccess
{
    public class CorreoDA
    {
        public void Insertar(Correo correo)
        {
            const string sql = "CALL auroraschema.sp_insert_correo(@p_id_cliente, @p_email)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@p_id_cliente", correo.IdCliente);
                cmd.Parameters.AddWithValue("@p_email", correo.Email);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[CorreoDA.Insertar] {ex.Message}");
            }
        }

        public void Modificar(Correo correo)
        {
            const string sql = "CALL auroraschema.sp_update_correo(@p_id_correo, @p_id_cliente, @p_email)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@p_id_correo", correo.IdCorreo);
                cmd.Parameters.AddWithValue("@p_id_cliente", correo.IdCliente);
                cmd.Parameters.AddWithValue("@p_email", correo.Email);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[CorreoDA.Modificar] {ex.Message}");
            }
        }

        public void Eliminar(int idCorreo)
        {
            const string sql = "CALL auroraschema.sp_delete_correo(@p_id_correo)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@p_id_correo", idCorreo);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[CorreoDA.Eliminar] {ex.Message}");
            }
        }

        public IEnumerable<Correo> Listar()
        {
            const string sql = "SELECT * FROM auroraschema.fn_listar_correos()";
            var lista = new List<Correo>();

            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                using var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new Correo
                    {
                        IdCorreo = dr.GetInt32(0),
                        IdCliente = dr.GetInt32(1),
                        Email = dr.GetString(2)
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[CorreoDA.Listar] {ex.Message}");
            }

            return lista;
        }
    }
}
