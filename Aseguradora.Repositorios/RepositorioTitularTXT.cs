namespace Aseguradora.Repositorios;
using Aseguradora.Aplicacion.Interfaces;
using Aseguradora.Aplicacion.Entities;
public class RepositorioTitularTXT : IRepositorioTitular
{
    readonly string _nombreArchivo = "titulares.txt";
    readonly string _nombreArchivoAuxiliar = "auxtitulares.txt";

    public RepositorioTitularTXT(){
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



    public void AgregarTitular(Titular titular)
    {
        //me fijo si existe el archivo de la persistencia de datos
        if (File.Exists(_nombreArchivo))
        {
            //si existe cargo la lista de los archivos
            var lista = ListarTitulares();
            //me fijo si existe algun titular con el mismo dni
            foreach (var item in lista)
            {
                if (item.Dni == titular.Dni)
                {
                    throw new Exception($"Ya existe un titular con el DNI: {titular.Dni}");
                }
            }
            //si no existe voy al ultimo elemento y me fijo el id
            titular.Id = lista.Last().Id + 1;
        }
        else
        {
            //si no existe el archivo le asigno el id 1
            titular.Id = 1;
        }



/*      antes era asi

        var lista = ListarTitulares();
        //me fijo que no exista un titular con el dni
        foreach (var item in lista)
        {
            if (item.DNI == titular.DNI)
            {
                throw new Exception($"Ya existe un titular con el DNI = {titular.DNI}");
            }
        }
        //asigno id al titular
        if (lista.Any()) //si la lista tiene elementos voy al ultimo y me fijo su id
        {
            titular.Id = lista.Last().Id + 1;
        }
        else 
        {
            titular.Id = 1;//si no inicia en 1
        }
*/
        using var sw = new StreamWriter(_nombreArchivo, true);
        sw.WriteLine(titular.Id);
        sw.WriteLine(titular.Dni);
        sw.WriteLine(titular.Apellido);
        sw.WriteLine(titular.Nombre);
        sw.WriteLine(titular.Direccion);
        sw.WriteLine(titular.Telefono);
        sw.WriteLine(titular.Email);
    }
    public void ModificarTitular(Titular titular)
    {
        var lista = ListarTitulares();
        try
        {
            foreach (Titular t in lista)
            {
                if (t.Dni == titular.Dni)
                {
                    t.Apellido = titular.Apellido;
                    t.Nombre = titular.Nombre;
                    t.Direccion = titular.Direccion;
                    t.Telefono = titular.Telefono;
                    t.Email = titular.Email;
                    t.Vehiculos = titular.Vehiculos;
                    ActualizarLista(lista);
                    throw new Exception("Se modifico correctamente");
                }
            }
            throw new Exception("No se encontro el titular");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }


    }
    public void EliminarTitular(int id)
    {
        var lista = ListarTitulares();
        try
        {
            foreach (Titular t in lista)
            {
                if (t.Id == id)
                {
                    lista.Remove(t);
                    ActualizarLista(lista);
                    throw new Exception("Se elimino correctamente");
                }
            }
            throw new Exception("No se encontro el titular");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    public List<Titular> ListarTitulares()
    {
        List<Titular> resultado = new List<Titular>();
        using var sr = new StreamReader(_nombreArchivo);
        while (!sr.EndOfStream)
        {
            Titular t = new Titular();
            t.Id = int.Parse(sr.ReadLine() ?? "");
            t.Dni = sr.ReadLine() ?? "";
            t.Apellido = sr.ReadLine() ?? "";
            t.Nombre = sr.ReadLine() ?? "";
            t.Direccion = sr.ReadLine() ?? "";
            t.Telefono = sr.ReadLine() ?? "";
            t.Email = sr.ReadLine() ?? "";
            resultado.Add(t);
        }
        return resultado;
    }
    public List<Titular> ListarTitularesConSusVehiculos()
    {
        //igual al ListarTitulares()
        List<Titular> resultado = new List<Titular>();
        using var sr = new StreamReader(_nombreArchivo);
        while (!sr.EndOfStream)
        {
            Titular t = new Titular();
            t.Id = int.Parse(sr.ReadLine() ?? "");
            t.Dni = sr.ReadLine() ?? "";
            t.Apellido = sr.ReadLine() ?? "";
            t.Nombre = sr.ReadLine() ?? "";
            t.Direccion = sr.ReadLine() ?? "";
            t.Telefono = sr.ReadLine() ?? "";
            t.Email = sr.ReadLine() ?? "";
            resultado.Add(t);
        }
        return resultado;
    }
    private void ActualizarLista(List<Titular> lista)
    {
        //si el archivo exite lo borro
        if (File.Exists(_nombreArchivoAuxiliar))
        {
            File.Delete(_nombreArchivoAuxiliar);
        }        
        //Armo un archivo auxiliar con la modificacion hecha
        using var sw = new StreamWriter(_nombreArchivoAuxiliar, true);
        foreach (var titular in lista)
        {
            sw.WriteLine(titular.Id);
            sw.WriteLine(titular.Dni);
            sw.WriteLine(titular.Apellido);
            sw.WriteLine(titular.Nombre);
            sw.WriteLine(titular.Direccion);
            sw.WriteLine(titular.Telefono);
            sw.WriteLine(titular.Email);
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

    public void AgregarVehiculoALista(Titular titular, Vehiculo vehiculo)
    {
        vehiculo.TitularId = titular.Id;
        titular.Vehiculos?.Add(vehiculo);
    }

    public Titular? GetTitular(int id)
    {
        throw new NotImplementedException();
    }
}
