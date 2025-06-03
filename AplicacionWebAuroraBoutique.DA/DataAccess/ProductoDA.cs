using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;
using AplicacionWebAuroraBoutique.Modelo;

namespace AplicacionWebAuroraBoutique.DA.DataAccess;

public class ProductoDA
{
    private readonly NpgsqlDataSource _ds = new NpgsqlDataSourceBuilder(DbConfig.ConnString).Build();

    // ---------- INSERT ----------
    public void Insertar(Producto p)
    {
        const string sql = "CALL auroraschema.sp_insert_producto(" +
                           "@p_nombre,@p_desc,@p_precio,@p_stock,@p_categoria,@p_admin)";

        try
        {
            using var cn = _ds.CreateConnection();
            cn.Open();
            using var cmd = new NpgsqlCommand(sql, cn) { CommandType = CommandType.Text };

            cmd.Parameters.Add("@p_nombre", NpgsqlTypes.NpgsqlDbType.Varchar).Value = p.Nombre;
            cmd.Parameters.Add("@p_desc", NpgsqlTypes.NpgsqlDbType.Varchar).Value = p.Descripcion;
            cmd.Parameters.Add("@p_precio", NpgsqlTypes.NpgsqlDbType.Numeric).Value = p.Precio;
            cmd.Parameters.Add("@p_stock", NpgsqlTypes.NpgsqlDbType.Integer).Value = p.CantidadStock;
            cmd.Parameters.Add("@p_categoria", NpgsqlTypes.NpgsqlDbType.Integer).Value = p.IdCategoria;
            cmd.Parameters.Add("@p_admin", NpgsqlTypes.NpgsqlDbType.Integer).Value = p.IdAdministrador;

            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ProductoDA.Insertar] {ex}");
        }
    }

    // ---------- LISTAR ----------
    public IEnumerable<Producto> Listar()
    {
        const string sql = """
            SELECT id_producto,nombre,descripcion,precio,cantidad_stock,id_categoria,id_administrador
            FROM   auroraschema.productos
            """;

        var lista = new List<Producto>();

        try
        {
            using var cn = _ds.CreateConnection();
            cn.Open();
            using var cmd = new NpgsqlCommand(sql, cn);
            using var dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                lista.Add(new Producto
                {
                    IdProducto = dr.GetInt32(0),
                    Nombre = dr.GetString(1),
                    Descripcion = dr.GetString(2),
                    Precio = dr.GetDecimal(3),
                    CantidadStock = dr.GetInt32(4),
                    IdCategoria = dr.GetInt32(5),
                    IdAdministrador = dr.GetInt32(6)
                });
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ProductoDA.Listar] {ex}");
            // MOCK opcional cuando la BD está offline
            lista.Add(new Producto
            {
                IdProducto = 0,
                Nombre = "Producto demo",
                Descripcion = "offline",
                Precio = 0,
                CantidadStock = 0,
                IdCategoria = 0,
                IdAdministrador = 0
            });
        }

        return lista;
    }
}
