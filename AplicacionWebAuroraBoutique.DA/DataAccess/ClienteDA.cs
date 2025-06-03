using Npgsql;
using AplicacionWebAuroraBoutique.Modelo;

namespace AplicacionWebAuroraBoutique.DA.DataAccess;

public class ClienteDA
{
    /// <summary>Inserta un cliente por medio del SP auroraschema.sp_insert_cliente</summary>
    public void Insertar(Cliente c)
    {
        const string sql = "CALL auroraschema.sp_insert_cliente(@p_nombre,@p_ap1,@p_ap2)";
        try
        {
            using var conn = PostgresConnectionFactory.Create();
            conn.Open();

            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@p_nombre", c.Nombre);
            cmd.Parameters.AddWithValue("@p_ap1", c.PrimerApellido);
            cmd.Parameters.AddWithValue("@p_ap2", c.SegundoApellido);

            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            // TEMPORAL: solo logueamos para no romper flujo si la BD está apagada
            Console.WriteLine($"[ClienteDA.Insertar] {ex.Message}");
        }
    }

    /// <summary>Devuelve todos los clientes (simulado si la BD no responde).</summary>
    public IEnumerable<Cliente> Listar()
    {
        const string sql = "SELECT id_cliente,nombre,primer_apellido,segundo_apellido FROM auroraschema.cliente";
        var lista = new List<Cliente>();

        try
        {
            using var conn = PostgresConnectionFactory.Create();
            conn.Open();

            using var cmd = new NpgsqlCommand(sql, conn);
            using var dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                lista.Add(new Cliente
                {
                    IdCliente = dr.GetInt32(0),
                    Nombre = dr.GetString(1),
                    PrimerApellido = dr.GetString(2),
                    SegundoApellido = dr.GetString(3)
                });
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ClienteDA.Listar] {ex.Message}");
            // Si la BD está caída, devolvemos un mock para que la UI no falle
            lista.Add(new Cliente { IdCliente = 0, Nombre = "Demo", PrimerApellido = "Offline", SegundoApellido = "Mode" });
        }

        return lista;
    }
}
