using Npgsql;
using AplicacionWebAuroraBoutique.Modelo;
using System;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.DA.DataAccess
{
    public class DireccionDA
    {
        public void Insertar(Direccion d)
        {
            const string sql = "CALL auroraschema.sp_insert_direccion(@p_idCliente, @p_idBarrio, @p_idDistrito, @p_idCanton, @p_idProvincia, @p_idPais)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@p_idCliente", d.IdCliente);
                cmd.Parameters.AddWithValue("@p_idBarrio", d.IdBarrio);
                cmd.Parameters.AddWithValue("@p_idDistrito", d.IdDistrito);
                cmd.Parameters.AddWithValue("@p_idCanton", d.IdCanton);
                cmd.Parameters.AddWithValue("@p_idProvincia", d.IdProvincia);
                cmd.Parameters.AddWithValue("@p_idPais", d.IdPais);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DireccionDA.Insertar] {ex.Message}");
            }
        }

        public void Modificar(Direccion d)
        {
            const string sql = "CALL auroraschema.sp_update_direccion(@p_idDireccion, @p_idCliente, @p_idBarrio, @p_idDistrito, @p_idCanton, @p_idProvincia, @p_idPais)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@p_idDireccion", d.IdDireccion);
                cmd.Parameters.AddWithValue("@p_idCliente", d.IdCliente);
                cmd.Parameters.AddWithValue("@p_idBarrio", d.IdBarrio);
                cmd.Parameters.AddWithValue("@p_idDistrito", d.IdDistrito);
                cmd.Parameters.AddWithValue("@p_idCanton", d.IdCanton);
                cmd.Parameters.AddWithValue("@p_idProvincia", d.IdProvincia);
                cmd.Parameters.AddWithValue("@p_idPais", d.IdPais);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DireccionDA.Modificar] {ex.Message}");
            }
        }

        public void Eliminar(int idDireccion)
        {
            const string sql = "CALL auroraschema.sp_delete_direccion(@p_idDireccion)";
            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@p_idDireccion", idDireccion);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DireccionDA.Eliminar] {ex.Message}");
            }
        }

        public IEnumerable<Direccion> Listar()
        {
            const string sql = "SELECT * FROM auroraschema.fn_listar_direccion()";
            var lista = new List<Direccion>();

            try
            {
                using var conn = PostgresConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(sql, conn);
                using var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new Direccion
                    {
                        IdDireccion = dr.GetInt32(0),
                        IdCliente = dr.GetInt32(1),
                        IdBarrio = dr.GetInt32(2),
                        IdDistrito = dr.GetInt32(3),
                        IdCanton = dr.GetInt32(4),
                        IdProvincia = dr.GetInt32(5),
                        IdPais = dr.GetInt32(6)
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DireccionDA.Listar] {ex.Message}");
            }

            return lista;
        }
    }
}
