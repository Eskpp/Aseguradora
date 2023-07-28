namespace Aseguradora.Aplicacion.UseCase;
using Aseguradora.Aplicacion.Entities;
using Aseguradora.Aplicacion.Interfaces;
public class AgregarSiniestroUseCase
{
    private readonly IRepositorioSiniestro _repo;

    public AgregarSiniestroUseCase(IRepositorioSiniestro repo)
    {
        this._repo = repo;
    }
    public void Ejecutar(Siniestro Siniestro){
        _repo.AgregarSiniestro(Siniestro);
    }
}