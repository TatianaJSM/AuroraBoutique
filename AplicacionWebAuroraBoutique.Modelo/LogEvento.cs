namespace AplicacionWebAuroraBoutique.Modelo;
public class LogEvento
{
    public int IdLog { get; set; }
    public string TipoEvento { get; set; }
    public string Descripcion { get; set; }
    public DateTime FechaEvento { get; set; }
    public int? IdCliente { get; set; }
    public int? IdAdministrador { get; set; }
    public int? IdPersonalEnvio { get; set; }
}