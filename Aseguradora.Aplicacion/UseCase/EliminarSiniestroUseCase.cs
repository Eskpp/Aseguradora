namespace Aseguradora.Aplicacion.UseCase;
using Aseguradora.Aplicacion.Entities;
using Aseguradora.Aplicacion.Interfaces;
public class EliminarSiniestroUseCase
{
    private readonly IRepositorioSiniestro _repo;

    public EliminarSiniestroUseCase(IRepositorioSiniestro repo)
    {
        this._repo = repo;
    }
    public void Ejecutar(int id){
        _repo.EliminarSiniestro(id);
    }
}