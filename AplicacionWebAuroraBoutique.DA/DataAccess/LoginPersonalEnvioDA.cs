// -------------- LoginPersonalEnvioDA.cs --------------
using System;
using Npgsql;

namespace AplicacionWebAuroraBoutique.DA.DataAccess;

public class LoginPersonalEnvioDA
{
    private readonly NpgsqlDataSource _ds = new NpgsqlDataSourceBuilder(DbConfig.ConnString).Build();

    public int? Autenticar(string usuario, string contrasena)
    {
        const string sql = """
            SELECT id_personal_envio
            FROM   auroraschema.login_personalenvio
            WHERE  usuario = @u AND contrasena = @p;
        """;

        try
        {
            using var cn = _ds.CreateConnection(); cn.Open();
            using var cmd = new NpgsqlCommand(sql, cn);

            cmd.Parameters.AddWithValue("@u", usuario);
            cmd.Parameters.AddWithValue("@p", contrasena);


            var result = cmd.ExecuteScalar();
            return result is int id ? id : (int?)null;
        }
        catch (Exception ex) { Console.WriteLine($"[LoginPersonalEnvioDA] {ex}"); return null; }
    }
}
