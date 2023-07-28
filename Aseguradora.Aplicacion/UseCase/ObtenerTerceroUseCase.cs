namespace Aseguradora.Aplicacion.UseCase;
using Aseguradora.Aplicacion.Entities;
using Aseguradora.Aplicacion.Interfaces;
public class ObtenerTerceroUseCase
{
    private readonly IRepositorioTercero _repo;

    public ObtenerTerceroUseCase(IRepositorioTercero repo)
    {
        this._repo = repo;
    }
    public Tercero? Ejecutar(int id){
        return _repo.GetTercero(id);
    }
}