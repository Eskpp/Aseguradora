namespace Aseguradora.Repositorios;

using System.Collections.Generic;
using Aseguradora.Aplicacion.Interfaces;
using Aseguradora.Aplicacion.Entities;

public class RepositorioVehiculo : IRepositorioVehiculo
{
    private readonly AseguradoraContext _context;
    public RepositorioVehiculo (AseguradoraContext context)
    {
        _context = context;
    }
    public void AgregarVehiculo(Vehiculo vehiculo)
    {
        _context.Add(vehiculo);
        _context.SaveChanges();
    }

    public void EliminarVehiculo(int Id)
    {
        var vehiculoBorrar = _context.Vehiculos.Where(v => v.Id == Id).SingleOrDefault();
        if (vehiculoBorrar != null)
        {
            _context.Remove(vehiculoBorrar);
            _context.SaveChanges();
        }
    }

    public Vehiculo? GetVehiculo(int Id)
    {
        Vehiculo? v = _context.Vehiculos.SingleOrDefault(v => v.Id == Id);
        if (v != null)
        {
            return v;
        }
        return null;
    }

    public List<Vehiculo> ListarVehiculos()
    {
        return _context.Vehiculos.ToList();
    }

    public void ModificarVehiculo(Vehiculo vehiculo)
    {
        var vehiculoModificar = GetVehiculo(vehiculo.Id);
        if (vehiculoModificar != null)
        {
            vehiculoModificar.Dominio = vehiculo.Dominio;
            vehiculoModificar.Marca = vehiculo.Marca;
            vehiculoModificar.Anio = vehiculo.Anio;
            vehiculoModificar.TitularId = vehiculo.TitularId;

            _context.SaveChanges();
        }
    }
}