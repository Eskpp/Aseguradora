namespace Aseguradora.Aplicacion.UseCase;
using Aseguradora.Aplicacion.Entities;
using Aseguradora.Aplicacion.Interfaces;
public class ListarTitularesConSusVehiculosUseCase
{
    private readonly IRepositorioTitular _repo;

    public ListarTitularesConSusVehiculosUseCase(IRepositorioTitular repo)
    {
        this._repo = repo;
    }
    public List<Titular> Ejecutar(){
        return _repo.ListarTitularesConSusVehiculos();
    }


    //igual a ListarTitularesUseCase, la unica diferencia esta en el metodo que invoca a este, se podria poner logica dentro del use case?
}