using AplicacionWebAuroraBoutique.Modelo;
using Npgsql;
using System;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.DA.DataAccess
{
    public class TipoFechaDA
    {
        public void Insertar(TipoFecha tipoFecha)
        {
            const string sql = "CALL auroraschema.sp_insert_tipo_fecha(@p_id_cliente, @p_dia, @p_mes, @p_anio, @p_tipo_evento)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@p_id_cliente", tipoFecha.IdCliente);
                cmd.Parameters.AddWithValue("@p_dia", tipoFecha.Dia);
                cmd.Parameters.AddWithValue("@p_mes", tipoFecha.Mes);
                cmd.Parameters.AddWithValue("@p_anio", tipoFecha.Anio);
                cmd.Parameters.AddWithValue("@p_tipo_evento", tipoFecha.TipoEvento);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[TipoFechaDA.Insertar] {ex.Message}");
            }
        }

        public void Modificar(TipoFecha tipoFecha)
        {
            const string sql = "CALL auroraschema.sp_update_tipo_fecha(@p_id_tipo_fecha, @p_id_cliente, @p_dia, @p_mes, @p_anio, @p_tipo_evento)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@p_id_tipo_fecha", tipoFecha.IdTipoFecha);
                cmd.Parameters.AddWithValue("@p_id_cliente", tipoFecha.IdCliente);
                cmd.Parameters.AddWithValue("@p_dia", tipoFecha.Dia);
                cmd.Parameters.AddWithValue("@p_mes", tipoFecha.Mes);
                cmd.Parameters.AddWithValue("@p_anio", tipoFecha.Anio);
                cmd.Parameters.AddWithValue("@p_tipo_evento", tipoFecha.TipoEvento);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[TipoFechaDA.Modificar] {ex.Message}");
            }
        }

        public void Eliminar(int idTipoFecha)
        {
            const string sql = "CALL auroraschema.sp_delete_tipo_fecha(@p_id_tipo_fecha)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@p_id_tipo_fecha", idTipoFecha);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[TipoFechaDA.Eliminar] {ex.Message}");
            }
        }

        public IEnumerable<TipoFecha> Listar()
        {
            const string sql = "SELECT * FROM auroraschema.fn_listar_tipo_fecha()";
            var lista = new List<TipoFecha>();

            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                using var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new TipoFecha
                    {
                        IdTipoFecha = dr.GetInt32(0),
                        IdCliente = dr.GetInt32(1),
                        Dia = dr.GetInt32(2),
                        Mes = dr.GetInt32(3),
                        Anio = dr.GetInt32(4),
                        TipoEvento = dr.GetString(5)
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[TipoFechaDA.Listar] {ex.Message}");
            }

            return lista;
        }
    }
}
