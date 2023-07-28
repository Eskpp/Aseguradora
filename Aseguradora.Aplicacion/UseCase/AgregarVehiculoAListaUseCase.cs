namespace Aseguradora.Aplicacion.UseCase;
using Aseguradora.Aplicacion.Entities;
using Aseguradora.Aplicacion.Interfaces;public class AgregarVehiculoAListaUseCase
{
    private readonly IRepositorioTitular _repo;

    public AgregarVehiculoAListaUseCase(IRepositorioTitular repo)
    {
        this._repo = repo;
    }
    public void Ejecutar(Titular titular, Vehiculo vehiculo){
        _repo.AgregarVehiculoALista(titular,vehiculo);
    }
}