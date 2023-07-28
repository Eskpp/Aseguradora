namespace Aseguradora.Repositorios;
using Aseguradora.Aplicacion.Interfaces;
using Aseguradora.Aplicacion.Entities;
public class RepositorioVehiculoTXT : IRepositorioVehiculo
{
    readonly string _nombreArchivo = "Vehiculos.txt";
    readonly string _nombreArchivoAuxiliar = "auxVehiculos.txt";
    public RepositorioVehiculoTXT(){
        //en el constructor borro los archivos donde se persisten los datos para simular primera ejecucion donde no existen los archivos
        if (File.Exists(_nombreArchivo))
        {
            File.Delete(_nombreArchivo);
        }
        if (File.Exists(_nombreArchivoAuxiliar))
        {
            File.Delete(_nombreArchivoAuxiliar);
        }
    }
    public void AgregarVehiculo(Vehiculo vehiculo)
    {
        //me fijo si existe el archivo de la persistencia de datos
        if (File.Exists(_nombreArchivo))
        {
            //si existe cargo la lista de los archivos
            var lista = ListarVehiculos();
            //me fijo si existe algun vehiculo con el mismo dominio
            foreach (var item in lista)
            {
                if (item.Dominio == vehiculo.Dominio)
                {
                    throw new Exception($"Ya existe un vehiculo con el dominio: {vehiculo.Dominio}");
                }
            }
            //si no existe voy al ultimo elemento y me fijo el id
            vehiculo.Id = lista.Last().Id + 1;
        }
        else
        {
            //si no existe el archivo le asigno el id 1
            vehiculo.Id = 1;
        }

        using var sw = new StreamWriter(_nombreArchivo, true);
        sw.WriteLine(vehiculo.Id);
        sw.WriteLine(vehiculo.Dominio);
        sw.WriteLine(vehiculo.Marca);
        sw.WriteLine(vehiculo.Anio);
        sw.WriteLine(vehiculo.TitularId);
    }
    public void ModificarVehiculo(Vehiculo Vehiculo)
    {
        var lista = ListarVehiculos();
        try
        {
            foreach (Vehiculo v in lista)
            {
                if (v.Dominio == Vehiculo.Dominio)
                {
                    v.Marca = Vehiculo.Marca;
                    v.Anio = Vehiculo.Anio;
                    v.TitularId = Vehiculo.TitularId;
                    ActualizarLista(lista);
                    throw new Exception("Se modifico correctamente");
                }
            }
            throw new Exception("No se encontro el vehiculo");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    public void EliminarVehiculo(int id)
    {
        var lista = ListarVehiculos();
        try
        {
            foreach (Vehiculo v in lista)
            {
                if (v.Id == id)
                {
                    lista.Remove(v);
                    ActualizarLista(lista);
                    throw new Exception("Se elimino correctamente");
                }
            }
            throw new Exception("No se encontro el Vehiculo");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    public List<Vehiculo> ListarVehiculos()
    {
        List<Vehiculo> resultado = new List<Vehiculo>();
        using var sr = new StreamReader(_nombreArchivo);
        while (!sr.EndOfStream)
        {
            Vehiculo v = new Vehiculo();
            v.Id = int.Parse(sr.ReadLine() ?? "");
            v.Dominio = sr.ReadLine() ?? "";
            v.Marca = sr.ReadLine() ?? "";
            v.Anio = int.Parse(sr.ReadLine() ?? "");
            v.TitularId = int.Parse(sr.ReadLine() ?? "");
            resultado.Add(v);
        }
        return resultado;
    }

    private void ActualizarLista(List<Vehiculo> lista)
    {
        //si el archivo exite lo borro
        if (File.Exists(_nombreArchivoAuxiliar))
        {
            File.Delete(_nombreArchivoAuxiliar);
        }
        //Armo un archivo auxiliar con la modificacion hecha
        using var sw = new StreamWriter(_nombreArchivoAuxiliar, true);
        foreach (var Vehiculo in lista)
        {
            sw.WriteLine(Vehiculo.Id);
            sw.WriteLine(Vehiculo.Dominio);
            sw.WriteLine(Vehiculo.Marca);
            sw.WriteLine(Vehiculo.Anio);
            sw.WriteLine(Vehiculo.TitularId);
        }
        sw.Dispose(); //libero el archivo
        try
        {
            //escribo toda la lista devuelta con la modificacion hecha en el archivo principal
            using var sr = new StreamReader(_nombreArchivoAuxiliar);
            using var sw2 = new StreamWriter(_nombreArchivo, false);
            sw2.Write(sr.ReadToEnd());
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }

    Vehiculo? IRepositorioVehiculo.GetVehiculo(int Id)
    {
        throw new NotImplementedException();
    }
}
