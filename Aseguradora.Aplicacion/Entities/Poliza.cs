namespace Aseguradora.Aplicacion.Entities;
public class Poliza
{
    public int Id { get; set; }
    public int VehiculoId { get; set; }
    public double MontoAsegurado { get; set; }
    public string? Franquicia { get; set; }
    public string Cobertura { get; set; } = "Responsabilidad civil";
    public DateTime FechaInicio { get; set; } = DateTime.Today;
    public DateTime FechaFin { get; set; } = DateTime.Today;

    public Poliza(double monto, string franquicia)
    {
        this.MontoAsegurado = monto;
        this.Franquicia = franquicia;
    }

    public Poliza()
    {
        
    }

    public override string ToString()
    {
        return $"{Id}: Id del vehiculo: {VehiculoId}, Franquicia: {Franquicia}, Monto asegurado: {MontoAsegurado}, Cobertura: {Cobertura}, Fecha inicio de vigencia: {FechaInicio.ToShortDateString}, Fecha fin de vigencia: {FechaFin.ToShortDateString}";
    }

}