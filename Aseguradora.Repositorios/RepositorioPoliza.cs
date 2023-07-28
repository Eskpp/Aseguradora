namespace Aseguradora.Repositorios;

using System.Collections.Generic;
using Aseguradora.Aplicacion.Interfaces;
using Aseguradora.Aplicacion.Entities;

public class RepositorioPoliza : IRepositorioPoliza
{
    private readonly AseguradoraContext _context;
    public RepositorioPoliza (AseguradoraContext context)
    {
        _context = context;
    }
    public void AgregarPoliza(Poliza poliza)
    {
        _context.Add(poliza);
        _context.SaveChanges();
    }

    public void EliminarPoliza(int Id)
    {
        var polizaBorrar = _context.Polizas.Where(p => p.Id == Id).SingleOrDefault();
        if (polizaBorrar != null)
        {
            _context.Remove(polizaBorrar);
            _context.SaveChanges();
        }
    }

    public Poliza? GetPoliza(int Id)
    {
        Poliza? p = _context.Polizas.SingleOrDefault(p => p.Id == Id);
        if (p != null)
        {
            return p;
        }
        return null;
    }

    public List<Poliza> ListarPolizas()
    {
        return _context.Polizas.ToList();
    }

    public void ModificarPoliza(Poliza poliza)
    {
        var polizaModificar = GetPoliza(poliza.Id);
        if (polizaModificar != null)
        {
            polizaModificar.VehiculoId = poliza.VehiculoId;
            polizaModificar.MontoAsegurado = poliza.MontoAsegurado;
            polizaModificar.Franquicia = poliza.Franquicia;
            polizaModificar.Cobertura = poliza.Cobertura;
            polizaModificar.FechaInicio = poliza.FechaInicio;
            polizaModificar.FechaFin = poliza.FechaFin;

            _context.SaveChanges();
        }
    }

    Poliza? IRepositorioPoliza.GetPolizaDesdeVehiculo(int idVehiculo)
    {
        Poliza? p = _context.Polizas.SingleOrDefault(p => p.VehiculoId == idVehiculo);
        if (p != null)
        {
            return p;
        }
        return null;
    }
}