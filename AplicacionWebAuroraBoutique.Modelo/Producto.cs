namespace AplicacionWebAuroraBoutique.Modelo;
public class Producto
{
    public int IdProducto { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public decimal Precio { get; set; }
    public int CantidadStock { get; set; }
    public int IdCategoria { get; set; }
    public int IdAdministrador { get; set; }
}