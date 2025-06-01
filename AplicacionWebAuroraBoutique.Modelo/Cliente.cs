namespace AplicacionWebAuroraBoutique.Modelo; 
public class Cliente
{
    public int IdCliente { get; set; }
    public string Nombre { get; set; }
    public string PrimerApellido { get; set; }
    public string SegundoApellido { get; set; }
    public bool ClienteConDescuentoProximaFacturacion { get; set; }
}