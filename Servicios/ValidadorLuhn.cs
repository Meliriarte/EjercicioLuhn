public static class ValidadorLuhn
{
    public static bool ValidarTarjeta(string numero)
    {
        if (string.IsNullOrWhiteSpace(numero))
        {
            return false;
        }

        if (numero.Length < 13 || numero.Length > 19)
        {
            return false;
        }

        foreach (char digito in numero)
        {
            if (!char.IsDigit(digito))
            {
                return false;
            }
        }

        // Se invierte el numero para recorrerlo desde el ultimo digito.
        string numalrevez = "";
        foreach (char item in numero)
        {
            numalrevez = item + numalrevez;
        }

        // Se duplican las posiciones pares y se comprueba el total de Luhn.
        int contadora = 0;
        int suma = 0;
        foreach (char item in numalrevez)
        {
            contadora ++;
            int numitem = (int)char.GetNumericValue(item);
            if (contadora %2 == 0)
            {
                numitem = numitem * 2;
                if (numitem >= 10)
                {
                    int residuo = numitem %10;
                    numitem = residuo + 1;
                }
            }
            suma = suma + numitem;
        }
        return suma %10 == 0;
    }

    public static string IdentificarMarca(string numero)
    {
        // La marca se determina usando la longitud y los prefijos de la tarjeta.
        int tamano = numero.Length;
        string tipo = "Desconocida";
        string prefijo = "";
        int prefijonum;
        if (tamano == 13 || tamano == 16)
        {
            prefijo = numero.Substring(0,1);
            if (prefijo == "4")
            {
                tipo = "Visa";
            }
            else if (tamano == 16)
            {
                prefijo = numero.Substring(0,2);
                prefijonum = int.Parse(prefijo);
                if (prefijonum >= 51 && prefijonum <= 55)
                {
                    tipo = "Mastercard";
                }
                else
                {
                    string prefijo2, prefijo4;
                    int prefijo3, prefijo6;
                    prefijo2 = numero.Substring(0, 2);
                    prefijo4 = numero.Substring(0, 4);
                    prefijo3 = int.Parse(numero.Substring(0,3));
                    prefijo6 = int.Parse(numero.Substring(0,6));
                    if (prefijo2 == "65")
                    {
                        tipo = "Discover";
                    }
                    else if (prefijo4 == "6011")
                    {
                        tipo = "Discover";
                    }
                    else if (prefijo3 >= 644 && prefijo3 <=649)
                    {
                        tipo = "Discover";
                    }
                    else if (prefijo6 >= 622126 && prefijo6 <=622925)
                    {
                        tipo = "Discover";
                    }
                    else
                    {
                        tipo = "Desconocida";
                    }
                }
            }
            else
            {
                tipo = "Desconocida";
            }
        }
        else if (tamano == 15)
        {
            prefijo = numero.Substring(0,2);
            if (prefijo == "34" || prefijo == "37")
            {
                tipo = "American Express";
            }
            else
            {
                tipo = "Desconocida";
            }
        }
        else if (tamano >= 17 && tamano <= 19)
        {
            string prefijo2, prefijo4;
            int prefijo3, prefijo6;
            prefijo2 = numero.Substring(0, 2);
            prefijo4 = numero.Substring(0, 4);
            prefijo3 = int.Parse(numero.Substring(0,3));
            prefijo6 = int.Parse(numero.Substring(0,6));
            if (prefijo2 == "65")
            {
                tipo = "Discover";
            }
            else if (prefijo4 == "6011")
            {
                tipo = "Discover";
            }
            else if (prefijo3 >= 644 && prefijo3 <=649)
            {
                tipo = "Discover";
            }
            else if (prefijo6 >= 622126 && prefijo6 <=622925)
            {
                tipo = "Discover";
            }
            else
            {
                tipo = "Desconocida";
            }
        }
        return tipo;
    }
}
