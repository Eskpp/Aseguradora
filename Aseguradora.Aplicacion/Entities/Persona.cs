namespace Aseguradora.Aplicacion.Entities;
public abstract class Persona 
{
    public int Id { get; set; }
    public string Dni { get; set; } = "";
    public string Apellido { get; set; } = "";
    public string Nombre { get; set; } = "";
    public string Telefono { get; set; } = "";
}