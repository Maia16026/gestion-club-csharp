using System;

namespace proyecto
{
    class Program
    {
        static void Main(string[] args)
        {
            Club club = new Club("El Olimpo");

            Entrenador jorge = new Entrenador("Jorge Molina", 32, 23, 100000);

            club.AltaEntrenador(jorge);

            Deporte futbol = new Deporte("futbol", "junior", 30, jorge, 1000);

            club.AgregarDeporte(futbol);

            bool salir = false;

            while (!salir)
            {
                try
                {
                    Console.Clear();

                    Console.WriteLine("CLUB DEPORTIVO");
                    Console.WriteLine("1 - Alta entrenador");
                    Console.WriteLine("2 - Baja entrenador");
                    Console.WriteLine("3 - Agregar deporte");
                    Console.WriteLine("4 - Eliminar deporte");
                    Console.WriteLine("5 - Inscribir niño");
                    Console.WriteLine("6 - Dar de baja niño");
                    Console.WriteLine("7 - Pagar cuota");
                    Console.WriteLine("8 - Listar inscriptos");
                    Console.WriteLine("9 - Listar deudores");
                    Console.WriteLine("0 - Salir");

                    Console.Write("\nOpcion: ");

                    int opcion = int.Parse(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            AltaEntrenador(club);
                            break;

                        case 2:
                            BajaEntrenador(club);
                            break;

                        case 3:
                            AgregarDeporte(club);
                            break;

                        case 4:
                            EliminarDeporte(club);
                            break;

                        case 5:
                            InscribirNiño(club);
                            break;

                        case 6:
                            BajaNiño(club);
                            break;

                        case 7:
                            PagarCuota(club);
                            break;

                        case 8:
                            club.ListarInscriptos();
                            break;

                        case 9:
                            InformarDeudores(club);
                            break;

                        case 0:
                            salir = true;
                            break;

                        default:
                            Console.WriteLine("Opcion invalida");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nERROR: " + ex.Message);
                }

                Console.WriteLine("\nPresione una tecla...");
                Console.ReadKey();
            }
        }

        static void AltaEntrenador(Club club)
        {
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Edad: ");
            int edad = int.Parse(Console.ReadLine());

            Console.Write("DNI: ");
            int dni = int.Parse(Console.ReadLine());

            Console.Write("Sueldo: ");
            double sueldo = double.Parse(Console.ReadLine());

            Entrenador entrenador = new Entrenador(nombre, edad, dni, sueldo);

            club.AltaEntrenador(entrenador);

            Console.WriteLine("Entrenador agregado");
        }

        static void BajaEntrenador(Club club)
        {
            Console.Write("DNI entrenador: ");

            int dni = int.Parse(Console.ReadLine());

            club.BajaEntrenador(dni);

            Console.WriteLine("Entrenador eliminado");
        }

        static void AgregarDeporte(Club club)
        {
            Console.Write("Nombre deporte: ");
            string nombre = Console.ReadLine();

            Console.Write("Categoria: ");
            string categoria = Console.ReadLine();

            Console.Write("Cupo: ");
            int cupo = int.Parse(Console.ReadLine());

            Console.Write("Costo cuota: ");
            double cuota = double.Parse(Console.ReadLine());

            Console.Write("DNI entrenador: ");
            int dni = int.Parse(Console.ReadLine());

            Entrenador entrenador = club.BuscarEntrenador(dni);

            Deporte deporte = new Deporte(
                nombre,
                categoria,
                cupo,
                entrenador,
                cuota
            );

            club.AgregarDeporte(deporte);

            Console.WriteLine("Deporte agregado");
        }

        static void EliminarDeporte(Club club)
        {
            Console.Write("Nombre deporte: ");
            string nombre = Console.ReadLine();

            Console.Write("Categoria: ");
            string categoria = Console.ReadLine();

            club.EliminarDeporte(nombre, categoria);

            Console.WriteLine("Deporte eliminado");
        }

        static void InscribirNino(Club club)
        {
            Console.Write("Nombre deporte: ");
            string nombreDeporte = Console.ReadLine();

            Console.Write("Categoria: ");
            string categoria = Console.ReadLine();

            Deporte deporte = club.BuscarDeporte(nombreDeporte, categoria);

            Console.Write("Nombre niño: ");
            string nombre = Console.ReadLine();

            Console.Write("Edad: ");
            int edad = int.Parse(Console.ReadLine());

            Console.Write("DNI: ");
            int dni = int.Parse(Console.ReadLine());

            Console.Write("Es socio? (s/n): ");
            bool socio = Console.ReadLine().ToLower() == "s";

            double descuento = 0;

            if (socio)
            {
                Console.Write("Descuento: ");
                descuento = double.Parse(Console.ReadLine());
            }

            Nino nino = new Nino(
                nombre,
                edad,
                dni,
                deporte,
                descuento,
                socio
            );

            deporte.AgregarInscripto(niño);

            Console.WriteLine("Niño inscripto");
        }

        static void BajaNino(Club club)
        {
            Console.Write("Nombre deporte: ");
            string nombre = Console.ReadLine();

            Console.Write("Categoria: ");
            string categoria = Console.ReadLine();

            Console.Write("DNI niño: ");
            int dni = int.Parse(Console.ReadLine());

            Deporte deporte = club.BuscarDeporte(nombre, categoria);

            deporte.EliminarInscripto(dni);

            Console.WriteLine("Niño eliminado");
        }

        static void PagarCuota(Club club)
        {
            Console.Write("Nombre deporte: ");
            string nombre = Console.ReadLine();

            Console.Write("Categoria: ");
            string categoria = Console.ReadLine();

            Console.Write("DNI niño: ");
            int dni = int.Parse(Console.ReadLine());

            Console.Write("Mes actual: ");
            int mes = int.Parse(Console.ReadLine());

            Deporte deporte = club.BuscarDeporte(nombre, categoria);

            Nino nino = deporte.BuscarNino(dni);

            double total = nino.CalcularCuota(deporte.CostoCuota);

            nino.PagarCuota(mes);

            Console.WriteLine("Monto pagado: $" + total);
        }

        static void InformarDeudores(Club club)
        {
            Console.Write("Mes actual: ");

            int mes = int.Parse(Console.ReadLine());

            club.ListarDeudores(mes);
        }
    }
}
