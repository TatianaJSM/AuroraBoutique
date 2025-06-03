using Npgsql;
using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.DA.DataAccess
{
    public class LoginPersonalEnvioDA
    {
        public void Insertar(LoginPersonalEnvio login)
        {
            const string sql = "CALL auroraschema.sp_insert_login_personalenvio(@p_idPersonalEnvio, @p_usuario, @p_contrasena)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();

                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@p_idPersonalEnvio", login.IdPersonalEnvio);
                cmd.Parameters.AddWithValue("@p_usuario", login.Usuario);
                cmd.Parameters.AddWithValue("@p_contrasena", login.Contrasena);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[LoginPersonalEnvioDA.Insertar] {ex.Message}");
            }
        }

        public void Modificar(LoginPersonalEnvio login)
        {
            const string sql = "CALL auroraschema.sp_update_login_personalenvio(@p_idLogin, @p_idPersonalEnvio, @p_usuario, @p_contrasena)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();

                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@p_idLogin", login.IdLoginPersonal);
                cmd.Parameters.AddWithValue("@p_idPersonalEnvio", login.IdPersonalEnvio);
                cmd.Parameters.AddWithValue("@p_usuario", login.Usuario);
                cmd.Parameters.AddWithValue("@p_contrasena", login.Contrasena);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[LoginPersonalEnvioDA.Modificar] {ex.Message}");
            }
        }

        public void Eliminar(int idLogin)
        {
            const string sql = "CALL auroraschema.sp_delete_login_personalenvio(@p_idLogin)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();

                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@p_idLogin", idLogin);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[LoginPersonalEnvioDA.Eliminar] {ex.Message}");
            }
        }

        public IEnumerable<LoginPersonalEnvio> Listar()
        {
            const string sql = "SELECT * FROM auroraschema.fn_listar_login_personalenvio()";
            var lista = new List<LoginPersonalEnvio>();

            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();

                using var cmd = new NpgsqlCommand(sql, conn);
                using var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new LoginPersonalEnvio
                    {
                        IdLoginPersonal = dr.GetInt32(0),
                        IdPersonalEnvio = dr.GetInt32(1),
                        Usuario = dr.GetString(2),
                        Contrasena = dr.GetString(3)
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[LoginPersonalEnvioDA.Listar] {ex.Message}");
            }

            return lista;
        }

        public int? Autenticar(string usuario, string contrasena)
        {
            const string sql = "SELECT id_personal_envio FROM auroraschema.login_personalenvio WHERE usuario = @u AND contrasena = @p";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();

                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@u", usuario);
                cmd.Parameters.AddWithValue("@p", contrasena);

                var result = cmd.ExecuteScalar();
                return result is int id ? id : (int?)null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[LoginPersonalEnvioDA.Autenticar] {ex.Message}");
                return null;
            }
        }
    }
}
