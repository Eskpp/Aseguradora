namespace Aseguradora.Aplicacion.UseCase;
using Aseguradora.Aplicacion.Entities;
using Aseguradora.Aplicacion.Interfaces;
public class ListarTercerosUseCase
{
    private readonly IRepositorioTercero _repo;

    public ListarTercerosUseCase(IRepositorioTercero repo)
    {
        this._repo = repo;
    }
    public List<Tercero> Ejecutar(){
        return _repo.ListarTerceros();
    }
}