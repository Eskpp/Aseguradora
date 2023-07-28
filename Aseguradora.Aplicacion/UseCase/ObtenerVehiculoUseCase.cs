namespace Aseguradora.Aplicacion.UseCase;
using Aseguradora.Aplicacion.Entities;
using Aseguradora.Aplicacion.Interfaces;
public class ObtenerVehiculoUseCase
{
    private readonly IRepositorioVehiculo _repo;

    public ObtenerVehiculoUseCase(IRepositorioVehiculo repo)
    {
        this._repo = repo;
    }
    public Vehiculo? Ejecutar(int id){
        return _repo.GetVehiculo(id);
    }
}