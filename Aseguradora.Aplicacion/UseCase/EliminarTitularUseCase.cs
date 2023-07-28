namespace Aseguradora.Aplicacion.UseCase;
using Aseguradora.Aplicacion.Entities;
using Aseguradora.Aplicacion.Interfaces;
public class EliminarTitularUseCase
{
    private readonly IRepositorioTitular _repo;

    public EliminarTitularUseCase(IRepositorioTitular repo)
    {
        this._repo = repo;
    }
    public void Ejecutar(int Id){
        _repo.EliminarTitular(Id);
    }
}