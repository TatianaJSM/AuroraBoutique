using Npgsql;
using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.DA.DataAccess
{
    public class LoginAdministradorDA
    {
        public void Insertar(LoginAdministrador login)
        {
            const string sql = "CALL auroraschema.sp_insert_login_administrador(@p_idAdmin, @p_usuario, @p_contrasena)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();

                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@p_idAdmin", login.IdAdministrador);
                cmd.Parameters.AddWithValue("@p_usuario", login.Usuario);
                cmd.Parameters.AddWithValue("@p_contrasena", login.Contrasena);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[LoginAdministradorDA.Insertar] {ex.Message}");
            }
        }

        public void Modificar(LoginAdministrador login)
        {
            const string sql = "CALL auroraschema.sp_update_login_administrador(@p_idLogin, @p_idAdmin, @p_usuario, @p_contrasena)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();

                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@p_idLogin", login.IdLoginAdmin);
                cmd.Parameters.AddWithValue("@p_idAdmin", login.IdAdministrador);
                cmd.Parameters.AddWithValue("@p_usuario", login.Usuario);
                cmd.Parameters.AddWithValue("@p_contrasena", login.Contrasena);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[LoginAdministradorDA.Modificar] {ex.Message}");
            }
        }

        public void Eliminar(int idLogin)
        {
            const string sql = "CALL auroraschema.sp_delete_login_administrador(@p_idLogin)";
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
                Console.WriteLine($"[LoginAdministradorDA.Eliminar] {ex.Message}");
            }
        }

        public IEnumerable<LoginAdministrador> Listar()
        {
            const string sql = "SELECT * FROM auroraschema.fn_listar_login_administrador()";
            var lista = new List<LoginAdministrador>();

            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();

                using var cmd = new NpgsqlCommand(sql, conn);
                using var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new LoginAdministrador
                    {
                        IdLoginAdmin = dr.GetInt32(0),
                        IdAdministrador = dr.GetInt32(1),
                        Usuario = dr.GetString(2),
                        Contrasena = dr.GetString(3)
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[LoginAdministradorDA.Listar] {ex.Message}");
            }

            return lista;
        }

        public int? Autenticar(string usuario, string contrasena)
        {
            const string sql = "SELECT auroraschema.fn_autenticar_login_administrador(@u, @p)";
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
                Console.WriteLine($"[LoginAdministradorDA.Autenticar] {ex.Message}");
                return null;
            }
        }
    }
}
