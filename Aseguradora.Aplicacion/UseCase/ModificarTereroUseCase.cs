namespace Aseguradora.Aplicacion.UseCase;
using Aseguradora.Aplicacion.Entities;
using Aseguradora.Aplicacion.Interfaces;
public class ModificarTerceroUseCase
{
    private readonly IRepositorioTercero _repo;

    public ModificarTerceroUseCase(IRepositorioTercero repo)
    {
        this._repo = repo;
    }
    public void Ejecutar(Tercero Tercero){
        _repo.ModificarTercero(Tercero);
    }
}