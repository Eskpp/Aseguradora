namespace Aseguradora.Repositorios;
using Aseguradora.Aplicacion.Interfaces;
using Aseguradora.Aplicacion.Entities;
using System.Globalization;
public class RepositorioPolizaTXT : IRepositorioPoliza
{
    readonly string _nombreArchivo = "Polizas.txt";
    readonly string _nombreArchivoAuxiliar = "auxPolizas.txt";
    public RepositorioPolizaTXT()
    {
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
    public void AgregarPoliza(Poliza poliza)
    {
        //me fijo si existe el archivo de la persistencia de datos
        if (File.Exists(_nombreArchivo))
        {
            //si existe cargo la lista de los archivos
            var lista = ListarPolizas();
            //voy al ultimo elemento y me fijo el id
            poliza.Id = lista.Last().Id + 1;
        }
        else
        {
            //si no existe el archivo le asigno el id 1
            poliza.Id = 1;
        }
        using var sw = new StreamWriter(_nombreArchivo, true);
        sw.WriteLine(poliza.Id);
        sw.WriteLine(poliza.VehiculoId);
        sw.WriteLine(poliza.MontoAsegurado);
        sw.WriteLine(poliza.Franquicia);
        sw.WriteLine(poliza.Cobertura);
        sw.WriteLine(poliza.FechaInicio.Date);
        sw.WriteLine(poliza.FechaFin.Date);
    }
    public void ModificarPoliza(Poliza Poliza)
    {
        var lista = ListarPolizas();
        try
        {
            foreach (Poliza p in lista)
            {
                if (p.Id == Poliza.Id)
                {
                    p.VehiculoId = Poliza.VehiculoId;
                    p.MontoAsegurado = Poliza.MontoAsegurado;
                    p.Franquicia = Poliza.Franquicia;
                    p.Cobertura = Poliza.Cobertura;
                    p.FechaInicio = Poliza.FechaInicio;
                    p.FechaFin = Poliza.FechaFin;
                    ActualizarLista(lista);
                    throw new Exception("Se modifico correctamente");
                }
            }
            throw new Exception("No se encontro el Poliza");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    public void EliminarPoliza(int id)
    {
        var lista = ListarPolizas();
        try
        {
            foreach (Poliza p in lista)
            {
                if (p.Id == id)
                {
                    lista.Remove(p);
                    ActualizarLista(lista);
                    throw new Exception("Se elimino correctamente");
                }
            }
            throw new Exception("No se encontro la Poliza");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    public List<Poliza> ListarPolizas()
    {
        List<Poliza> resultado = new List<Poliza>();
        using var sr = new StreamReader(_nombreArchivo);
        while (!sr.EndOfStream)
        {
            Poliza p = new Poliza();
            p.Id = int.Parse(sr.ReadLine() ?? "");
            p.VehiculoId = int.Parse(sr.ReadLine() ?? "");
            p.MontoAsegurado = double.Parse(sr.ReadLine() ?? "");
            p.Franquicia = sr.ReadLine() ?? "";
            p.Cobertura = sr.ReadLine() ?? "";
            p.FechaInicio = DateTime.Parse(sr.ReadLine() ?? "");
            p.FechaFin = DateTime.Parse(sr.ReadLine() ?? "");
            resultado.Add(p);
        }
        return resultado;
    }

    private void ActualizarLista(List<Poliza> lista)
    {
        //si el archivo exite lo borro
        if (File.Exists(_nombreArchivoAuxiliar))
        {
            File.Delete(_nombreArchivoAuxiliar);
        }
        //Armo un archivo auxiliar con la modificacion hecha
        using var sw = new StreamWriter(_nombreArchivoAuxiliar, true);
        foreach (var Poliza in lista)
        {
            sw.WriteLine(Poliza.Id);
            sw.WriteLine(Poliza.VehiculoId);
            sw.WriteLine(Poliza.MontoAsegurado);
            sw.WriteLine(Poliza.Franquicia);
            sw.WriteLine(Poliza.Cobertura);
            sw.WriteLine(Poliza.FechaInicio);
            sw.WriteLine(Poliza.FechaFin);
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

    Poliza? IRepositorioPoliza.GetPoliza(int id)
    {
        throw new NotImplementedException();
    }

    Poliza? IRepositorioPoliza.GetPolizaDesdeVehiculo(int idVehiculo)
    {
        throw new NotImplementedException();
    }
}
