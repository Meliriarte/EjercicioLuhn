public static class Generador
{
    public static string GenerarNumeroValido()
    {
        Random aleatorio = new Random();
        string numero;

        // Se generan tarjetas Visa hasta encontrar una que pase Luhn.
        do
        {
            numero = "4";

            for (int posicion = 1; posicion < 16; posicion++)
            {
                numero += aleatorio.Next(0, 10);
            }
        }
        while (!ValidadorLuhn.ValidarTarjeta(numero));

        return numero;
    }
}
