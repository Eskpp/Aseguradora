namespace Aseguradora.Aplicacion.UseCase;
using Aseguradora.Aplicacion.Entities;
using Aseguradora.Aplicacion.Interfaces;
public class ListarVehiculosUseCase
{
    private readonly IRepositorioVehiculo _repo;

    public ListarVehiculosUseCase(IRepositorioVehiculo repo)
    {
        this._repo = repo;
    }
    public List<Vehiculo> Ejecutar(){
        return _repo.ListarVehiculos();
    }
}