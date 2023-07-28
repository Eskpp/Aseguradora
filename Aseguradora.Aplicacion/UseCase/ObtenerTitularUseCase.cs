namespace Aseguradora.Aplicacion.UseCase;
using Aseguradora.Aplicacion.Entities;
using Aseguradora.Aplicacion.Interfaces;
public class ObtenerTitularUseCase
{
    private readonly IRepositorioTitular _repo;

    public ObtenerTitularUseCase(IRepositorioTitular repo)
    {
        this._repo = repo;
    }
    public Titular? Ejecutar(int id){
        return _repo.GetTitular(id);
    }
}