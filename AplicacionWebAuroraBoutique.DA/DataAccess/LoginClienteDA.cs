using Npgsql;
using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.DA.DataAccess
{
    public class LoginClienteDA
    {
        public void Insertar(LoginCliente login)
        {
            const string sql = "CALL auroraschema.sp_insert_login_cliente(@p_idCliente, @p_usuario, @p_contrasena)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();

                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@p_idCliente", login.IdCliente);
                cmd.Parameters.AddWithValue("@p_usuario", login.Usuario);
                cmd.Parameters.AddWithValue("@p_contrasena", login.Contrasena);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[LoginClienteDA.Insertar] {ex.Message}");
            }
        }

        public void Modificar(LoginCliente login)
        {
            const string sql = "CALL auroraschema.sp_update_login_cliente(@p_idLogin, @p_idCliente, @p_usuario, @p_contrasena)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();

                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@p_idLogin", login.IdLoginCliente);
                cmd.Parameters.AddWithValue("@p_idCliente", login.IdCliente);
                cmd.Parameters.AddWithValue("@p_usuario", login.Usuario);
                cmd.Parameters.AddWithValue("@p_contrasena", login.Contrasena);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[LoginClienteDA.Modificar] {ex.Message}");
            }
        }

        public void Eliminar(int idLogin)
        {
            const string sql = "CALL auroraschema.sp_delete_login_cliente(@p_idLogin)";
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
                Console.WriteLine($"[LoginClienteDA.Eliminar] {ex.Message}");
            }
        }

        public IEnumerable<LoginCliente> Listar()
        {
            const string sql = "SELECT * FROM auroraschema.fn_listar_login_cliente()";
            var lista = new List<LoginCliente>();

            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();

                using var cmd = new NpgsqlCommand(sql, conn);
                using var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new LoginCliente
                    {
                        IdLoginCliente = dr.GetInt32(0),
                        IdCliente = dr.GetInt32(1),
                        Usuario = dr.GetString(2),
                        Contrasena = dr.GetString(3)
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[LoginClienteDA.Listar] {ex.Message}");
            }

            return lista;
        }

        public int? Autenticar(string usuario, string contrasena)
        {
            const string sql = "SELECT id_cliente FROM auroraschema.login_cliente WHERE usuario = @u AND contrasena = @p";
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
                Console.WriteLine($"[LoginClienteDA.Autenticar] {ex.Message}");
                return null;
            }
        }
    }
}
