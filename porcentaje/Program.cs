using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<string> historial = new List<string>();
        string opcion;

        do
        {
            Console.WriteLine("**** Calculadora de Porcentajes ****");
            Console.WriteLine("1. Calcular porcentaje de un número");
            Console.WriteLine("2. Calcular qué porcentaje es un número respecto a otro");
            Console.WriteLine("3. Ver historial");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    CalcularPorcentaje(historial);
                    break;
                case "2":
                    CalcularPorcentajeInverso(historial);
                    break;
                case "3":
                    MostrarHistorial(historial);
                    break;
                case "4":
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Opción inválida. Intente de nuevo.");
                    break;
            }
        } while (opcion != "4");
    }

    static void CalcularPorcentaje(List<string> historial)
    {
        double numero = 0, porcentaje = 0, resultado = 0;
        string entradaNumero, entradaPorcentaje;

        do
        {
            Console.Write("Ingrese un número: ");
            entradaNumero = Console.ReadLine();
        } while (!double.TryParse(entradaNumero, out numero) || numero <= 0);

        do
        {
            Console.Write("Ingrese el porcentaje: ");
            entradaPorcentaje = Console.ReadLine();
        } while (!double.TryParse(entradaPorcentaje, out porcentaje) || porcentaje <= 0 || porcentaje > 100);

        resultado = (porcentaje / 100) * numero;
        Console.WriteLine($"El {porcentaje}% de {numero} es {resultado}");
        historial.Add($"{porcentaje}% de {numero} = {resultado}");
    }

    static void CalcularPorcentajeInverso(List<string> historial)
    {
        double numeroParte = 0, numeroTotal = 0, resultado = 0;
        string entradaParte, entradaTotal;

        do
        {
            Console.Write("Ingrese la parte del numero: ");
            entradaParte = Console.ReadLine();
        } while (!double.TryParse(entradaParte, out numeroParte) || numeroParte <= 0);

        do
        {
            Console.Write("Ingrese el valor a sacar el porcentaje de la parte: ");
            entradaTotal = Console.ReadLine();
        } while (!double.TryParse(entradaTotal, out numeroTotal) || numeroTotal <= 0 || numeroParte > numeroTotal);

        resultado = (numeroParte / numeroTotal) * 100;
        Console.WriteLine($"{numeroParte} es el {resultado}% de {numeroTotal}");
        historial.Add($"{numeroParte} de {numeroTotal} = {resultado}%");
    }

    static void MostrarHistorial(List<string> historial)
    {
        Console.WriteLine("**** Historial de cálculos ****");
        if (historial.Count == 0)
        {
            Console.WriteLine("No hay cálculos realizados.");
        }
        else
        {
            foreach (var item in historial)
            {
                Console.WriteLine(item);
            }
        }
    }
}
