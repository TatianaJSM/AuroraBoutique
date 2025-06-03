using Npgsql;
using AplicacionWebAuroraBoutique.Modelo;

namespace AplicacionWebAuroraBoutique.DA.DataAccess;

public class DistritoDA
{
    public IEnumerable<Distrito> Listar()
    {
        const string sql = "SELECT id_distrito, id_canton, nombre FROM auroraschema.distrito";
        var lista = new List<Distrito>();

        try
        {
            using var conn = PostgresConnectionFactory.Create();
            conn.Open();
            using var cmd = new NpgsqlCommand(sql, conn);
            using var dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                lista.Add(new Distrito
                {
                    IdDistrito = dr.GetInt32(0),
                    IdCanton = dr.GetInt32(1),
                    Nombre = dr.GetString(2)
                });
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[DistritoDA.Listar] {ex.Message}");
        }

        return lista;
    }
}
