using Npgsql;
using AplicacionWebAuroraBoutique.Modelo;
using System;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.DA.DataAccess
{
    public class ResenaDA
    {
        public void Insertar(Resena r)
        {
            const string sql = "CALL auroraschema.sp_insert_resena(@p_cliente,@p_producto,@p_pedido,@p_com,@p_calif,@p_tipo_fecha)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@p_cliente", r.IdCliente);
                cmd.Parameters.AddWithValue("@p_producto", r.IdProducto);
                cmd.Parameters.AddWithValue("@p_pedido", r.IdPedido);
                cmd.Parameters.AddWithValue("@p_com", r.Comentario);
                cmd.Parameters.AddWithValue("@p_calif", r.Calificacion);
                cmd.Parameters.AddWithValue("@p_tipo_fecha", r.IdTipoFecha);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ResenaDA.Insertar] {ex.Message}");
            }
        }

        public void Modificar(Resena r)
        {
            const string sql = "CALL auroraschema.sp_update_resena(@p_id,@p_cliente,@p_producto,@p_pedido,@p_com,@p_calif,@p_tipo_fecha)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@p_id", r.IdResena);
                cmd.Parameters.AddWithValue("@p_cliente", r.IdCliente);
                cmd.Parameters.AddWithValue("@p_producto", r.IdProducto);
                cmd.Parameters.AddWithValue("@p_pedido", r.IdPedido);
                cmd.Parameters.AddWithValue("@p_com", r.Comentario);
                cmd.Parameters.AddWithValue("@p_calif", r.Calificacion);
                cmd.Parameters.AddWithValue("@p_tipo_fecha", r.IdTipoFecha);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ResenaDA.Modificar] {ex.Message}");
            }
        }

        public void Eliminar(int idResena)
        {
            const string sql = "CALL auroraschema.sp_delete_resena(@p_id)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@p_id", idResena);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ResenaDA.Eliminar] {ex.Message}");
            }
        }

        public IEnumerable<Resena> ListarPorProducto(int idProducto)
        {
            const string sql = "SELECT * FROM auroraschema.fn_list_resena_producto(@p_prod)";
            var lista = new List<Resena>();

            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@p_prod", idProducto);
                using var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new Resena
                    {
                        IdResena = dr.GetInt32(0),
                        IdCliente = dr.GetInt32(1),
                        Calificacion = dr.GetInt32(2),
                        Comentario = dr.GetString(3),
                        IdPedido = dr.GetInt32(4),
                        IdTipoFecha = dr.GetInt32(5),
                        IdProducto = idProducto
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ResenaDA.ListarPorProducto] {ex.Message}");
            }
            return lista;
        }



        public IEnumerable<Resena> Listar()
        {
            const string sql = "SELECT * FROM auroraschema.fn_listar_resena()";  // Asumiendo que existe este SP general (si no, lo creamos luego)
            var lista = new List<Resena>();

            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                using var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new Resena
                    {
                        IdResena = dr.GetInt32(0),
                        IdCliente = dr.GetInt32(1),
                        Calificacion = dr.GetInt32(2),
                        Comentario = dr.GetString(3),
                        IdPedido = dr.GetInt32(4),
                        IdTipoFecha = dr.GetInt32(5),
                        IdProducto = dr.GetInt32(6)
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ResenaDA.Listar] {ex.Message}");
            }
            return lista;
        }

    }
}
