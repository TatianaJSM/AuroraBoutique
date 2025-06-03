using AplicacionWebAuroraBoutique.Modelo;
using Npgsql;
using System;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.DA.DataAccess
{
    public class LogEventoDA
    {
        public void Insertar(LogEvento log)
        {
            const string sql = "CALL auroraschema.sp_insert_log_evento(@p_tipo, @p_desc, @p_fecha, @p_id_cliente, @p_id_admin, @p_id_personal)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@p_tipo", log.TipoEvento);
                cmd.Parameters.AddWithValue("@p_desc", log.Descripcion);
                cmd.Parameters.AddWithValue("@p_fecha", log.FechaEvento);
                cmd.Parameters.AddWithValue("@p_id_cliente", log.IdCliente.HasValue ? log.IdCliente.Value : (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@p_id_admin", log.IdAdministrador.HasValue ? log.IdAdministrador.Value : (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@p_id_personal", log.IdPersonalEnvio.HasValue ? log.IdPersonalEnvio.Value : (object)DBNull.Value);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[LogEventoDA.Insertar] {ex.Message}");
            }
        }

        public void Modificar(LogEvento log)
        {
            const string sql = "CALL auroraschema.sp_update_log_evento(@p_idlog, @p_tipo, @p_desc, @p_fecha, @p_id_cliente, @p_id_admin, @p_id_personal)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@p_idlog", log.IdLog);
                cmd.Parameters.AddWithValue("@p_tipo", log.TipoEvento);
                cmd.Parameters.AddWithValue("@p_desc", log.Descripcion);
                cmd.Parameters.AddWithValue("@p_fecha", log.FechaEvento);
                cmd.Parameters.AddWithValue("@p_id_cliente", log.IdCliente.HasValue ? log.IdCliente.Value : (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@p_id_admin", log.IdAdministrador.HasValue ? log.IdAdministrador.Value : (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@p_id_personal", log.IdPersonalEnvio.HasValue ? log.IdPersonalEnvio.Value : (object)DBNull.Value);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[LogEventoDA.Modificar] {ex.Message}");
            }
        }

        public void Eliminar(int idLog)
        {
            const string sql = "CALL auroraschema.sp_delete_log_evento(@p_idlog)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@p_idlog", idLog);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[LogEventoDA.Eliminar] {ex.Message}");
            }
        }

        public IEnumerable<LogEvento> Listar()
        {
            const string sql = "SELECT * FROM auroraschema.fn_listar_log_evento()";
            var lista = new List<LogEvento>();

            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                using var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new LogEvento
                    {
                        IdLog = dr.GetInt32(0),
                        TipoEvento = dr.GetString(1),
                        Descripcion = dr.GetString(2),
                        FechaEvento = dr.GetDateTime(3),
                        IdCliente = dr.IsDBNull(4) ? null : dr.GetInt32(4),
                        IdAdministrador = dr.IsDBNull(5) ? null : dr.GetInt32(5),
                        IdPersonalEnvio = dr.IsDBNull(6) ? null : dr.GetInt32(6)
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[LogEventoDA.Listar] {ex.Message}");
            }

            return lista;
        }
    }
}
