namespace Aseguradora.Aplicacion.UseCase;
using Aseguradora.Aplicacion.Entities;
using Aseguradora.Aplicacion.Interfaces;
public class AgregarPolizaUseCase
{
    private readonly IRepositorioPoliza _repo;

    public AgregarPolizaUseCase(IRepositorioPoliza repo)
    {
        this._repo = repo;
    }
    public void Ejecutar(Poliza Poliza){
        _repo.AgregarPoliza(Poliza);
    }
}