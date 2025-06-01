namespace AplicacionWebAuroraBoutique.Modelo;
public class HistorialTransaccion
{
    public int IdTransaccion { get; set; }
    public int IdPedido { get; set; }
    public int IdMetodoPago { get; set; }
    public decimal Monto { get; set; }
    public int IdTipoFecha { get; set; }
}