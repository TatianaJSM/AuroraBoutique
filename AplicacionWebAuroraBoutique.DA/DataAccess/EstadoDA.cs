using Npgsql;
using AplicacionWebAuroraBoutique.Modelo;

namespace AplicacionWebAuroraBoutique.DA.DataAccess;

public class EstadoDA
{
    public IEnumerable<Estado> Listar()
    {
        const string sql = "SELECT id_estado, nombre, descripcion FROM auroraschema.estado";
        var lista = new List<Estado>();

        try
        {
            using var conn = PostgresConnectionFactory.Create();
            conn.Open();
            using var cmd = new NpgsqlCommand(sql, conn);
            using var dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                lista.Add(new Estado
                {
                    IdEstado = dr.GetInt32(0),
                    Nombre = dr.GetString(1),
                    Descripcion = dr.GetString(2)
                });
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[EstadoDA.Listar] {ex.Message}");
        }

        return lista;
    }
}
