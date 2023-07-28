namespace Aseguradora.Aplicacion.UseCase;
using Aseguradora.Aplicacion.Entities;
using Aseguradora.Aplicacion.Interfaces;
public class ObtenerPolizaDesdeVehiculoUseCase
{
    private readonly IRepositorioPoliza _repo;

    public ObtenerPolizaDesdeVehiculoUseCase(IRepositorioPoliza repo)
    {
        this._repo = repo;
    }
    public Poliza? Ejecutar(int id){
        return _repo.GetPolizaDesdeVehiculo(id);
    }
}