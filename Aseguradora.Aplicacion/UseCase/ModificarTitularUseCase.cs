namespace Aseguradora.Aplicacion.UseCase;
using Aseguradora.Aplicacion.Entities;
using Aseguradora.Aplicacion.Interfaces;
public class ModificarTitularUseCase
{
    private readonly IRepositorioTitular _repo;

    public ModificarTitularUseCase(IRepositorioTitular repo)
    {
        this._repo = repo;
    }
    public void Ejecutar(Titular titular){
        _repo.ModificarTitular(titular);
    }
}