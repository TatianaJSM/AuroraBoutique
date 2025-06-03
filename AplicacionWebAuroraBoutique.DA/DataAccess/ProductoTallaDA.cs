using AplicacionWebAuroraBoutique.Modelo;
using Npgsql;

namespace AplicacionWebAuroraBoutique.DA.DataAccess;

public class ProductoTallaDA
{
    public IEnumerable<ProductoTalla> Listar()
    {
        const string sql = "SELECT id_producto, id_talla FROM auroraschema.producto_talla";
        var lista = new List<ProductoTalla>();

        try
        {
            using var conn = PostgresConnectionFactory.Create();
            conn.Open();
            using var cmd = new NpgsqlCommand(sql, conn);
            using var dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                lista.Add(new ProductoTalla
                {
                    IdProducto = dr.GetInt32(0),
                    IdTalla = dr.GetInt32(1)
                });
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ProductoTallaDA.Listar] {ex.Message}");
        }

        return lista;
    }
}
