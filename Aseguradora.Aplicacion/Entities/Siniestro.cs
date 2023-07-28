namespace Aseguradora.Aplicacion.Entities;
public class Siniestro
{
    public int Id { get; set; }
    public int PolizaId { get; set; }
    public DateTime FechaIngreso { get; set; } = DateTime.Now;
    public DateTime FechaOcurrencia { get; set; } = DateTime.Now;
    public string Direccion { get; set; } = "";
    public string? Descripcion { get; set; }
}