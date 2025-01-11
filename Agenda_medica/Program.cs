using System;
using System.Collections.Generic;

// Definimos una estructura (struct) para el Paciente
public struct Paciente
{
    private string Cedula { get; } // Encapsulamos la cédula
    public string Nombre { get; set; }
    public int Edad { get; set; }
    public DateTime FechaTurno { get; set; }
    public string Urgencia { get; set; }

    // Constructor para inicializar un Paciente 
    public Paciente(string cedula, string nombre, int edad, DateTime fechaTurno, string urgencia)
    {
        Cedula = cedula;
        Nombre = nombre;
        Edad = edad;
        FechaTurno = fechaTurno;
        Urgencia = urgencia;
    }

    // Método para mostrar la cédula (no se puede acceder directamente desde fuera)
    public string ObtenerCedula()
    {
        return Cedula;
    }
}

// Definimos una clase para la Agenda de turnos
public class AgendaTurnos
{
    private List<Paciente> pacientes;

    public AgendaTurnos()
    {
        pacientes = new List<Paciente>();
    }

    // Método para agregar un paciente a la agenda
    public void AgregarPaciente(Paciente paciente)
    {
        pacientes.Add(paciente);
    }

    // Método para visualizar todos los turnos en formato tabla
    public void VisualizarTurnos()
    {
        if (pacientes.Count == 0)
        {
            Console.WriteLine("No hay pacientes en la agenda.");
            return;
        }

        // cabecera de la tabla
        Console.WriteLine(new string('-', 80));
        Console.WriteLine($"{"Cédula",-15} {"Nombre",-20} {"Edad",-5} {"Fecha de Turno",-20} {"Urgencia",-10}");
        Console.WriteLine(new string('-', 80));

        foreach (var paciente in pacientes)
        {
            Console.WriteLine($"{paciente.ObtenerCedula(),-15} {paciente.Nombre,-20} {paciente.Edad,-5} {paciente.FechaTurno,-20:yyyy-MM-dd HH:mm} {paciente.Urgencia,-10}");
        }

        Console.WriteLine(new string('-', 80));
    }
}

// Programa principal
public class Program
{
    public static void Main()
    {
        Console.WriteLine(@"    █████╗  ██████╗ ███████╗███╗   ██╗██████╗  █████╗     ███╗   ███╗███████╗██████╗ ██╗ ██████╗ █████╗ ");
        Console.WriteLine(@"   ██╔══██╗██╔════╝ ██╔════╝████╗  ██║██╔══██╗██╔══██╗    ████╗ ████║██╔════╝██╔══██╗██║██╔════╝██╔══██╗");
        Console.WriteLine(@"   ███████║██║  ███╗█████╗  ██╔██╗ ██║██║  ██║███████║    ██╔████╔██║█████╗  ██║  ██║██║██║     ███████║");
        Console.WriteLine(@"   ██╔══██║██║   ██║██╔══╝  ██║╚██╗██║██║  ██║██╔══██║    ██║╚██╔╝██║██╔══╝  ██║  ██║██║██║     ██╔══██║");
        Console.WriteLine(@"   ██║  ██║╚██████╔╝███████╗██║ ╚████║██████╔╝██║  ██║    ██║ ╚═╝ ██║███████╗██████╔╝██║╚██████╗██║  ██║");
        Console.WriteLine(@"   ╚═╝  ╚═╝ ╚═════╝ ╚══════╝╚═╝  ╚═══╝╚═════╝ ╚═╝  ╚═╝    ╚═╝     ╚═╝╚══════╝╚═════╝ ╚═╝ ╚═════╝╚═╝  ╚═╝");

        AgendaTurnos agenda = new AgendaTurnos();
        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("\n--- Menú de Opciones ---");
            Console.WriteLine("1. Agregar paciente");
            Console.WriteLine("2. Visualizar turnos");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opción: ");
            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    // Ingresar los datos del paciente
                    Console.Write("Ingrese la cédula del paciente: ");
                    string cedula = Console.ReadLine();
                    Console.Write("Ingrese el nombre del paciente: ");
                    string nombre = Console.ReadLine();
                    Console.Write("Ingrese la edad del paciente: ");
                    int edad = int.Parse(Console.ReadLine());
                    Console.Write("Ingrese la fecha del turno (AÑO-MES-DIA HORA:MINUTOS): ");
                    DateTime fechaTurno = DateTime.Parse(Console.ReadLine());
                    Console.Write("Ingrese el nivel de urgencia (Urgente, Moderada, Baja): ");
                    string urgencia = Console.ReadLine();

                    // Agregar el paciente a la agenda
                    agenda.AgregarPaciente(new Paciente(cedula, nombre, edad, fechaTurno, urgencia));
                    Console.WriteLine("Paciente agregado exitosamente.");
                    break;

                case 2:
                    // Visualizar los turnos en formato tabla
                    Console.WriteLine("\nAgenda de Turnos:");
                    agenda.VisualizarTurnos();
                    break;

                case 3:
                    // Salir del programa
                    continuar = false;
                    Console.WriteLine("Saliendo del programa...");
                    break;

                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }
}
