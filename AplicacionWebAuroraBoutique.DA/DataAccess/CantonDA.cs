using Npgsql;
using AplicacionWebAuroraBoutique.Modelo;

namespace AplicacionWebAuroraBoutique.DA.DataAccess;

public class CantonDA
{
    public IEnumerable<Canton> Listar()
    {
        const string sql = "SELECT id_canton, id_provincia, nombre FROM auroraschema.canton";
        var lista = new List<Canton>();

        try
        {
            using var conn = PostgresConnectionFactory.Create();
            conn.Open();
            using var cmd = new NpgsqlCommand(sql, conn);
            using var dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                lista.Add(new Canton
                {
                    IdCanton = dr.GetInt32(0),
                    IdProvincia = dr.GetInt32(1),
                    Nombre = dr.GetString(2)
                });
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[CantonDA.Listar] {ex.Message}");
        }

        return lista;
    }
}
