namespace Aseguradora.Aplicacion.Entities;
public class Vehiculo
{
    public int Id { get; set; }
    public string Dominio { get; set; } = "";
    public string? Marca { get; set; }
    public int? Anio { get; set; }
    public int TitularId { get; set; }

    public Vehiculo(string dominio)
    {
        this.Dominio = dominio;
    }

    public Vehiculo(){

    }

    public override string ToString()
    {
        return $"{Id}: {Dominio} {Marca} Año fabricación: {Anio}, Id del titular: {TitularId}";
    }
}