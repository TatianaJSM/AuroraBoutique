using AplicacionWebAuroraBoutique.Modelo;
using Npgsql;
using System;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.DA.DataAccess
{
    public class ProductoTallaDA
    {
        public void Insertar(ProductoTalla pt)
        {
            const string sql = "CALL auroraschema.sp_insert_producto_talla(@p_idProducto, @p_idTalla)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@p_idProducto", pt.IdProducto);
                cmd.Parameters.AddWithValue("@p_idTalla", pt.IdTalla);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ProductoTallaDA.Insertar] {ex.Message}");
            }
        }

        public void Modificar(ProductoTalla pt)
        {
            const string sql = "CALL auroraschema.sp_update_producto_talla(@p_idProducto, @p_idTalla)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@p_idProducto", pt.IdProducto);
                cmd.Parameters.AddWithValue("@p_idTalla", pt.IdTalla);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ProductoTallaDA.Modificar] {ex.Message}");
            }
        }

        public void Eliminar(int idProducto, int idTalla)
        {
            const string sql = "CALL auroraschema.sp_delete_producto_talla(@p_idProducto, @p_idTalla)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@p_idProducto", idProducto);
                cmd.Parameters.AddWithValue("@p_idTalla", idTalla);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ProductoTallaDA.Eliminar] {ex.Message}");
            }
        }

        public IEnumerable<ProductoTalla> Listar()
        {
            const string sql = "SELECT * FROM auroraschema.fn_list_producto_talla()";
            var lista = new List<ProductoTalla>();

            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                using var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new ProductoTalla
                    {
                        IdProducto = dr.GetInt32(0),
                        IdTalla = dr.GetInt32(1)
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ProductoTallaDA.Listar] {ex.Message}");
            }

            return lista;
        }
    }
}
