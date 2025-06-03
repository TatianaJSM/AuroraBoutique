using Npgsql;
using AplicacionWebAuroraBoutique.Modelo;

namespace AplicacionWebAuroraBoutique.DA.DataAccess;

public class PaisDA
{
    public IEnumerable<Pais> Listar()
    {
        const string sql = "SELECT id_pais, nombre FROM auroraschema.pais";
        var lista = new List<Pais>();

        try
        {
            using var conn = PostgresConnectionFactory.Create();
            conn.Open();
            using var cmd = new NpgsqlCommand(sql, conn);
            using var dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                lista.Add(new Pais
                {
                    IdPais = dr.GetInt32(0),
                    Nombre = dr.GetString(1)
                });
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[PaisDA.Listar] {ex.Message}");
        }

        return lista;
    }
}
