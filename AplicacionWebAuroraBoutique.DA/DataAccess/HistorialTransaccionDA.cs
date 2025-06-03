using Npgsql;
using AplicacionWebAuroraBoutique.Modelo;

namespace AplicacionWebAuroraBoutique.DA.DataAccess;

public class HistorialTransaccionDA
{
    public void Insertar(HistorialTransaccion h)
    {
        const string sql = "CALL auroraschema.sp_insert_historial_transaccion(@p_idPedido, @p_idMetodoPago, @p_monto, @p_idTipoFecha)";
        try
        {
            using var conn = PostgresConnectionFactory.Create();
            conn.Open();
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@p_idPedido", h.IdPedido);
            cmd.Parameters.AddWithValue("@p_idMetodoPago", h.IdMetodoPago);
            cmd.Parameters.AddWithValue("@p_monto", h.Monto);
            cmd.Parameters.AddWithValue("@p_idTipoFecha", h.IdTipoFecha);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[HistorialTransaccionDA.Insertar] {ex.Message}");
        }
    }
}
