namespace Aseguradora.Aplicacion.UseCase;
using Aseguradora.Aplicacion.Entities;
using Aseguradora.Aplicacion.Interfaces;
public class ObtenerPolizaUseCase
{
    private readonly IRepositorioPoliza _repo;

    public ObtenerPolizaUseCase(IRepositorioPoliza repo)
    {
        this._repo = repo;
    }
    public Poliza? Ejecutar(int id){
        return _repo.GetPoliza(id);
    }
}