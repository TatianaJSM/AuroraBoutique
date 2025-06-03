using Npgsql;
using AplicacionWebAuroraBoutique.Modelo;
using System;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.DA.DataAccess
{
    public class InventarioMovimientoDA
    {
        public void Insertar(InventarioMovimiento m)
        {
            const string sql = "CALL auroraschema.sp_insert_inventario_movimiento(@p_prod,@p_tipo,@p_cant,@p_admin,@p_tipo_fecha)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@p_prod", m.IdProducto);
                cmd.Parameters.AddWithValue("@p_tipo", m.TipoMovimiento);
                cmd.Parameters.AddWithValue("@p_cant", m.Cantidad);
                cmd.Parameters.AddWithValue("@p_admin", m.IdAdministrador);
                cmd.Parameters.AddWithValue("@p_tipo_fecha", m.IdTipoFecha);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[InventarioMovimientoDA.Insertar] {ex.Message}");
            }
        }

        public void Modificar(InventarioMovimiento m)
        {
            const string sql = "CALL auroraschema.sp_update_inventario_movimiento(@p_id,@p_prod,@p_tipo,@p_cant,@p_admin,@p_tipo_fecha)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@p_id", m.IdMovimiento);
                cmd.Parameters.AddWithValue("@p_prod", m.IdProducto);
                cmd.Parameters.AddWithValue("@p_tipo", m.TipoMovimiento);
                cmd.Parameters.AddWithValue("@p_cant", m.Cantidad);
                cmd.Parameters.AddWithValue("@p_admin", m.IdAdministrador);
                cmd.Parameters.AddWithValue("@p_tipo_fecha", m.IdTipoFecha);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[InventarioMovimientoDA.Modificar] {ex.Message}");
            }
        }

        public void Eliminar(int idMovimiento)
        {
            const string sql = "CALL auroraschema.sp_delete_inventario_movimiento(@p_id)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@p_id", idMovimiento);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[InventarioMovimientoDA.Eliminar] {ex.Message}");
            }
        }

        public IEnumerable<InventarioMovimiento> Listar()
        {
            const string sql = "SELECT * FROM auroraschema.fn_listar_inventario_movimiento()";
            var lista = new List<InventarioMovimiento>();

            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                using var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new InventarioMovimiento
                    {
                        IdMovimiento = dr.GetInt32(0),
                        IdProducto = dr.GetInt32(1),
                        TipoMovimiento = dr.GetString(2),
                        Cantidad = dr.GetInt32(3),
                        IdAdministrador = dr.GetInt32(4),
                        IdTipoFecha = dr.GetInt32(5)
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[InventarioMovimientoDA.Listar] {ex.Message}");
            }

            return lista;
        }
    }
}
