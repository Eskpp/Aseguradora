namespace Aseguradora.Aplicacion.UseCase;
using Aseguradora.Aplicacion.Entities;
using Aseguradora.Aplicacion.Interfaces;
public class ModificarSiniestroUseCase
{
    private readonly IRepositorioSiniestro _repo;

    public ModificarSiniestroUseCase(IRepositorioSiniestro repo)
    {
        this._repo = repo;
    }
    public void Ejecutar(Siniestro Siniestro){
        _repo.ModificarSiniestro(Siniestro);
    }
}