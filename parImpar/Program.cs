using System;

class Program
{
    static void Main()
    {
        bool continuar = true;

        while (continuar)
        {
            int lista = 0;
            string entradaLista;
            int inicio, fin;
            int contadorPares = 0, contadorImpares = 0;
            int sumaPares = 0, sumaImpares = 0;

            Console.WriteLine("Ingrese el número inicial del rango:");
            while (!int.TryParse(Console.ReadLine(), out inicio))
            {
                Console.WriteLine("Entrada inválida. Por favor, ingrese un número válido.");
            }

            Console.WriteLine("Ingrese el número final del rango:");
            while (!int.TryParse(Console.ReadLine(), out fin))
            {
                Console.WriteLine("Entrada inválida. Por favor, ingrese un número válido.");
            }

            do
            {
                Console.WriteLine("Ingrese el modo de cómo quiere imprimir los pares e impares");
                Console.WriteLine("1. Descendente - 2. Ascendente");
                entradaLista = Console.ReadLine();

                if (entradaLista == "1" || entradaLista == "2")
                {
                    lista = Convert.ToInt32(entradaLista);
                    break;
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Por favor, ingrese 1 o 2.");
                }
            } while (true);

            bool EsPrimo(int numero)
            {
                if (numero < 2) return false;
                for (int i = 2; i * i <= numero; i++)
                {
                    if (numero % i == 0) return false;
                }
                return true;
            }

            if (lista == 1)
            {
                for (int numero = fin; numero >= inicio; numero--)
                {
                    if (numero % 2 == 0)
                    {
                        Console.WriteLine($"El número {numero} ES PAR");
                        contadorPares++;
                        sumaPares += numero;
                    }
                    else
                    {
                        Console.WriteLine($"El número {numero} NO ES PAR");
                        contadorImpares++;
                        sumaImpares += numero;
                    }

                    if (EsPrimo(numero))
                    {
                        Console.WriteLine($"El número {numero} ES PRIMO");
                    }
                }
            }
            else
            {
                for (int numero = inicio; numero <= fin; numero++)
                {
                    if (numero % 2 == 0)
                    {
                        Console.WriteLine($"El número {numero} ES PAR");
                        contadorPares++;
                        sumaPares += numero;
                    }
                    else
                    {
                        Console.WriteLine($"El número {numero} NO ES PAR");
                        contadorImpares++;
                        sumaImpares += numero;
                    }

                    if (EsPrimo(numero))
                    {
                        Console.WriteLine($"El número {numero} ES PRIMO");
                    }
                }
            }

            Console.WriteLine($"\nResumen:");
            Console.WriteLine($"Total de números pares: {contadorPares}");
            Console.WriteLine($"Total de números impares: {contadorImpares}");
            Console.WriteLine($"Suma de números pares: {sumaPares}");
            Console.WriteLine($"Suma de números impares: {sumaImpares}");

            string respuesta;
            do
            {
                Console.WriteLine("\n¿Desea repetir el proceso? (s/n)");
                respuesta = Console.ReadLine()?.ToLower() ?? "n";

                if (respuesta != "s" && respuesta != "n")
                {
                    Console.WriteLine("Entrada inválida. Por favor, ingrese 's' para sí o 'n' para no.");
                }
            } while (respuesta != "s" && respuesta != "n");

            continuar = respuesta == "s";
        }

        Console.WriteLine("Gracias por usar el programa. ¡Hasta luego!");
    }
}