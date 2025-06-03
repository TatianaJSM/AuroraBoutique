using AplicacionWebAuroraBoutique.Modelo;
using Npgsql;

namespace AplicacionWebAuroraBoutique.DA.DataAccess;

public class TipoFechaDA
{
    public IEnumerable<TipoFecha> Listar()
    {
        const string sql = "SELECT id_tipo_fecha, id_cliente, dia, mes, anio, tipo_evento FROM auroraschema.tipo_fecha";
        var lista = new List<TipoFecha>();

        try
        {
            using var conn = PostgresConnectionFactory.Create();
            conn.Open();
            using var cmd = new NpgsqlCommand(sql, conn);
            using var dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                lista.Add(new TipoFecha
                {
                    IdTipoFecha = dr.GetInt32(0),
                    IdCliente = dr.GetInt32(1),
                    Dia = dr.GetInt32(2),
                    Mes = dr.GetInt32(3),
                    Anio = dr.GetInt32(4),
                    TipoEvento = dr.GetString(5)
                });
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[TipoFechaDA.Listar] {ex.Message}");
        }

        return lista;
    }
}
