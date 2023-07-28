namespace Aseguradora.Aplicacion.Interfaces;
using Aseguradora.Aplicacion.Entities;
public interface IRepositorioVehiculo
{
    void AgregarVehiculo(Vehiculo vehiculo);
    Vehiculo? GetVehiculo(int Id);
    void ModificarVehiculo(Vehiculo vehiculo);
    void EliminarVehiculo(int Id);
    List<Vehiculo> ListarVehiculos();

}