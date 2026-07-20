public static class Estadisticas
{
    public static void MostrarEstadisticas()
    {
        try
        {
            string[] tarjetas = File.ReadAllLines("Datos/tarjetas.txt");

            int total = 0;
            int validas = 0;
            int invalidas = 0;
            int visa = 0;
            int mastercard = 0;
            int americanExpress = 0;
            int discover = 0;
            int desconocidas = 0;

            foreach (string tarjeta in tarjetas)
            {
                if (string.IsNullOrWhiteSpace(tarjeta))
                {
                    continue;
                }

                total++;

                bool Esvalida = ValidadorLuhn.ValidarTarjeta(tarjeta);

                if (Esvalida)
                {
                    validas++;
                }
                else
                {
                    invalidas++;
                }

                string marca = "Desconocida";

                try
                {
                    marca = ValidadorLuhn.IdentificarMarca(tarjeta);
                }
                catch (FormatException)
                {
                    marca = "Desconocida";
                }

                if (marca == "Visa")
                {
                    visa++;
                }
                else if (marca == "Mastercard")
                {
                    mastercard++;
                }
                else if (marca == "American Express")
                {
                    americanExpress++;
                }
                else if (marca == "Discover")
                {
                    discover++;
                }
                else
                {
                    desconocidas++;
                }
            }

            Console.WriteLine("=== ESTADISTICAS ===");
            Console.WriteLine($"Total de tarjetas: {total}");
            Console.WriteLine($"Tarjetas validas: {validas}");
            Console.WriteLine($"Tarjetas invalidas: {invalidas}");
            
            Console.WriteLine("--- Por marca ---");
            Console.WriteLine($"Visa: {visa}");
            Console.WriteLine($"Mastercard: {mastercard}");
            Console.WriteLine($"American Express: {americanExpress}");
            Console.WriteLine($"Discover: {discover}");
            Console.WriteLine($"Desconocidas: {desconocidas}");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("No se encontro el archivo de tarjetas.");
        }
        catch (Exception)
        {
            Console.WriteLine("Ocurrio un error al calcular las estadisticas.");
        }

    }
}
