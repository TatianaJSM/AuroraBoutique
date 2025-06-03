using Npgsql;
using AplicacionWebAuroraBoutique.Modelo;

namespace AplicacionWebAuroraBoutique.DA.DataAccess;

public class PersonalEnvioDA
{
    public void Insertar(PersonalEnvio p)
    {
        const string sql = "CALL auroraschema.sp_insert_personalenvio(@p_nombre, @p_ap1, @p_ap2)";
        try
        {
            using var conn = PostgresConnectionFactory.Create();
            conn.Open();

            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@p_nombre", p.Nombre);
            cmd.Parameters.AddWithValue("@p_ap1", p.PrimerApellido);
            cmd.Parameters.AddWithValue("@p_ap2", p.SegundoApellido);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[PersonalEnvioDA.Insertar] {ex.Message}");
        }
    }

    public IEnumerable<PersonalEnvio> Listar()
    {
        const string sql = "SELECT id_personalenvio, nombre, primer_apellido, segundo_apellido FROM auroraschema.personalenvio";
        var lista = new List<PersonalEnvio>();

        try
        {
            using var conn = PostgresConnectionFactory.Create();
            conn.Open();
            using var cmd = new NpgsqlCommand(sql, conn);
            using var dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                lista.Add(new PersonalEnvio
                {
                    IdPersonalEnvio = dr.GetInt32(0),
                    Nombre = dr.GetString(1),
                    PrimerApellido = dr.GetString(2),
                    SegundoApellido = dr.GetString(3)
                });
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[PersonalEnvioDA.Listar] {ex.Message}");
            lista.Add(new PersonalEnvio { IdPersonalEnvio = 0, Nombre = "Demo", PrimerApellido = "Offline", SegundoApellido = "Mode" });
        }

        return lista;
    }
}
