namespace AplicacionWebAuroraBoutique.Modelo;
public class DetallePedido
{
    public int IdDetalle { get; set; }
    public int IdPedido { get; set; }
    public int IdProducto { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioTotalIVA { get; set; }
}