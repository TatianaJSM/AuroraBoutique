using Npgsql;
using AplicacionWebAuroraBoutique.Modelo;

namespace AplicacionWebAuroraBoutique.DA.DataAccess;

public class CategoriaDA
{
    public IEnumerable<Categoria> Listar()
    {
        const string sql = "SELECT id_categoria, nombre FROM auroraschema.categoria";
        var lista = new List<Categoria>();

        try
        {
            using var conn = PostgresConnectionFactory.Create();
            conn.Open();
            using var cmd = new NpgsqlCommand(sql, conn);
            using var dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                lista.Add(new Categoria
                {
                    IdCategoria = dr.GetInt32(0),
                    Nombre = dr.GetString(1)
                });
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[CategoriaDA.Listar] {ex.Message}");
        }

        return lista;
    }
}
