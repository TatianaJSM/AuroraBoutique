using Npgsql;
using AplicacionWebAuroraBoutique.Modelo;

namespace AplicacionWebAuroraBoutique.DA.DataAccess;

public class AdministradorDA
{
    public void Insertar(Administrador a)
    {
        const string sql = "CALL auroraschema.sp_insert_administrador(@p_nombre, @p_ap1, @p_ap2)";
        try
        {
            using var conn = PostgresConnectionFactory.Create();
            conn.Open();
            using var cmd = new NpgsqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@p_nombre", a.Nombre);
            cmd.Parameters.AddWithValue("@p_ap1", a.PrimerApellido);
            cmd.Parameters.AddWithValue("@p_ap2", a.SegundoApellido);

            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[AdministradorDA.Insertar] {ex.Message}");
        }
    }

    public void Modificar(Administrador a)
    {
        const string sql = "CALL auroraschema.sp_update_administrador(@p_id, @p_nombre, @p_ap1, @p_ap2)";
        try
        {
            using var conn = PostgresConnectionFactory.Create();
            conn.Open();
            using var cmd = new NpgsqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@p_id", a.IdAdministrador);
            cmd.Parameters.AddWithValue("@p_nombre", a.Nombre);
            cmd.Parameters.AddWithValue("@p_ap1", a.PrimerApellido);
            cmd.Parameters.AddWithValue("@p_ap2", a.SegundoApellido);

            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[AdministradorDA.Modificar] {ex.Message}");
        }
    }

    public void Eliminar(int idAdministrador)
    {
        const string sql = "CALL auroraschema.sp_delete_administrador(@p_id)";
        try
        {
            using var conn = PostgresConnectionFactory.Create();
            conn.Open();
            using var cmd = new NpgsqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@p_id", idAdministrador);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[AdministradorDA.Eliminar] {ex.Message}");
        }
    }

    public IEnumerable<Administrador> Listar()
    {
        const string sql = "SELECT * FROM auroraschema.fn_list_administrador()";
        var lista = new List<Administrador>();

        try
        {
            using var conn = PostgresConnectionFactory.Create();
            conn.Open();
            using var cmd = new NpgsqlCommand(sql, conn);
            using var dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                lista.Add(new Administrador
                {
                    IdAdministrador = dr.GetInt32(0),
                    Nombre = dr.GetString(1),
                    PrimerApellido = dr.GetString(2),
                    SegundoApellido = dr.GetString(3)
                });
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[AdministradorDA.Listar] {ex.Message}");
            lista.Add(new Administrador { IdAdministrador = 0, Nombre = "Demo", PrimerApellido = "Offline", SegundoApellido = "Mode" });
        }

        return lista;
    }
}
