using Npgsql;
using AplicacionWebAuroraBoutique.Modelo;

namespace AplicacionWebAuroraBoutique.DA.DataAccess;

public class ProductoColorDA
{
    public void Insertar(ProductoColor pc)
    {
        const string sql = "CALL auroraschema.sp_insert_producto_color(@p_idProducto, @p_idColor)";
        try
        {
            using var conn = PostgresConnectionFactory.Create();
            conn.Open();
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@p_idProducto", pc.IdProducto);
            cmd.Parameters.AddWithValue("@p_idColor", pc.IdColor);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ProductoColorDA.Insertar] {ex.Message}");
        }
    }
}
