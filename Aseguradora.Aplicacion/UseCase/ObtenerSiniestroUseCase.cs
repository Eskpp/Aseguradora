namespace Aseguradora.Aplicacion.UseCase;
using Aseguradora.Aplicacion.Entities;
using Aseguradora.Aplicacion.Interfaces;
public class ObtenerSiniestroUseCase
{
    private readonly IRepositorioSiniestro _repo;

    public ObtenerSiniestroUseCase(IRepositorioSiniestro repo)
    {
        this._repo = repo;
    }
    public Siniestro? Ejecutar(int id){
        return _repo.GetSiniestro(id);
    }
}