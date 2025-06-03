using Npgsql;
using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.DA.DataAccess
{
    public class MetodoPagoDA
    {
        public void Insertar(MetodoPago metodo)
        {
            const string sql = "CALL auroraschema.sp_insert_metodo_pago(@p_pago)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@p_pago", metodo.Pago);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[MetodoPagoDA.Insertar] {ex.Message}");
            }
        }

        public void Modificar(MetodoPago metodo)
        {
            const string sql = "CALL auroraschema.sp_update_metodo_pago(@p_id, @p_pago)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@p_id", metodo.IdMetodoPago);
                cmd.Parameters.AddWithValue("@p_pago", metodo.Pago);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[MetodoPagoDA.Modificar] {ex.Message}");
            }
        }

        public void Eliminar(int idMetodoPago)
        {
            const string sql = "CALL auroraschema.sp_delete_metodo_pago(@p_id)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@p_id", idMetodoPago);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[MetodoPagoDA.Eliminar] {ex.Message}");
            }
        }

        public IEnumerable<MetodoPago> Listar()
        {
            const string sql = "SELECT * FROM auroraschema.fn_listar_metodo_pago()";
            var lista = new List<MetodoPago>();

            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                using var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new MetodoPago
                    {
                        IdMetodoPago = dr.GetInt32(0),
                        Pago = dr.GetString(1)
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[MetodoPagoDA.Listar] {ex.Message}");
            }

            return lista;
        }
    }
}
