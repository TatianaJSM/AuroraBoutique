// -------------- DetallePedidoDA.cs --------------
using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;
using AplicacionWebAuroraBoutique.Modelo;

namespace AplicacionWebAuroraBoutique.DA.DataAccess;

public class DetallePedidoDA
{
    private readonly NpgsqlDataSource _ds = new NpgsqlDataSourceBuilder(DbConfig.ConnString).Build();

    public void Insertar(DetallePedido d)
    {
        const string sql = "CALL auroraschema.sp_insert_detalle_pedido(@p_pedido,@p_producto,@p_cant,@p_total)";
        try
        {
            using var cn = _ds.CreateConnection(); cn.Open();
            using var cmd = new NpgsqlCommand(sql, cn);

            cmd.Parameters.Add("@p_pedido", NpgsqlTypes.NpgsqlDbType.Integer).Value = d.IdPedido;
            cmd.Parameters.Add("@p_producto", NpgsqlTypes.NpgsqlDbType.Integer).Value = d.IdProducto;
            cmd.Parameters.Add("@p_cant", NpgsqlTypes.NpgsqlDbType.Integer).Value = d.Cantidad;
            cmd.Parameters.Add("@p_total", NpgsqlTypes.NpgsqlDbType.Numeric).Value = d.PrecioTotalIVA;

            cmd.ExecuteNonQuery();
        }
        catch (Exception ex) { Console.WriteLine($"[DetallePedidoDA.Insertar] {ex}"); }
    }
}
