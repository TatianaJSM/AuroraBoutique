using Npgsql;
using AplicacionWebAuroraBoutique.Modelo;
using System;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.DA.DataAccess
{
    public class ProductoDA
    {
        public void Insertar(Producto p)
        {
            const string sql = "CALL auroraschema.sp_insert_producto(@p_nombre,@p_desc,@p_precio,@p_stock,@p_categoria,@p_admin)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@p_nombre", p.Nombre);
                cmd.Parameters.AddWithValue("@p_desc", p.Descripcion);
                cmd.Parameters.AddWithValue("@p_precio", p.Precio);
                cmd.Parameters.AddWithValue("@p_stock", p.CantidadStock);
                cmd.Parameters.AddWithValue("@p_categoria", p.IdCategoria);
                cmd.Parameters.AddWithValue("@p_admin", p.IdAdministrador);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ProductoDA.Insertar] {ex.Message}");
            }
        }

        public void Modificar(Producto p)
        {
            const string sql = "CALL auroraschema.sp_update_producto(@p_id,@p_nombre,@p_desc,@p_precio,@p_stock,@p_categoria,@p_admin)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@p_id", p.IdProducto);
                cmd.Parameters.AddWithValue("@p_nombre", p.Nombre);
                cmd.Parameters.AddWithValue("@p_desc", p.Descripcion);
                cmd.Parameters.AddWithValue("@p_precio", p.Precio);
                cmd.Parameters.AddWithValue("@p_stock", p.CantidadStock);
                cmd.Parameters.AddWithValue("@p_categoria", p.IdCategoria);
                cmd.Parameters.AddWithValue("@p_admin", p.IdAdministrador);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ProductoDA.Modificar] {ex.Message}");
            }
        }

        public void Eliminar(int idProducto)
        {
            const string sql = "CALL auroraschema.sp_delete_producto(@p_id)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@p_id", idProducto);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ProductoDA.Eliminar] {ex.Message}");
            }
        }

        public IEnumerable<Producto> Listar()
        {
            const string sql = "SELECT * FROM auroraschema.fn_list_producto()";
            var lista = new List<Producto>();

            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                using var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new Producto
                    {
                        IdProducto = dr.GetInt32(0),
                        Nombre = dr.GetString(1),
                        Descripcion = dr.GetString(2),
                        Precio = dr.GetDecimal(3),
                        CantidadStock = dr.GetInt32(4),
                        IdCategoria = dr.GetInt32(5),
                        IdAdministrador = dr.GetInt32(6)
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ProductoDA.Listar] {ex.Message}");
            }

            return lista;
        }
    }
}
