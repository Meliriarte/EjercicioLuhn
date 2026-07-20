# Validador de Tarjetas

Aplicación de consola creada para validar números de tarjetas mediante el algoritmo de Luhn e identificar su marca.

Este proyecto corresponde al ejercicio de fundamentos de C# y .NET. Incluye validación individual, lectura de tarjetas desde un archivo, generación de números válidos y estadísticas.

## Funciones principales

La aplicación cuenta con cinco opciones:

1. **Validar una tarjeta**
   - Solicita un número de tarjeta.
   - Comprueba si el número es válido.
   - Identifica la marca cuando es posible.

2. **Validar desde un archivo**
   - Lee los números guardados en `Datos/tarjetas.txt`.
   - Procesa una tarjeta por línea.
   - Muestra el resultado de cada tarjeta y un resumen final.

3. **Generar un número válido**
   - Crea un número aleatorio de 16 dígitos.
   - Genera una tarjeta Visa válida según Luhn.

4. **Mostrar estadísticas**
   - Cuenta las tarjetas válidas e inválidas del archivo.
   - Muestra el total por marca.

5. **Salir**
   - Cierra la aplicación.

## Marcas identificadas

| Marca | Regla principal |
|---|---|
| Visa | Empieza por 4 y tiene 13 o 16 dígitos |
| Mastercard | Empieza entre 51 y 55 y tiene 16 dígitos |
| American Express | Empieza por 34 o 37 y tiene 15 dígitos |
| Discover | Usa los prefijos indicados en el ejercicio y tiene entre 16 y 19 dígitos |

Si el número no coincide con ninguna regla, se muestra como `Desconocida`.

## ¿Cómo funciona la validación?

El programa aplica el algoritmo de Luhn de la siguiente manera:

1. Lee el número de derecha a izquierda.
2. Duplica algunos dígitos según su posición.
3. Cuando un resultado tiene dos cifras, suma sus cifras.
4. Suma todos los valores obtenidos.
5. Si el total es divisible entre 10, la tarjeta se considera válida.

## Ejemplos para probar

Estos números son datos de prueba y no representan tarjetas reales para realizar compras.

| Número | Resultado esperado |
|---|---|
| `4532015112830366` | Visa válida |
| `4532015112830367` | Visa inválida |
| `5555555555554444` | Mastercard válida |
| `5555555555554445` | Mastercard inválida |
| `378282246310005` | American Express válida |
| `378282246310006` | American Express inválida |
| `6011111111111117` | Discover válida |
| `6011111111111118` | Discover inválida |
| `9999999999999995` | Marca desconocida, pero válida según Luhn |
| `9999999999999996` | Marca desconocida e inválida |

## Archivo de prueba

El archivo `Datos/tarjetas.txt` contiene un número por línea. Para agregar más pruebas, solo se debe editar ese archivo y escribir cada número en una línea separada.

Ejemplo:

```text
4532015112830366
4532015112830367
5555555555554444
```

## Organización del proyecto

```text
Ejercicio-01-luhn/
├── Datos/
│   └── tarjetas.txt
├── Imagenes/
├── Servicios/
│   ├── Archivo.cs
│   ├── Estadisticas.cs
│   ├── Generador.cs
│   └── ValidadorLuhn.cs
├── Program.cs
├── Ejercicio-01-luhn.csproj
└── README.md
```

Cada archivo tiene una responsabilidad concreta:

- `Program.cs`: muestra el menú y recibe las opciones del usuario.
- `ValidadorLuhn.cs`: valida los números e identifica las marcas.
- `Archivo.cs`: lee y procesa el archivo de tarjetas.
- `Generador.cs`: crea números válidos.
- `Estadisticas.cs`: calcula los totales y el desglose por marca.

## Cómo ejecutar el proyecto

1. Abrir una terminal en la carpeta del proyecto.
2. Ejecutar:

```text
dotnet run
```

3. Elegir una opción del menú.

El proyecto fue creado para ejecutarse con .NET 10.

## Manejo de errores

La aplicación controla situaciones como:

- Opciones del menú que no son números.
- Números demasiado grandes para la opción del menú.
- Archivos que no existen.
- Tarjetas con caracteres que no son números.
- Números de tarjeta vacíos o con una longitud no permitida.

## Evidencias

En la carpeta `Imagenes` se encuentran capturas de la ejecución del proyecto.

## Repositorio

[Ver el proyecto en GitHub](https://github.com/Meliriarte/EjercicioLuhn)
