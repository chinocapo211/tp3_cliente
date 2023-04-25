int opcion;
int buscarId;
int ultimoId;
do{
    opcion=Menu();
    switch(opcion)
    {
        case 1:
            cliente nuevoClien = SolicitarDatos();
            ultimoId = ticketera.agregarCliente(nuevoClien);
        break;
        case 2:
            List<string> estadisticas = new List<string>();
            estadisticas = ticketera.estadisticasTicketera();
            Console.WriteLine($"El total de clientes ingresados son: {estadisticas[0]}");
            Console.WriteLine($"El porcentaje del tipo 1: {estadisticas[5]} y la recaudacion de este fue: {estadisticas[1]}");
            Console.WriteLine($"El porcentaje del tipo 2: {estadisticas[6]} y la recaudacion de este fue: {estadisticas[2]}");
            Console.WriteLine($"El porcentaje del tipo 3: {estadisticas[7]} y la recaudacion de este fue: {estadisticas[3]}");
            Console.WriteLine($"El porcentaje del tipo 4: {estadisticas[8]} y la recaudacion de este fue: {estadisticas[4]}");
            Console.WriteLine($"La recaudacion total fue de: {estadisticas[9]}");
        break;
        case 3:
            buscarId = pedirInt(1,999999,"Ingrese el ID que busca:  ");
            cliente mostrar = ticketera.buscarCliente(buscarId);
            if(mostrar != null)
            {
                Console.WriteLine(mostrar.DNI);
                Console.WriteLine(mostrar.apellido);
                Console.WriteLine(mostrar.nombre);
                Console.WriteLine(mostrar.fechaInscripcion);
                Console.WriteLine(mostrar.tipoEntrada);
                Console.WriteLine(mostrar.totalAbonado);
            }
        break;
        case 4:
            buscarId = pedirInt(1,999999,"Ingrese el ID que busca: ");
            int Nte=pedirInt(1,4,"Tipo de entrada: "); 
            int Nta;
            Nta = verificarEntrada(Nte);
            DateTime nuevaFecha = pedirFecha("Ingrese la nueva fecha a ingresar:   ");;
            bool validar = ticketera.cambiarEntrada(buscarId,Nte,Nta,nuevaFecha);
        break;
    }
}while(opcion!=5);
cliente SolicitarDatos()
{
    int dni= int.Parse(pedirDni());
    string apellido=IngresarTexto("Apellido:  ");
    string nombre=IngresarTexto("Nombre:  ");
    DateTime fn = pedirFecha("Fecha inscripcion:  ");
    int te=pedirInt(1,4,"Tipo de entrada:  "); 
    int ta = 0;
    ta = verificarEntrada(te);
    return new cliente(dni,apellido,nombre,fn,te,ta);
}
static int verificarEntrada(int te)
{
    int devolver=0;
    switch(te)
    {
        case 1:
            devolver=pedirInt(15000,15000,"Total de abonado: ");
        break;
        case 2:
            devolver=pedirInt(30000,30000,"Total de abonado: ");
        break;
        case 3:
            devolver=pedirInt(10000,10000,"Total de abonado: ");
        break;
        case 4:
            devolver=pedirInt(40000,40000,"Total de abonado: ");
        break;
    }
    return devolver;
}
static string IngresarTexto(string msj)
{
    Console.Write(msj, " ");
    return Console.ReadLine();
}
static int pedirInt(int minimo, int maximo, string msj)
{
    int devolver;
    Console.Write(msj);
    devolver = int.Parse(Console.ReadLine());
    while(devolver < minimo || devolver > maximo)
    {
        Console.Write("El numero debe estar dentro del limite, vuelva a intentar... ");
        devolver = int.Parse(Console.ReadLine());
    }
    return devolver;
}
static int Menu()
{
    int devolver;
    do
    {
        Console.WriteLine("1) Nueva Inscripción");
        Console.WriteLine("2) Obtener Estadísticas del Evento");
        Console.WriteLine("3) Buscar Cliente");
        Console.WriteLine("4) Cambiar entrada de un cliente");
        Console.WriteLine("5) Salir");
        devolver= pedirInt(1,5,"Ingrese la opción que desea ejecutar: ");
    } while(devolver<0 || devolver>5);
    return devolver;
}
static DateTime pedirFecha(string msj)
{
    DateTime devolver;
    string fecha;
    fecha = IngresarTexto(msj);
    while(DateTime.TryParse(fecha, out devolver) == false)
    {
        fecha = IngresarTexto("Error, ingrese una fecha... ");
    }
    return devolver;
}
static string pedirDni()
{
    string devolver;
    int desecho;
    devolver = IngresarTexto("Ingrese el DNI de la persona:  ");
    while((devolver.Length < 7 || devolver.Length > 8)|| int.TryParse(devolver, out desecho) == false)
    {
        devolver = IngresarTexto("Error, el DNI debe tener 8 caracteres y ser solo numérico... ");
    }
    return devolver;
}