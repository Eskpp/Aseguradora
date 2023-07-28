namespace Aseguradora.Repositorios;

using Microsoft.EntityFrameworkCore;
using Aseguradora.Aplicacion.Entities;

public class Inicializador
{
    public static void Ejecutar()
    {
        using (var context = new AseguradoraContext())
        {
            context.Database.EnsureCreated();
            if (context.Titulares.Count() > 0) //si ya fue inicializada
            {
                return;
            }

            context.Add(new Titular() {Dni ="1000000", Apellido="Argamonte", Nombre = "Santiago", Telefono="+54911123456"});
            context.Add(new Titular() {Dni ="2222222", Apellido="Casas", Nombre = "Facundo", Telefono="+549296423456"});
            context.Add(new Titular() {Dni ="1231231", Apellido="Aguirre", Nombre = "Malena", Telefono="+549221123456"});

            context.SaveChanges();
        }
    }
}