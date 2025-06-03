using Npgsql;
using AplicacionWebAuroraBoutique.Modelo;
using System;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.DA.DataAccess
{
    public class ProvinciaDA
    {
        public void Insertar(Provincia p)
        {
            const string sql = "CALL auroraschema.sp_insert_provincia(@p_idPais, @p_nombre)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@p_idPais", p.IdPais);
                cmd.Parameters.AddWithValue("@p_nombre", p.Nombre);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ProvinciaDA.Insertar] {ex.Message}");
            }
        }

        public void Modificar(Provincia p)
        {
            const string sql = "CALL auroraschema.sp_update_provincia(@p_idProvincia, @p_idPais, @p_nombre)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@p_idProvincia", p.IdProvincia);
                cmd.Parameters.AddWithValue("@p_idPais", p.IdPais);
                cmd.Parameters.AddWithValue("@p_nombre", p.Nombre);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ProvinciaDA.Modificar] {ex.Message}");
            }
        }

        public void Eliminar(int idProvincia)
        {
            const string sql = "CALL auroraschema.sp_delete_provincia(@p_idProvincia)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@p_idProvincia", idProvincia);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ProvinciaDA.Eliminar] {ex.Message}");
            }
        }

        public IEnumerable<Provincia> Listar()
        {
            const string sql = "SELECT * FROM auroraschema.fn_list_provincia()";
            var lista = new List<Provincia>();

            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                using var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new Provincia
                    {
                        IdProvincia = dr.GetInt32(0),
                        IdPais = dr.GetInt32(1),
                        Nombre = dr.GetString(2)
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ProvinciaDA.Listar] {ex.Message}");
            }

            return lista;
        }
    }
}
