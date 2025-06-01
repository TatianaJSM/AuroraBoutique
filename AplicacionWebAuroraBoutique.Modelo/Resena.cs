namespace AplicacionWebAuroraBoutique.Modelo;
public class Resena
{
    public int IdResena { get; set; }
    public int IdCliente { get; set; }
    public int IdProducto { get; set; }
    public int Calificacion { get; set; }
    public string Comentario { get; set; }
    public int IdPedido { get; set; }
    public int IdTipoFecha { get; set; }
}