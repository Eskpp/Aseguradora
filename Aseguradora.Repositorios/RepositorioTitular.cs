namespace Aseguradora.Repositorios;

using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Aseguradora.Aplicacion.Interfaces;
using Aseguradora.Aplicacion.Entities;

public class RepositorioTitular : IRepositorioTitular
{
    private readonly AseguradoraContext _context;

    public RepositorioTitular(AseguradoraContext context){
        _context = context;
    }

    public Titular? GetTitular(int id)
    {
        Titular? t = _context.Titulares.SingleOrDefault(t => t.Id == id);
        if (t != null)
        {
            return t;
        }
        return null;
    }

    public void AgregarTitular(Titular titular)
    {
        //puedo agregar verificacion
        _context.Add(titular);
        _context.SaveChanges();
    }

    public void AgregarVehiculoALista(Titular titular, Vehiculo vehiculo) //el vehiculo este aun no fue persistido, se le esta asignando el titularid
    {
        vehiculo.TitularId = titular.Id;            //guardo vehiculo aca? este metodo deberia estar aca? si solo le asigno el titular id, puedo hacerlo en otro lado?
    }

    public void EliminarTitular(int id)
    {
        var titularBorrar = _context.Titulares.Where(t => t.Id == id).SingleOrDefault();
        if (titularBorrar != null)
        {
            _context.Remove(titularBorrar);
            _context.SaveChanges();
        }
    }

    public List<Titular> ListarTitulares()
    {
        return _context.Titulares.ToList();
    }

    public List<Titular> ListarTitularesConSusVehiculos()
    {
        return _context.Titulares.Include(t => t.Vehiculos).ToList(); //devuelve la lista de titulares que incluye los vehiculos
    }

    public void ModificarTitular(Titular titular) //dato por parametro ya fue modificado
    {
        var titularModificar = _context.Titulares.Where(t => t.Dni.Equals(titular.Dni)).SingleOrDefault();
        if (titularModificar != null)
        {
            titularModificar.Apellido = titular.Apellido;
            titularModificar.Nombre = titular.Nombre;
            titularModificar.Telefono = titular.Telefono;
            titularModificar.Direccion = titular.Direccion;
            titularModificar.Email = titular.Email;

            _context.SaveChanges();
        }
    }
}