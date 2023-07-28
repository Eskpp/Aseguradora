namespace Aseguradora.Aplicacion.UseCase;
using Aseguradora.Aplicacion.Entities;
using Aseguradora.Aplicacion.Interfaces;
public class AgregarVehiculoUseCase
{
    private readonly IRepositorioVehiculo _repo;

    public AgregarVehiculoUseCase(IRepositorioVehiculo repo)
    {
        this._repo = repo;
    }
    public void Ejecutar(Vehiculo Vehiculo){
        _repo.AgregarVehiculo(Vehiculo);
    }
}