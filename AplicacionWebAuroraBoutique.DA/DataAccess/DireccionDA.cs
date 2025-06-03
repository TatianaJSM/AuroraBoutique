using Npgsql;
using AplicacionWebAuroraBoutique.Modelo;

namespace AplicacionWebAuroraBoutique.DA.DataAccess;

public class DireccionDA
{
    public void Insertar(Direccion d)
    {
        const string sql = "CALL auroraschema.sp_insert_direccion(@p_idCliente, @p_idBarrio, @p_idDistrito, @p_idCanton, @p_idProvincia, @p_idPais)";
        try
        {
            using var conn = PostgresConnectionFactory.Create();
            conn.Open();
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@p_idCliente", d.IdCliente);
            cmd.Parameters.AddWithValue("@p_idBarrio", d.IdBarrio);
            cmd.Parameters.AddWithValue("@p_idDistrito", d.IdDistrito);
            cmd.Parameters.AddWithValue("@p_idCanton", d.IdCanton);
            cmd.Parameters.AddWithValue("@p_idProvincia", d.IdProvincia);
            cmd.Parameters.AddWithValue("@p_idPais", d.IdPais);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[DireccionDA.Insertar] {ex.Message}");
        }
    }
}
