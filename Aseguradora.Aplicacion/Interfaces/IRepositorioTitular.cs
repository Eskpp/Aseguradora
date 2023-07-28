namespace Aseguradora.Aplicacion.Interfaces;
using Aseguradora.Aplicacion.Entities;
public interface IRepositorioTitular
{
    void AgregarTitular(Titular titular);
    Titular? GetTitular(int id);
    void ModificarTitular(Titular titular);
    void EliminarTitular(int id);
    List<Titular> ListarTitulares();
    List<Titular> ListarTitularesConSusVehiculos();
    void AgregarVehiculoALista(Titular titular, Vehiculo vehiculo); //hace falta? depende de como maneje al vehiculo

}