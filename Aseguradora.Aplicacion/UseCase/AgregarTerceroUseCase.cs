namespace Aseguradora.Aplicacion.UseCase;
using Aseguradora.Aplicacion.Entities;
using Aseguradora.Aplicacion.Interfaces;
public class AgregarTerceroUseCase
{
    private readonly IRepositorioTercero _repo;

    public AgregarTerceroUseCase(IRepositorioTercero repo)
    {
        this._repo = repo;
    }
    public void Ejecutar(Tercero Tercero){
        _repo.AgregarTercero(Tercero);
    }
}