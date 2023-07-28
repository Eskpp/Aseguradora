/*using Aseguradora.Repositorios;
using Aseguradora.Aplicacion.Entities;
using Aseguradora.Aplicacion.UseCase;

RepositorioTitularTXT repoTitular = new RepositorioTitularTXT();
AgregarTitularUseCase agregarTitular = new AgregarTitularUseCase(repoTitular);
ListarTitularesUseCase listarTitulares = new ListarTitularesUseCase(repoTitular);
ModificarTitularUseCase modificarTitular = new ModificarTitularUseCase(repoTitular);
EliminarTitularUseCase eliminarTitular = new EliminarTitularUseCase(repoTitular);
ListarTitularesConSusVehiculosUseCase listarTitularesConSusVehiculos = new ListarTitularesConSusVehiculosUseCase(repoTitular);
AgregarVehiculoAListaUseCase agregarVehiculoALista = new AgregarVehiculoAListaUseCase(repoTitular);

RepositorioVehiculoTXT repoVehiculo = new RepositorioVehiculoTXT();
AgregarVehiculoUseCase agregarVehiculo = new AgregarVehiculoUseCase(repoVehiculo);
ListarVehiculosUseCase listarVehiculos = new ListarVehiculosUseCase(repoVehiculo);
ModificarVehiculoUseCase modificarVehiculo = new ModificarVehiculoUseCase(repoVehiculo);
EliminarVehiculoUseCase eliminarVehiculo = new EliminarVehiculoUseCase(repoVehiculo);

RepositorioPolizaTXT repoPoliza = new RepositorioPolizaTXT();
AgregarPolizaUseCase agregarPoliza = new AgregarPolizaUseCase(repoPoliza);
ListarPolizasUseCase listarPolizas = new ListarPolizasUseCase(repoPoliza);
ModificarPolizaUseCase modificarPoliza = new ModificarPolizaUseCase(repoPoliza);
EliminarPolizaUseCase eliminarPoliza = new EliminarPolizaUseCase(repoPoliza);

//Se instancia un titular
Titular titular = new Titular("40123456","Argamonte","Santiago","1234")
{
    Direccion = "40 nro. 123",
    Telefono = "221-12345678",
    Email = "santiagoargamonte@gmail.com"
};

//se inicializa sin id
Console.WriteLine($"Id del titular instanciado: {titular.Id}");

//persistimos el titular instanciado
PersistirTitular(titular);

//vemos el id nuevamente
Console.WriteLine($"El id del titular persistido es: {titular.Id}");

PersistirTitular(new Titular("12345678","Aguirre","Malena","1234"));
PersistirTitular(new Titular("23456789","Collinao","Javier","1234"));
PersistirTitular(new Titular("34567891","Ferreyra","Lucrecia","1234"));

ListarTitulares();

//intentando agregar un titular con el mismo dni que uno ya existente
Console.WriteLine("intentando agregar un titular con el mismo dni que uno ya existente");
Titular titular2 = new Titular("12345678","Iglesias","Guillermina","1234");
PersistirTitular(titular2);

//modificando uno ya existente
Console.WriteLine("modificando uno ya existente");
modificarTitular.Ejecutar(titular2);

ListarTitulares();

//Eliminando titular de id 2
Console.WriteLine("Eliminando titular de id 2");
eliminarTitular.Ejecutar(2);

ListarTitulares();



Console.WriteLine("----------Vehiculos----------");


//lo mismo con vehiculos
Vehiculo vehiculo = new Vehiculo("ABC123")
{
    Marca = "Fiat",
    Anio =  2001
};

Console.WriteLine($"Id del vehiculo instanciado: {vehiculo.Id}");

PersistirVehiculo(vehiculo);

Console.WriteLine($"El id del vehiculo persistido es: {vehiculo.Id}");

PersistirVehiculo(new Vehiculo("DEF456"));
PersistirVehiculo(new Vehiculo("GHI789"));
PersistirVehiculo(new Vehiculo("JKL159"));

ListarVehiculos();

Console.WriteLine("intentando agregar un vehiculo con el mismo dominio que uno ya existente");
Vehiculo vehiculo2 = new Vehiculo("DEF456")
{
    Marca = "Ford",
    Anio = 1998
};
PersistirVehiculo(vehiculo2);

Console.WriteLine("Entonces se lo modifica");
modificarVehiculo.Ejecutar(vehiculo2);

ListarVehiculos();

Console.WriteLine("eliminando al vehiculo de id 2");
eliminarVehiculo.Ejecutar(2);

ListarVehiculos();



/*
    no supe como guardar la lista de vehiculos en una linea de texto
Console.WriteLine("Asignando vehiculos a titulares");

AgregarVehiculoALista(titular, vehiculo);

ListarTitularesConSusVehiculos();
*/
/*


Console.WriteLine("----------Polizas----------");
Poliza poliza = new Poliza(500000, "Galeno")
{
    Cobertura = "Todo riesgo",
    FechaInicio = new DateTime(2022,12,30),
    FechaFin = new DateTime(2023,12,30)
};
Console.WriteLine($"Id de la poliza instanciada: {poliza.Id}");

PersistirPoliza(poliza);

Console.WriteLine($"El id de la poliza persistida es: {poliza.Id}");

PersistirPoliza(new Poliza(800000, "La Caja"));
PersistirPoliza(new Poliza(850000, "Sancor Seguros"));
PersistirPoliza(new Poliza(1500000, "BBVA"));

ListarPolizas();

Poliza poliza2 = new Poliza(1300000, "La Caja")
{
    Cobertura = "Todo riesgo",
    FechaInicio = new DateTime(2023,4,12),
    FechaFin = new DateTime(2024,4,12),
    Id = 2, //hardcodeo el id ya que no tengo un metodo getid
};
Console.WriteLine("Modificando poliza");
modificarPoliza.Ejecutar(poliza2);

ListarPolizas();

Console.WriteLine("eliminando la poliza de id 3");
eliminarPoliza.Ejecutar(3);

ListarPolizas();


//comandos para poder ver la consola al final de la ejecucion-----------------------------------------------------------------------------------
Console.WriteLine("Aprete una tecla para cerrar.");
Console.ReadLine();




//metodos locales
void PersistirTitular(Titular t)
{
    try
    {
        agregarTitular.Ejecutar(t);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}
void ListarTitulares()
{
    Console.WriteLine("Listando todos los titulares.");
    List<Titular> lista = listarTitulares.Ejecutar();
    foreach (var item in lista)
    {
        Console.WriteLine(item);
    }
}

void PersistirVehiculo(Vehiculo v)
{
    try
    {
        agregarVehiculo.Ejecutar(v);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}
void ListarVehiculos()
{
    Console.WriteLine("Listando todos los vehiculos.");
    List<Vehiculo> lista = listarVehiculos.Ejecutar();
    foreach (var item in lista)
    {
        Console.WriteLine(item);
    }
}
/*
void AgregarVehiculoALista(Titular t, Vehiculo v)
{
    //se agrega el vehiculo a la lista y se persisten los cambios
    agregarVehiculoALista.Ejecutar(t,v);
    modificarTitular.Ejecutar(t);
    modificarVehiculo.Ejecutar(v);
}
void ListarTitularesConSusVehiculos()
{
    Console.WriteLine("Listando todos los titulares y sus vehiculos.");
    List<Titular> lista = listarTitulares.Ejecutar();
    foreach (var item in lista)
    {
        Console.WriteLine(item);
        //si hay vehiculos los imprime
        if (item.Vehiculos.Any())
        {
            Console.WriteLine("y sus vehiculos");
            foreach (var vehiculo in item.Vehiculos)
            {
                Console.WriteLine(vehiculo);
            }
        }
    }
}
*/
/*
void PersistirPoliza(Poliza p)
{
    try
    {
        agregarPoliza.Ejecutar(p);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}
void ListarPolizas()
{
    Console.WriteLine("Listando todas las polizas.");
    List<Poliza> lista = listarPolizas.Ejecutar();
    foreach (var item in lista)
    {
        Console.WriteLine(item);
    }
}*/