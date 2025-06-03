// -------------- InventarioMovimientoDA.cs --------------
using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;
using AplicacionWebAuroraBoutique.Modelo;

namespace AplicacionWebAuroraBoutique.DA.DataAccess;

public class InventarioMovimientoDA
{
    private readonly NpgsqlDataSource _ds = new NpgsqlDataSourceBuilder(DbConfig.ConnString).Build();

    public void Registrar(InventarioMovimiento m)
    {
        const string sql = "CALL auroraschema.sp_mov_inv(@p_prod,@p_tipo,@p_cant,@p_admin,@p_tipo_fecha)";
        try
        {
            using var cn = _ds.CreateConnection(); cn.Open();
            using var cmd = new NpgsqlCommand(sql, cn);

            cmd.Parameters.Add("@p_prod", NpgsqlTypes.NpgsqlDbType.Integer).Value = m.IdProducto;
            cmd.Parameters.Add("@p_tipo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = m.TipoMovimiento;
            cmd.Parameters.Add("@p_cant", NpgsqlTypes.NpgsqlDbType.Integer).Value = m.Cantidad;
            cmd.Parameters.Add("@p_admin", NpgsqlTypes.NpgsqlDbType.Integer).Value = m.IdAdministrador;
            cmd.Parameters.Add("@p_tipo_fecha", NpgsqlTypes.NpgsqlDbType.Integer).Value = m.IdTipoFecha;

            cmd.ExecuteNonQuery();
        }
        catch (Exception ex) { Console.WriteLine($"[InventarioMovimientoDA.Registrar] {ex}"); }
    }
}
