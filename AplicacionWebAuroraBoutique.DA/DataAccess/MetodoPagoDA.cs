// -------------- MetodoPagoDA.cs --------------
using System;
using System.Collections.Generic;
using Npgsql;
using AplicacionWebAuroraBoutique.Modelo;

namespace AplicacionWebAuroraBoutique.DA.DataAccess;

public class MetodoPagoDA
{
    private readonly NpgsqlDataSource _ds = new NpgsqlDataSourceBuilder(DbConfig.ConnString).Build();

    public IEnumerable<MetodoPago> Listar()
    {
        const string sql = "SELECT id_metodo_pago, pago FROM auroraschema.metodo_pago;";
        var lista = new List<MetodoPago>();

        try
        {
            using var cn = _ds.CreateConnection(); cn.Open();
            using var cmd = new NpgsqlCommand(sql, cn);
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
        catch (Exception ex) { Console.WriteLine($"[MetodoPagoDA.Listar] {ex}"); }

        return lista;
    }
}
