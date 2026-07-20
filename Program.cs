int opcion = 0;

do
{
    Console.WriteLine("=== VALIDADOR DE TARJETAS ===");
    Console.WriteLine("1. Validar una tarjeta");
    Console.WriteLine("2. Validar tarjeta desde un archivo");
    Console.WriteLine("3. Generar un número de tarjeta válido");
    Console.WriteLine("4. Estadísticas de tarjetas");
    Console.WriteLine("5. Salir");

    Console.Write("Ingrese una opción: ");
    try
    {
        opcion = int.Parse(Console.ReadLine() ?? "");
    }
    catch (FormatException)
    {
        Console.WriteLine("Debe ingresar un número válido.");
        continue;
    }
    catch (OverflowException)
    {
        Console.WriteLine("El número ingresado es demasiado grande.");
        continue;
    }

    switch (opcion)
    {
        case 1:
            Console.Write("Ingrese el numero de la tarjeta: ");
            string tarjeta = Console.ReadLine() ?? "";
            if (tarjeta.Equals(""))
            {
                Console.Write("Numero de tarjeta invalido, intente nuevamente.");
                break;
            }
            Console.WriteLine("Validando tarjeta...");
            Console.WriteLine($"Numero: {tarjeta}");
            string marca = ValidadorLuhn.IdentificarMarca(tarjeta);
            Console.WriteLine($"Marca: {marca}");
            bool Esvalida = ValidadorLuhn.ValidarTarjeta(tarjeta);
            if (Esvalida)
            {
                
                Console.WriteLine("Estado: Valida!.");
            }else
            {
                Console.WriteLine("Estado: Invalida!.");
            }
            break;

        case 2:
            Console.WriteLine("Validando tarjeta desde un archivo...");
            Archivo.ValidarDesdeArchivo("Datos/tarjetas.txt");
            break;

        case 3:
            string numeroGenerado = Generador.GenerarNumeroValido();
            string marcaGenerada = ValidadorLuhn.IdentificarMarca(numeroGenerado);

            Console.WriteLine("Número generado: " + numeroGenerado);
            Console.WriteLine("Marca: " + marcaGenerada);
            Console.WriteLine("Estado: Valida!.");
            break;

        case 4:
            Estadisticas.MostrarEstadisticas();
            break;

        case 5:
            Console.WriteLine("Saliendo del programa...");
            break;

        default:
            Console.WriteLine("Opción inválida.");
            break;
    }

    if (opcion != 5)
    {
        Console.WriteLine("\nPresione cualquier tecla para volver al menú...");
        Console.ReadKey();
        Console.Clear();
    }

} while (opcion != 5);
