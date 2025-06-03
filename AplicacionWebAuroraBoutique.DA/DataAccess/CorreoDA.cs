using Npgsql;
using AplicacionWebAuroraBoutique.Modelo;

namespace AplicacionWebAuroraBoutique.DA.DataAccess;

public class CorreoDA
{
    public IEnumerable<Correo> Listar()
    {
        const string sql = "SELECT id_correo, id_cliente, email FROM auroraschema.correo";
        var lista = new List<Correo>();

        try
        {
            using var conn = PostgresConnectionFactory.Create();
            conn.Open();
            using var cmd = new NpgsqlCommand(sql, conn);
            using var dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                lista.Add(new Correo
                {
                    IdCorreo = dr.GetInt32(0),
                    IdCliente = dr.GetInt32(1),
                    Email = dr.GetString(2)
                });
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[CorreoDA.Listar] {ex.Message}");
        }

        return lista;
    }
}
