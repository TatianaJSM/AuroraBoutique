using AplicacionWebAuroraBoutique.Modelo;
using Npgsql;

namespace AplicacionWebAuroraBoutique.DA.DataAccess;

public class TelefonoDA
{
    public IEnumerable<Telefono> Listar()
    {
        const string sql = "SELECT id_telefono, id_cliente, numero FROM auroraschema.telefono";
        var lista = new List<Telefono>();

        try
        {
            using var conn = PostgresConnectionFactory.Create();
            conn.Open();
            using var cmd = new NpgsqlCommand(sql, conn);
            using var dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                lista.Add(new Telefono
                {
                    IdTelefono = dr.GetInt32(0),
                    IdCliente = dr.GetInt32(1),
                    Numero = dr.GetString(2)
                });
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[TelefonoDA.Listar] {ex.Message}");
        }

        return lista;
    }
}
