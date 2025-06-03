using Npgsql;
using AplicacionWebAuroraBoutique.Modelo;
using System;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.DA.DataAccess
{
    public class PersonalEnvioDA
    {
        public void Insertar(PersonalEnvio p)
        {
            const string sql = "CALL auroraschema.sp_insert_personalenvio(@p_nombre, @p_ap1, @p_ap2)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();

                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@p_nombre", p.Nombre);
                cmd.Parameters.AddWithValue("@p_ap1", p.PrimerApellido);
                cmd.Parameters.AddWithValue("@p_ap2", p.SegundoApellido);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[PersonalEnvioDA.Insertar] {ex.Message}");
            }
        }

        public void Modificar(PersonalEnvio p)
        {
            const string sql = "CALL auroraschema.sp_update_personalenvio(@p_id, @p_nombre, @p_ap1, @p_ap2)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();

                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@p_id", p.IdPersonalEnvio);
                cmd.Parameters.AddWithValue("@p_nombre", p.Nombre);
                cmd.Parameters.AddWithValue("@p_ap1", p.PrimerApellido);
                cmd.Parameters.AddWithValue("@p_ap2", p.SegundoApellido);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[PersonalEnvioDA.Modificar] {ex.Message}");
            }
        }

        public void Eliminar(int idPersonalEnvio)
        {
            const string sql = "CALL auroraschema.sp_delete_personalenvio(@p_id)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();

                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@p_id", idPersonalEnvio);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[PersonalEnvioDA.Eliminar] {ex.Message}");
            }
        }

        public IEnumerable<PersonalEnvio> Listar()
        {
            const string sql = "SELECT * FROM auroraschema.fn_list_personalenvio()";
            var lista = new List<PersonalEnvio>();

            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                using var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new PersonalEnvio
                    {
                        IdPersonalEnvio = dr.GetInt32(0),
                        Nombre = dr.GetString(1),
                        PrimerApellido = dr.GetString(2),
                        SegundoApellido = dr.GetString(3)
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[PersonalEnvioDA.Listar] {ex.Message}");
            }

            return lista;
        }
    }
}
