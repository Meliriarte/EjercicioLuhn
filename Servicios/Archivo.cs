public static class Archivo
{
    public static void ValidarDesdeArchivo(string ruta)
    {
        try
        {
            // Lee todas las tarjetas, usando una linea por cada numero.
            string[] tarjetas = File.ReadAllLines(ruta);

            int validas = 0;
            int invalidas = 0;

            foreach (string tarjeta in tarjetas)
            {
                if (string.IsNullOrWhiteSpace(tarjeta))
                {
                    continue;
                }

                try
                {
                    bool Esvalida = ValidadorLuhn.ValidarTarjeta(tarjeta);
                    string marca = ValidadorLuhn.IdentificarMarca(tarjeta);

                    Console.WriteLine($"Numero: {tarjeta}");
                    Console.WriteLine($"Marca: {marca}");

                    if (Esvalida)
                    {
                        Console.WriteLine("Estado: Valida!");
                        validas++;
                    }
                    else
                    {
                        Console.WriteLine("Estado: Invalida!");
                        invalidas++;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Numero: {tarjeta}");
                    Console.WriteLine("Marca: Desconocida");
                    Console.WriteLine("Estado: Invalida!");
                    invalidas++;
                }

                Console.WriteLine();
            }

            // Muestra el resultado general despues de procesar todas las lineas.
            Console.WriteLine("=== RESUMEN ===");
            Console.WriteLine($"Tarjetas validas: {validas}");
            Console.WriteLine($"Tarjetas invalidas: {invalidas}");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("No se encontro el archivo.");
        }
        catch (Exception)
        {
            Console.WriteLine("Ocurrio un error al leer el archivo.");
        }
    }
}
