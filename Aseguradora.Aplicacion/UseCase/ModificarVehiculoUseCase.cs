namespace Aseguradora.Aplicacion.UseCase;
using Aseguradora.Aplicacion.Entities;
using Aseguradora.Aplicacion.Interfaces;
public class ModificarVehiculoUseCase
{
    private readonly IRepositorioVehiculo _repo;

    public ModificarVehiculoUseCase(IRepositorioVehiculo repo)
    {
        this._repo = repo;
    }
    public void Ejecutar(Vehiculo Vehiculo){
        _repo.ModificarVehiculo(Vehiculo);
    }
}