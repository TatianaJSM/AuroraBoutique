// -------------- PedidoDA.cs --------------
using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;
using AplicacionWebAuroraBoutique.Modelo;

namespace AplicacionWebAuroraBoutique.DA.DataAccess;

public class PedidoDA
{
    private readonly NpgsqlDataSource _ds = new NpgsqlDataSourceBuilder(DbConfig.ConnString).Build();

    public int Insertar(Pedido p)
    {
        const string sql = "CALL auroraschema.sp_insert_pedido(@p_estado,@p_cliente,@p_admin,@p_tipo_fecha)";
        try
        {
            using var cn = _ds.CreateConnection();
            cn.Open();
            using var cmd = new NpgsqlCommand(sql, cn);

            cmd.Parameters.Add("@p_estado", NpgsqlTypes.NpgsqlDbType.Integer).Value = p.IdEstado;
            cmd.Parameters.Add("@p_cliente", NpgsqlTypes.NpgsqlDbType.Integer).Value = p.IdCliente;
            cmd.Parameters.Add("@p_admin", NpgsqlTypes.NpgsqlDbType.Integer).Value = p.IdAdministrador;
            cmd.Parameters.Add("@p_tipo_fecha", NpgsqlTypes.NpgsqlDbType.Integer).Value = p.IdTipoFecha;

            cmd.ExecuteNonQuery();
            // Si tu SP devuelve el id_pedido nuevo, devuélvelo; de lo contrario, retorna 0:
            return 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[PedidoDA.Insertar] {ex}");
            return 0;
        }
    }

    public IEnumerable<Pedido> Listar()
    {
        const string sql = """
            SELECT id_pedido,id_estado,id_cliente,id_administrador,id_tipo_fecha
            FROM   auroraschema.pedido
        """;

        var lista = new List<Pedido>();
        try
        {
            using var cn = _ds.CreateConnection(); cn.Open();
            using var cmd = new NpgsqlCommand(sql, cn);
            using var dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                lista.Add(new Pedido
                {
                    IdPedido = dr.GetInt32(0),
                    IdEstado = dr.GetInt32(1),
                    IdCliente = dr.GetInt32(2),
                    IdAdministrador = dr.GetInt32(3),
                    IdTipoFecha = dr.GetInt32(4)
                });
            }
        }
        catch (Exception ex) { Console.WriteLine($"[PedidoDA.Listar] {ex}"); }

        return lista;
    }
}
