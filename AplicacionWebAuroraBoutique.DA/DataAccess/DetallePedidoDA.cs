using Npgsql;
using AplicacionWebAuroraBoutique.Modelo;
using System;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.DA.DataAccess
{
    public class DetallePedidoDA
    {
        public void Insertar(DetallePedido detalle)
        {
            const string sql = "CALL auroraschema.sp_insert_detalle_pedido(@p_pedido, @p_producto, @p_cant, @p_total)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@p_pedido", detalle.IdPedido);
                cmd.Parameters.AddWithValue("@p_producto", detalle.IdProducto);
                cmd.Parameters.AddWithValue("@p_cant", detalle.Cantidad);
                cmd.Parameters.AddWithValue("@p_total", detalle.PrecioTotalIVA);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DetallePedidoDA.Insertar] {ex.Message}");
            }
        }

        public void Modificar(DetallePedido detalle)
        {
            const string sql = "CALL auroraschema.sp_update_detalle_pedido(@p_iddetalle, @p_pedido, @p_producto, @p_cant, @p_total)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@p_iddetalle", detalle.IdDetalle);
                cmd.Parameters.AddWithValue("@p_pedido", detalle.IdPedido);
                cmd.Parameters.AddWithValue("@p_producto", detalle.IdProducto);
                cmd.Parameters.AddWithValue("@p_cant", detalle.Cantidad);
                cmd.Parameters.AddWithValue("@p_total", detalle.PrecioTotalIVA);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DetallePedidoDA.Modificar] {ex.Message}");
            }
        }

        public void Eliminar(int idDetalle)
        {
            const string sql = "CALL auroraschema.sp_delete_detalle_pedido(@p_iddetalle)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@p_iddetalle", idDetalle);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DetallePedidoDA.Eliminar] {ex.Message}");
            }
        }

        public IEnumerable<DetallePedido> Listar()
        {
            const string sql = "SELECT * FROM auroraschema.fn_listar_detalle_pedido()";
            var lista = new List<DetallePedido>();

            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                using var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new DetallePedido
                    {
                        IdDetalle = dr.GetInt32(0),
                        IdPedido = dr.GetInt32(1),
                        IdProducto = dr.GetInt32(2),
                        Cantidad = dr.GetInt32(3),
                        PrecioTotalIVA = dr.GetDecimal(4)
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DetallePedidoDA.Listar] {ex.Message}");
            }

            return lista;
        }
    }
}
