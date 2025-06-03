using Npgsql;
using AplicacionWebAuroraBoutique.Modelo;

namespace AplicacionWebAuroraBoutique.DA.DataAccess;

public class BarrioDA
{
    public IEnumerable<Barrio> Listar()
    {
        const string sql = "SELECT id_barrio, id_distrito, nombre FROM auroraschema.barrio";
        var lista = new List<Barrio>();

        try
        {
            using var conn = PostgresConnectionFactory.Create();
            conn.Open();
            using var cmd = new NpgsqlCommand(sql, conn);
            using var dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                lista.Add(new Barrio
                {
                    IdBarrio = dr.GetInt32(0),
                    IdDistrito = dr.GetInt32(1),
                    Nombre = dr.GetString(2)
                });
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[BarrioDA.Listar] {ex.Message}");
        }

        return lista;
    }
}
