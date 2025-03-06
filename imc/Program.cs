using System;

class Program
{
    static void Main()
    {
        double peso = 0;
        double estatura = 0;
        double imc = 0;
        string resultadoImc = "";
        string[,] historial = new string[10, 4];
        int contadorHistorial = 0;
        int opciones = 0;

        Console.WriteLine("**** CALCULAR IMC ****");

        do
        {
            Console.WriteLine("Ingrese su peso en kilogramos (entre 30 y 300 kg):");
            if (double.TryParse(Console.ReadLine(), out peso) && peso >= 30 && peso <= 300)
            {
                historial[contadorHistorial, 0] = peso.ToString();
                break;
            }
            else
            {
                Console.WriteLine("Entrada inválida. Por favor, ingrese un peso válido entre 30 y 300 kg.");
            }
        } while (true);


        do
        {
            Console.WriteLine("Ingrese su estatura en metros (por ejemplo, 1.75, entre 1.0 y 2.5 m):");
            if (double.TryParse(Console.ReadLine(), out estatura) && estatura >= 1.0 && estatura <= 2.5)
            {
                historial[contadorHistorial, 1] = estatura.ToString();
                break;
            }
            else
            {
                Console.WriteLine("Entrada inválida. Por favor, ingrese una estatura válida entre 1.0 y 2.5 m.");
            }
        } while (true);

        imc = peso / (estatura * estatura);
        historial[contadorHistorial, 2] = imc.ToString("F2");
        historial[contadorHistorial, 3] = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        contadorHistorial++;

        if (imc >= 40)
        {
            resultadoImc = "OBESIDAD MÓRBIDA (Grado III)";
        }
        else if (imc >= 35)
        {
            resultadoImc = "OBESIDAD SEVERA (Grado II)";
        }
        else if (imc >= 30)
        {
            resultadoImc = "OBESIDAD (Grado I)";
        }
        else if (imc >= 25)
        {
            resultadoImc = "SOBREPESO";
        }
        else if (imc >= 18.5)
        {
            resultadoImc = "NORMAL";
        }
        else if (imc >= 17)
        {
            resultadoImc = "DELGADEZ LEVE";
        }
        else if (imc >= 16)
        {
            resultadoImc = "DELGADEZ MODERADA";
        }
        else
        {
            resultadoImc = "DELGADEZ SEVERA";
        }

        Console.WriteLine($"\nPeso: {peso} Kg");
        Console.WriteLine($"Estatura: {estatura} m");
        Console.WriteLine($"IMC: {imc:F2}");
        Console.WriteLine($"Clasificación: {resultadoImc}");

        do
        {
            Console.WriteLine("\n***************************************");
            Console.WriteLine("Escriba el número de la opción:");
            Console.WriteLine("1. Nuevo IMC - 2. Ver Historial - 3. Salir");
            if (int.TryParse(Console.ReadLine(), out opciones) && opciones >= 1 && opciones <= 4)
            {
                break;
            }
            else
            {
                Console.WriteLine("Opción inválida. Por favor, ingrese 1, 2, 3 o 4.");
            }
        } while (true);


        if (opciones == 2)
        {
            Console.WriteLine("\n**** HISTORIAL DE CÁLCULOS ****");
            if (contadorHistorial == 0)
            {
                Console.WriteLine("No hay cálculos en el historial.");
            }
            else
            {
                for (int j = 0; j < contadorHistorial; j++)
                {
                    Console.WriteLine($"\nCálculo {j + 1}:");
                    Console.WriteLine($"Peso: {historial[j, 0]} Kg");
                    Console.WriteLine($"Estatura: {historial[j, 1]} m");
                    Console.WriteLine($"IMC: {historial[j, 2]}");
                    Console.WriteLine($"Fecha: {historial[j, 3]}");
                }
            }
        }

        if (opciones == 3)
        {
            Console.WriteLine("\nAdios!");
        }
    }
}
