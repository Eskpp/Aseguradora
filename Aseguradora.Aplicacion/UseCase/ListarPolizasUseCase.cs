namespace Aseguradora.Aplicacion.UseCase;
using Aseguradora.Aplicacion.Entities;
using Aseguradora.Aplicacion.Interfaces;
public class ListarPolizasUseCase
{
    private readonly IRepositorioPoliza _repo;

    public ListarPolizasUseCase(IRepositorioPoliza repo)
    {
        this._repo = repo;
    }
    public List<Poliza> Ejecutar(){
        return _repo.ListarPolizas();
    }
}