namespace Aseguradora.Aplicacion.Interfaces;
using Aseguradora.Aplicacion.Entities;
public interface IRepositorioTercero
{
    void AgregarTercero(Tercero Tercero);
    Tercero? GetTercero(int Id);
    void ModificarTercero(Tercero Tercero);
    void EliminarTercero(int Id);
    List<Tercero> ListarTerceros();

}