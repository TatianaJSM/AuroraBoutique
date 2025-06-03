using Npgsql;
using AplicacionWebAuroraBoutique.Modelo;
using System;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.DA.DataAccess
{
    public class ProductoColorDA
    {
        public void Insertar(ProductoColor pc)
        {
            const string sql = "CALL auroraschema.sp_insert_producto_color(@p_idProducto, @p_idColor)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@p_idProducto", pc.IdProducto);
                cmd.Parameters.AddWithValue("@p_idColor", pc.IdColor);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ProductoColorDA.Insertar] {ex.Message}");
            }
        }

        public void Modificar(ProductoColor pc)
        {
            const string sql = "CALL auroraschema.sp_update_producto_color(@p_idProducto, @p_idColor)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@p_idProducto", pc.IdProducto);
                cmd.Parameters.AddWithValue("@p_idColor", pc.IdColor);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ProductoColorDA.Modificar] {ex.Message}");
            }
        }

        public void Eliminar(int idProducto, int idColor)
        {
            const string sql = "CALL auroraschema.sp_delete_producto_color(@p_idProducto, @p_idColor)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@p_idProducto", idProducto);
                cmd.Parameters.AddWithValue("@p_idColor", idColor);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ProductoColorDA.Eliminar] {ex.Message}");
            }
        }

        public IEnumerable<ProductoColor> Listar()
        {
            const string sql = "SELECT * FROM auroraschema.fn_list_producto_color()";
            var lista = new List<ProductoColor>();

            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                using var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new ProductoColor
                    {
                        IdProducto = dr.GetInt32(0),
                        IdColor = dr.GetInt32(1)
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ProductoColorDA.Listar] {ex.Message}");
            }

            return lista;
        }
    }
}
