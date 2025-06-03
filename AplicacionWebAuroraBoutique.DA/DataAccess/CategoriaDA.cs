using Npgsql;
using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.DA.DataAccess
{
    public class CategoriaDA
    {
        public void Insertar(Categoria categoria)
        {
            const string sql = "CALL auroraschema.sp_insert_categoria(@p_nombre)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@p_nombre", categoria.Nombre);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[CategoriaDA.Insertar] {ex.Message}");
            }
        }

        public void Modificar(Categoria categoria)
        {
            const string sql = "CALL auroraschema.sp_update_categoria(@p_categoria, @p_nombre)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@p_categoria", categoria.IdCategoria);
                cmd.Parameters.AddWithValue("@p_nombre", categoria.Nombre);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[CategoriaDA.Modificar] {ex.Message}");
            }
        }

        public void Eliminar(int idCategoria)
        {
            const string sql = "CALL auroraschema.sp_delete_categoria(@p_categoria)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@p_categoria", idCategoria);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[CategoriaDA.Eliminar] {ex.Message}");
            }
        }

        public IEnumerable<Categoria> Listar()
        {
            const string sql = "SELECT * FROM auroraschema.fn_listar_categorias()";
            var lista = new List<Categoria>();

            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                using var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new Categoria
                    {
                        IdCategoria = dr.GetInt32(0),
                        Nombre = dr.GetString(1)
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[CategoriaDA.Listar] {ex.Message}");
            }

            return lista;
        }
    }
}
