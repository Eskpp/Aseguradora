namespace Aseguradora.Aplicacion.UseCase;
using Aseguradora.Aplicacion.Entities;
using Aseguradora.Aplicacion.Interfaces;
public class ModificarPolizaUseCase
{
    private readonly IRepositorioPoliza _repo;

    public ModificarPolizaUseCase(IRepositorioPoliza repo)
    {
        this._repo = repo;
    }
    public void Ejecutar(Poliza Poliza){
        _repo.ModificarPoliza(Poliza);
    }
}