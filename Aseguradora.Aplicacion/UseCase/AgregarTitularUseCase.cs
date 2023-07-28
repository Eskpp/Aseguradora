namespace Aseguradora.Aplicacion.UseCase;
using Aseguradora.Aplicacion.Entities;
using Aseguradora.Aplicacion.Interfaces;
public class AgregarTitularUseCase
{
    private readonly IRepositorioTitular _repo;

    public AgregarTitularUseCase(IRepositorioTitular repo)
    {
        this._repo = repo;
    }
    public void Ejecutar(Titular titular){
        _repo.AgregarTitular(titular);
    }
}