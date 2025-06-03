using AplicacionWebAuroraBoutique.Modelo;
using Npgsql;

namespace AplicacionWebAuroraBoutique.DA.DataAccess;

public class LogEventoDA
{
    public void Insertar(LogEvento log)
    {
        const string sql = @"CALL auroraschema.sp_insert_log_evento(@p_tipo, @p_desc, @p_fecha, @p_id_cliente, @p_id_admin, @p_id_personal)";

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
}

