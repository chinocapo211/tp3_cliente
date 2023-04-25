class ticketera
{
    static private Dictionary<int,cliente> dicClientes = new Dictionary<int, cliente>();
    static private int ultimoIdEntrada=0;
    int devolverUltimoId()
    {
        return ultimoIdEntrada;
    }
    public static int agregarCliente(cliente clien)
    {
        ultimoIdEntrada++;
        dicClientes.Add(ultimoIdEntrada,clien);
        return ultimoIdEntrada; 
    }
    public static cliente buscarCliente(int idEntrada)
    {
        if(dicClientes[idEntrada].apellido != "")
        {
            return dicClientes[idEntrada];
        }
        else
        {
            Console.WriteLine("No se encontro el cliente...");
            return null;
        }
    }
    public static bool cambiarEntrada(int ID, int tipo, int total, DateTime fecha)
    {
        bool devolver = false;
        if(dicClientes.ContainsKey(ID))
        {
            if(dicClientes[ID].totalAbonado > total)
            {
                Console.WriteLine("No se pudo cambiar la entrada...");
            }
            else
            {
                dicClientes[ID].totalAbonado = total;
                dicClientes[ID].tipoEntrada = tipo;
                dicClientes[ID].fechaInscripcion = fecha;
                devolver = true;
            }
        }
        else
        {
            Console.WriteLine("No se encontro el id...");
        }
        return devolver;
    }
    static public List<string> estadisticasTicketera()
    {
        int total = 0,totalEntrada = 0;
        int[,] valoresTipo = new int[2,4];
        List<string> devolver = new List<string>();
        devolver.Add(ultimoIdEntrada.ToString());
        foreach(cliente i in dicClientes.Values)
        {
            if(i.tipoEntrada == 1)
            {
                valoresTipo[0,0] += i.totalAbonado;
                valoresTipo[1,0] += 1;
            }
            else if(i.tipoEntrada == 2)
            {
                valoresTipo[0,1] += i.totalAbonado;
                valoresTipo[1,1] += 1;
            }
            else if(i.tipoEntrada == 3)
            {
                valoresTipo[0,2] += i.totalAbonado;
                valoresTipo[1,2] += 1;
            }
            else if(i.tipoEntrada == 4)
            {
                valoresTipo[0,3] += i.totalAbonado;
                valoresTipo[1,3] += 1;
            }
            total += i.totalAbonado;
            totalEntrada++;
        }
        devolver.Add((valoresTipo[0,0]).ToString());
        devolver.Add((valoresTipo[0,1]).ToString());
        devolver.Add((valoresTipo[0,2]).ToString());
        devolver.Add((valoresTipo[0,3]).ToString());
        devolver.Add((valoresTipo[1,0]*100/totalEntrada).ToString());
        devolver.Add((valoresTipo[1,1]*100/totalEntrada).ToString());
        devolver.Add((valoresTipo[1,2]*100/totalEntrada).ToString());
        devolver.Add((valoresTipo[1,3]*100/totalEntrada).ToString());
        devolver.Add(total.ToString());
        return devolver;
    }
}