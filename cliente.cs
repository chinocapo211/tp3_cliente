class cliente
{
    public int DNI{get; private set;}
    public string apellido{get;private set;}
    public string nombre{get;private set;}
    public DateTime fechaInscripcion{get; set;}
    public int tipoEntrada{get; set;}
    public int totalAbonado{get; set;}
    public cliente(int dni, string ape, string nom, DateTime fins, int te, int ta)
    {
        DNI = dni;
        apellido = ape;
        nombre = nom;
        fechaInscripcion = fins;
        tipoEntrada = te;
        totalAbonado = ta;
    }
}
