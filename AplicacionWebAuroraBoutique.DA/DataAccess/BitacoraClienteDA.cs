using AplicacionWebAuroraBoutique.Modelo;
using Npgsql;

namespace AplicacionWebAuroraBoutique.DA.DataAccess;

public class BitacoraClienteDA
{
    public void Insertar(BitacoraCliente bitacora)
    {
        const string sql = "CALL auroraschema.sp_insert_bitacoracliente(@p_idcliente, @p_usuario, @p_accion, @p_fecharegistro)";
        try
        {
            using var conn = PostgresConnectionFactory.Create();
            conn.Open();

            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@p_idcliente", bitacora.IdCliente);
            cmd.Parameters.AddWithValue("@p_usuario", bitacora.Usuario);
            cmd.Parameters.AddWithValue("@p_accion", bitacora.Accion);
            cmd.Parameters.AddWithValue("@p_fecharegistro", bitacora.FechaRegistro);

            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[BitacoraClienteDA.Insertar] {ex.Message}");
        }
    }

    public IEnumerable<BitacoraCliente> Listar()
    {
        const string sql = "SELECT id_log, id_cliente, usuario, accion, fecha_registro FROM auroraschema.bitacora_cliente";
        var lista = new List<BitacoraCliente>();

        try
        {
            using var conn = PostgresConnectionFactory.Create();
            conn.Open();

            using var cmd = new NpgsqlCommand(sql, conn);
            using var dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                lista.Add(new BitacoraCliente
                {
                    IdLog = dr.GetInt32(0),
                    IdCliente = dr.GetInt32(1),
                    Usuario = dr.GetString(2),
                    Accion = dr.GetString(3),
                    FechaRegistro = dr.GetDateTime(4)
                });
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[BitacoraClienteDA.Listar] {ex.Message}");
            lista.Add(new BitacoraCliente { IdLog = 0 });
        }

        return lista;
    }
}
