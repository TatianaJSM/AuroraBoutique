using Npgsql;
using AplicacionWebAuroraBoutique.Modelo;
using System;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.DA.DataAccess
{
    public class PedidoPersonalEnvioDA
    {
        public void Insertar(PedidoPersonalEnvio p)
        {
            const string sql = "CALL auroraschema.sp_insert_pedido_personalenvio(@p_idPedido, @p_idPersonalEnvio, @p_idTipoFecha)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@p_idPedido", p.IdPedido);
                cmd.Parameters.AddWithValue("@p_idPersonalEnvio", p.IdPersonalEnvio);
                cmd.Parameters.AddWithValue("@p_idTipoFecha", p.IdTipoFecha);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[PedidoPersonalEnvioDA.Insertar] {ex.Message}");
            }
        }

        public void Modificar(PedidoPersonalEnvio p)
        {
            const string sql = "CALL auroraschema.sp_update_pedido_personalenvio(@p_idPedidoEnvio, @p_idPedido, @p_idPersonalEnvio, @p_idTipoFecha)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@p_idPedidoEnvio", p.IdPedidoEnvio);
                cmd.Parameters.AddWithValue("@p_idPedido", p.IdPedido);
                cmd.Parameters.AddWithValue("@p_idPersonalEnvio", p.IdPersonalEnvio);
                cmd.Parameters.AddWithValue("@p_idTipoFecha", p.IdTipoFecha);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[PedidoPersonalEnvioDA.Modificar] {ex.Message}");
            }
        }

        public void Eliminar(int idPedidoEnvio)
        {
            const string sql = "CALL auroraschema.sp_delete_pedido_personalenvio(@p_idPedidoEnvio)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@p_idPedidoEnvio", idPedidoEnvio);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[PedidoPersonalEnvioDA.Eliminar] {ex.Message}");
            }
        }

        public IEnumerable<PedidoPersonalEnvio> Listar()
        {
            const string sql = "SELECT * FROM auroraschema.fn_listar_pedido_personalenvio()";
            var lista = new List<PedidoPersonalEnvio>();

            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                using var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new PedidoPersonalEnvio
                    {
                        IdPedidoEnvio = dr.GetInt32(0),
                        IdPedido = dr.GetInt32(1),
                        IdPersonalEnvio = dr.GetInt32(2),
                        IdTipoFecha = dr.GetInt32(3)
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[PedidoPersonalEnvioDA.Listar] {ex.Message}");
            }

            return lista;
        }
    }
}
