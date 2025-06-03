using Npgsql;
using AplicacionWebAuroraBoutique.Modelo;

namespace AplicacionWebAuroraBoutique.DA.DataAccess;

public class ColorDA
{
    public IEnumerable<Color> Listar()
    {
        const string sql = "SELECT id_color, descripcion FROM auroraschema.color";
        var lista = new List<Color>();

        try
        {
            using var conn = PostgresConnectionFactory.Create();
            conn.Open();
            using var cmd = new NpgsqlCommand(sql, conn);
            using var dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                lista.Add(new Color
                {
                    IdColor = dr.GetInt32(0),
                    Descripcion = dr.GetString(1)
                });
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ColorDA.Listar] {ex.Message}");
        }

        return lista;
    }
}
