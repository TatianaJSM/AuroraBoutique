using Npgsql;
using AplicacionWebAuroraBoutique.Modelo;

namespace AplicacionWebAuroraBoutique.DA.DataAccess;

public class ProvinciaDA
{
    public IEnumerable<Provincia> Listar()
    {
        const string sql = "SELECT id_provincia, id_pais, nombre FROM auroraschema.provincia";
        var lista = new List<Provincia>();

        try
        {
            using var conn = PostgresConnectionFactory.Create();
            conn.Open();
            using var cmd = new NpgsqlCommand(sql, conn);
            using var dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                lista.Add(new Provincia
                {
                    IdProvincia = dr.GetInt32(0),
                    IdPais = dr.GetInt32(1),
                    Nombre = dr.GetString(2)
                });
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ProvinciaDA.Listar] {ex.Message}");
        }

        return lista;
    }
}
