// -------------- ResenaDA.cs --------------
using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;
using AplicacionWebAuroraBoutique.Modelo;

namespace AplicacionWebAuroraBoutique.DA.DataAccess;

public class ResenaDA
{
    private readonly NpgsqlDataSource _ds = new NpgsqlDataSourceBuilder(DbConfig.ConnString).Build();

    public void Insertar(Resena r)
    {
        const string sql =
            "CALL auroraschema.sp_insert_resena(@p_cliente,@p_producto,@p_pedido,@p_com,@p_calif,@p_tipo_fecha)";

        try
        {
            using var cn = _ds.CreateConnection(); cn.Open();
            using var cmd = new NpgsqlCommand(sql, cn);

            cmd.Parameters.Add("@p_cliente", NpgsqlTypes.NpgsqlDbType.Integer).Value = r.IdCliente;
            cmd.Parameters.Add("@p_producto", NpgsqlTypes.NpgsqlDbType.Integer).Value = r.IdProducto;
            cmd.Parameters.Add("@p_pedido", NpgsqlTypes.NpgsqlDbType.Integer).Value = r.IdPedido;
            cmd.Parameters.Add("@p_com", NpgsqlTypes.NpgsqlDbType.Varchar).Value = r.Comentario;
            cmd.Parameters.Add("@p_calif", NpgsqlTypes.NpgsqlDbType.Integer).Value = r.Calificacion;
            cmd.Parameters.Add("@p_tipo_fecha", NpgsqlTypes.NpgsqlDbType.Integer).Value = r.IdTipoFecha;

            cmd.ExecuteNonQuery();
        }
        catch (Exception ex) { Console.WriteLine($"[ResenaDA.Insertar] {ex}"); }
    }

    public IEnumerable<Resena> ListarPorProducto(int idProducto)
    {
        const string sql = """
            SELECT id_resena,id_cliente,calificacion,comentario,id_pedido,id_tipo_fecha
            FROM   auroraschema.resena
            WHERE  id_producto = @p_prod;
        """;

        var lista = new List<Resena>();
        try
        {
            using var cn = _ds.CreateConnection(); cn.Open();
            using var cmd = new NpgsqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@p_prod", idProducto);

            using var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new Resena
                {
                    IdResena = dr.GetInt32(0),
                    IdCliente = dr.GetInt32(1),
                    Calificacion = dr.GetInt32(2),
                    Comentario = dr.GetString(3),
                    IdPedido = dr.GetInt32(4),
                    IdTipoFecha = dr.GetInt32(5),
                    IdProducto = idProducto
                });
            }
        }
        catch (Exception ex) { Console.WriteLine($"[ResenaDA.Listar] {ex}"); }
        return lista;
    }
}
