using Npgsql;
using AplicacionWebAuroraBoutique.Modelo;

namespace AplicacionWebAuroraBoutique.DA.DataAccess;

public class PedidoPersonalEnvioDA
{
    public void Insertar(PedidoPersonalEnvio p)
    {
        const string sql = "CALL auroraschema.sp_insert_pedido_personalenvio(@p_idPedido, @p_idPersonalEnvio, @p_idTipoFecha)";
        try
        {
            using var conn = PostgresConnectionFactory.Create();
            conn.Open();
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@p_idPedido", p.IdPedido);
            cmd.Parameters.AddWithValue("@p_idPersonalEnvio", p.IdPersonalEnvio);
            cmd.Parameters.AddWithValue("@p_idTipoFecha", p.IdTipoFecha);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[PedidoPersonalEnvioDA.Insertar] {ex.Message}");
        }
    }
}
