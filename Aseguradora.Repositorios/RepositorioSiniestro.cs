namespace Aseguradora.Repositorios;

using System.Collections.Generic;
using Aseguradora.Aplicacion.Interfaces;
using Aseguradora.Aplicacion.Entities;

public class RepositorioSiniestro : IRepositorioSiniestro
{
    private readonly AseguradoraContext _context;
    public RepositorioSiniestro(AseguradoraContext context)
    {
        _context = context;
    }
    public void AgregarSiniestro(Siniestro siniestro)
    {
        var poliza = _context.Polizas.SingleOrDefault(p => p.Id == siniestro.PolizaId); //obtengo poliza
        if (poliza != null)
        {
            if (poliza.FechaInicio <= siniestro.FechaOcurrencia && siniestro.FechaOcurrencia <= poliza.FechaFin)
            {
                _context.Add(siniestro);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("No habia cobertura de poliza durante la ocurrencia del siniestro.");
            }
        }
        else 
        {
            throw new Exception("No existe la poliza");
        }

    }

    public void EliminarSiniestro(int Id)
    {
        var SiniestroBorrar = _context.Siniestros.Where(s => s.Id == Id).SingleOrDefault();
        if (SiniestroBorrar != null)
        {
            _context.Remove(SiniestroBorrar);
            _context.SaveChanges();
        }
    }

    public Siniestro? GetSiniestro(int Id)
    {
        Siniestro? s = _context.Siniestros.SingleOrDefault(s => s.Id == Id);
        if (s != null)
        {
            return s;
        }
        return null;
    }

    public List<Siniestro> ListarSiniestros()
    {
        return _context.Siniestros.ToList();
    }

    public void ModificarSiniestro(Siniestro siniestro)
    {
        var SiniestroModificar = GetSiniestro(siniestro.Id);
        if (SiniestroModificar != null)
        {
            SiniestroModificar.PolizaId = siniestro.PolizaId;
            SiniestroModificar.FechaIngreso = siniestro.FechaIngreso;
            SiniestroModificar.FechaOcurrencia = siniestro.FechaOcurrencia;
            SiniestroModificar.Direccion = siniestro.Direccion;
            SiniestroModificar.Descripcion = siniestro.Descripcion;

            _context.SaveChanges();
        }
    }
}