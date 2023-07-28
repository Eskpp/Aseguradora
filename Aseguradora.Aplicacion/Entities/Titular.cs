namespace Aseguradora.Aplicacion.Entities;
public class Titular : Persona
{
    public string? Direccion { get; set; }
    public string? Email { get; set; }
    public List<Vehiculo>? Vehiculos { get; set; } // asi o fijarse si hace falta inicializarlo

    public Titular(string dni, string apellido, string nombre, string telefono)
    {
        this.Dni = dni;
        this.Apellido = apellido;
        this.Nombre = nombre;
        this.Telefono = telefono;
    }

    public Titular(){
        
    }

    public override string ToString()
    {
        return $"{Id}: {Dni} {Apellido}, {Nombre} {Direccion} {Telefono} {Email}";
    }

}
