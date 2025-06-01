namespace AplicacionWebAuroraBoutique.Modelo;
public class InventarioMovimiento
{
    public int IdMovimiento { get; set; }
    public int IdProducto { get; set; }
    public string TipoMovimiento { get; set; }
    public int Cantidad { get; set; }
    public int IdAdministrador { get; set; }
    public int IdTipoFecha { get; set; }
}