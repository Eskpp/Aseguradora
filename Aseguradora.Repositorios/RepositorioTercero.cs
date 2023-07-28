namespace Aseguradora.Repositorios;

using System.Collections.Generic;
using Aseguradora.Aplicacion.Interfaces;
using Aseguradora.Aplicacion.Entities;

public class RepositorioTercero : IRepositorioTercero
{
    private readonly AseguradoraContext _context;
    public RepositorioTercero (AseguradoraContext context)
    {
        _context = context;
    }
    public void AgregarTercero(Tercero tercero)
    {
        _context.Add(tercero);
        _context.SaveChanges();
    }

    public void EliminarTercero(int Id)
    {
        var TerceroBorrar = _context.Terceros.Where(t => t.Id == Id).SingleOrDefault();
        if (TerceroBorrar != null)
        {
            _context.Remove(TerceroBorrar);
            _context.SaveChanges();
        }
    }

    public Tercero? GetTercero(int Id)
    {
        Tercero? t = _context.Terceros.SingleOrDefault(t => t.Id == Id);
        if (t != null)
        {
            return t;
        }
        return null;
    }

    public List<Tercero> ListarTerceros()
    {
        return _context.Terceros.ToList();
    }

    public void ModificarTercero(Tercero Tercero)
    {
        var TerceroModificar = GetTercero(Tercero.Id);
        if (TerceroModificar != null)
        {
            TerceroModificar.Dni = Tercero.Dni;
            TerceroModificar.Nombre = Tercero.Nombre;
            TerceroModificar.Apellido = Tercero.Apellido;
            TerceroModificar.Aseguradora = Tercero.Aseguradora;
            TerceroModificar.SiniestroID = Tercero.SiniestroID;
            TerceroModificar.Telefono = Tercero.Telefono;

            _context.SaveChanges();
        }
    }
}