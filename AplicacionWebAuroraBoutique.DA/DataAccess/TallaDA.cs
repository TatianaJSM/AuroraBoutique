using Npgsql;
using AplicacionWebAuroraBoutique.Modelo;

namespace AplicacionWebAuroraBoutique.DA.DataAccess;

public class TallaDA
{
    public IEnumerable<Talla> Listar()
    {
        const string sql = "SELECT id_talla, descripcion FROM auroraschema.talla";
        var lista = new List<Talla>();

        try
        {
            using var conn = PostgresConnectionFactory.Create();
            conn.Open();
            using var cmd = new NpgsqlCommand(sql, conn);
            using var dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                lista.Add(new Talla
                {
                    IdTalla = dr.GetInt32(0),
                    Descripcion = dr.GetString(1)
                });
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[TallaDA.Listar] {ex.Message}");
        }

        return lista;
    }
}
