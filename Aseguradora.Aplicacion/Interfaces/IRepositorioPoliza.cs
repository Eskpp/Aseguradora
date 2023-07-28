namespace Aseguradora.Aplicacion.Interfaces;
using Aseguradora.Aplicacion.Entities;
public interface IRepositorioPoliza
{
    void AgregarPoliza(Poliza titular);
    Poliza? GetPoliza(int id);
    Poliza? GetPolizaDesdeVehiculo(int idVehiculo);
    void ModificarPoliza(Poliza titular);
    void EliminarPoliza(int Id);
    List<Poliza> ListarPolizas();

}