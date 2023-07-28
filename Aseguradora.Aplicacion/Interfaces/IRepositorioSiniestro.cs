namespace Aseguradora.Aplicacion.Interfaces;
using Aseguradora.Aplicacion.Entities;
public interface IRepositorioSiniestro
{
    void AgregarSiniestro(Siniestro Siniestro);
    Siniestro? GetSiniestro(int Id);
    void ModificarSiniestro(Siniestro Siniestro);
    void EliminarSiniestro(int Id);
    List<Siniestro> ListarSiniestros();

}