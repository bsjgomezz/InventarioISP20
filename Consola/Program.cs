using Consola.Class;

public class Program
{
    private static void Main(string[] args)
    {
        //CreamosVariables();

        //CreamosMatricesYVectores();

        //ImpresionDeParametros(args);

        //Capturadevaloresdelusuario();

        //CapturaDeValoresDelUsuario();

        //CreamosAlumnosEImprimimosSuFichaDeDatos();

        //CreamosEstudiantesEImprimimosSuSaludo();

        //ProbamosMetodosConDiferentesValoresDeRetorno();

        //ContarMateriasDesaprobadas();

        Ejercicio1();
    }

    private static void Ejercicio1()
    {
        //Metodo Main
        Persona estudiante1 = new();
        Persona persona1 = new();
        persona1.nombre = "Nico amargado";
        persona1.edad = 20;
        estudiante1.nombre = "Bauti";
        Console.WriteLine($"La persona es {persona1.nombre}, y su edad es {persona1.edad}");
        Console.WriteLine(Environment.NewLine+"Probando probando");
        Object Estudiante=new Object();
        Console.WriteLine(Estudiante.ToString());
        DateTime ahora = new DateTime();
        ahora=DateTime.Now;
        Console.WriteLine(ahora.ToString());
        Console.WriteLine(estudiante1.ToString());
    }

    private static void ContarMateriasDesaprobadas()
    {
        throw new NotImplementedException();
    }

    private static void ProbamosMetodosConDiferentesValoresDeRetorno()
    {
        AlumnoCurso alumno1 = new AlumnoCurso("Aquiles", "Talon", 39);

        alumno1.AgregarNota(8);
        alumno1.AgregarNota(7.5);
        alumno1.AgregarNota(9);
        alumno1.AgregarNota(3);
        alumno1.AgregarNota(5);

        string nombreCompleto = alumno1.ObtenerNombreCompleto();
        int cantidadNotas = alumno1.ObtenerCantidadDeNotas();
        double promedio = alumno1.CalcularPromedio();
        bool aprobado = alumno1.EstaAprobado();
        char inicial = alumno1.ObtenerInicial();
        int materiaDesaprobadas = alumno1.ContarMateriasDesaprobadas();
        DateTime fechaConsulta = alumno1.ObtenerFechaConsulta();
        List<double> notas = alumno1.ObtenerNotas();

        Console.WriteLine("Nombre completo: " + nombreCompleto);
        Console.WriteLine("Cantidad de notas: " + cantidadNotas);
        Console.WriteLine("Promedio: " + promedio);
        Console.WriteLine("¿Está aprobado?: " + aprobado);
        Console.WriteLine("Inicial: " + inicial);
        Console.WriteLine("Fecha de consulta: " + fechaConsulta);
        Console.WriteLine("Materias desaprobadas:" + materiaDesaprobadas);
    }

    private static void CreamosEstudiantesEImprimimosSuSaludo()
    {
        Estudiante estudiante1 = new Estudiante();
        estudiante1.Nombre = "Nicolas Marquez";
        estudiante1.Edad = 12;
        estudiante1.Domicilio = "El pueblo trucho ese";
        //estudiante1.Saludar();
        Console.WriteLine(estudiante1.DatosCompletos);       
    }

    private static void CreamosAlumnosEImprimimosSuFichaDeDatos()
    {
        Alumno alumno = new Alumno("Alejandro", "Ramirez", 12345678, new DateOnly(2000, 1, 1));
        Console.WriteLine(alumno.ImpresionFichaDeDatos());
        Alumno alumno2 = new Alumno("Enzo", "Ramirez", 12345672, new DateOnly(2006, 5, 1));
        Console.WriteLine(alumno2.ImpresionFichaDeDatos());
        Alumno alumno3 = new Alumno("Aquiles", "Ramirez", 12345628, new DateOnly(2004, 4, 1));
        Console.WriteLine(alumno3.ImpresionFichaDeDatos());

        Console.WriteLine(Alumno.ImprimirCantidadDeInstancias());
    }

    private static void CreamosMatricesYVectores()
    {
        //Creamos un vector de tipo string con 12 elementos
        string[] meses=new string[12] { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
        meses[0]= "Enero";
        //Creamos una matriz de tipo string con 3 filas y 2 columnas
        string[,] nosotros = new string[3, 2] { { "Alejandro", "Ramirez" }, { "Enzo", "Lovino" }, { "Aquiles", "Fuster" } };
        nosotros[0, 0] = "Marquez";
        nosotros[0, 1] = "Santiago";
        int[] edades = new int[3] {20,21, 22};
    }

    private static void CapturaDeValoresDelUsuario()
    {
        Console.Write("ingrese el año de su nacimiento: ");
        string? anionacimiento = Console.ReadLine();
        int anio = Convert.ToInt32(anionacimiento);
        int edad = DateTime.Now.Year - anio;
        Console.WriteLine($"Usted tiene {edad} años aproximadamente");
    }

    private static void ImpresionDeParametros(string[] args)
    {
        if (args.Length > 1)
        {
            Console.WriteLine($"Hola  {args[0]} {args[1]}");
        }else
        {
            Console.WriteLine("No se han pasado los parametros necesarios");
        }

    }

    private static void CreamosVariables()
    {

        //creamos una variable de entera y le asignamos un valor
        int numero = 10;
        // Declaracion de una variable de tipo string y asignamos un valor
        int numero2;
        // Asignamos un valor a la variable numero2
        numero2 = 20;
        int numero3 = 30;
    }
}