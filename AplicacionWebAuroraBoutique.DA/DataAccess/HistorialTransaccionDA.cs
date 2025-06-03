using Npgsql;
using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.DA.DataAccess
{
    public class HistorialTransaccionDA
    {
        public void Insertar(HistorialTransaccion h)
        {
            const string sql = "CALL auroraschema.sp_insert_historial_transaccion(@p_idPedido, @p_idMetodoPago, @p_monto, @p_idTipoFecha)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@p_idPedido", h.IdPedido);
                cmd.Parameters.AddWithValue("@p_idMetodoPago", h.IdMetodoPago);
                cmd.Parameters.AddWithValue("@p_monto", h.Monto);
                cmd.Parameters.AddWithValue("@p_idTipoFecha", h.IdTipoFecha);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[HistorialTransaccionDA.Insertar] {ex.Message}");
            }
        }

        public void Modificar(HistorialTransaccion h)
        {
            const string sql = "CALL auroraschema.sp_update_historial_transaccion(@p_idTransaccion, @p_idPedido, @p_idMetodoPago, @p_monto, @p_idTipoFecha)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@p_idTransaccion", h.IdTransaccion);
                cmd.Parameters.AddWithValue("@p_idPedido", h.IdPedido);
                cmd.Parameters.AddWithValue("@p_idMetodoPago", h.IdMetodoPago);
                cmd.Parameters.AddWithValue("@p_monto", h.Monto);
                cmd.Parameters.AddWithValue("@p_idTipoFecha", h.IdTipoFecha);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[HistorialTransaccionDA.Modificar] {ex.Message}");
            }
        }

        public void Eliminar(int idTransaccion)
        {
            const string sql = "CALL auroraschema.sp_delete_historial_transaccion(@p_idTransaccion)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@p_idTransaccion", idTransaccion);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[HistorialTransaccionDA.Eliminar] {ex.Message}");
            }
        }

        public IEnumerable<HistorialTransaccion> Listar()
        {
            const string sql = "SELECT * FROM auroraschema.fn_listar_historial_transaccion()";
            var lista = new List<HistorialTransaccion>();

            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                using var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new HistorialTransaccion
                    {
                        IdTransaccion = dr.GetInt32(0),
                        IdPedido = dr.GetInt32(1),
                        IdMetodoPago = dr.GetInt32(2),
                        Monto = dr.GetDecimal(3),
                        IdTipoFecha = dr.GetInt32(4)
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[HistorialTransaccionDA.Listar] {ex.Message}");
            }

            return lista;
        }
    }
}
