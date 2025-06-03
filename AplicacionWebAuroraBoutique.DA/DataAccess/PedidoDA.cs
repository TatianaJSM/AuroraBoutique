using Npgsql;
using AplicacionWebAuroraBoutique.Modelo;
using System;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.DA.DataAccess
{
    public class PedidoDA
    {
        public void Insertar(Pedido p)
        {
            const string sql = "CALL auroraschema.sp_insert_pedido(@p_estado, @p_cliente, @p_admin, @p_tipo_fecha)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@p_estado", p.IdEstado);
                cmd.Parameters.AddWithValue("@p_cliente", p.IdCliente);
                cmd.Parameters.AddWithValue("@p_admin", p.IdAdministrador);
                cmd.Parameters.AddWithValue("@p_tipo_fecha", p.IdTipoFecha);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[PedidoDA.Insertar] {ex.Message}");
            }
        }

        public void Modificar(Pedido p)
        {
            const string sql = "CALL auroraschema.sp_update_pedido(@p_id_pedido, @p_estado, @p_cliente, @p_admin, @p_tipo_fecha)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@p_id_pedido", p.IdPedido);
                cmd.Parameters.AddWithValue("@p_estado", p.IdEstado);
                cmd.Parameters.AddWithValue("@p_cliente", p.IdCliente);
                cmd.Parameters.AddWithValue("@p_admin", p.IdAdministrador);
                cmd.Parameters.AddWithValue("@p_tipo_fecha", p.IdTipoFecha);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[PedidoDA.Modificar] {ex.Message}");
            }
        }

        public void Eliminar(int idPedido)
        {
            const string sql = "CALL auroraschema.sp_delete_pedido(@p_id_pedido)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@p_id_pedido", idPedido);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[PedidoDA.Eliminar] {ex.Message}");
            }
        }

        public IEnumerable<Pedido> Listar()
        {
            const string sql = "SELECT * FROM auroraschema.fn_listar_pedido()";
            var lista = new List<Pedido>();

            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                using var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new Pedido
                    {
                        IdPedido = dr.GetInt32(0),
                        IdEstado = dr.GetInt32(1),
                        IdCliente = dr.GetInt32(2),
                        IdAdministrador = dr.GetInt32(3),
                        IdTipoFecha = dr.GetInt32(4)
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[PedidoDA.Listar] {ex.Message}");
            }

            return lista;
        }
    }
}
