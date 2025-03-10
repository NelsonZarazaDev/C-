using System;
using System.Threading;

class SemaforoEjercicio
{
    static int MostrarMenu()
    {
        int semaforo;
        string entrada;

        while (true)
        {
            Console.WriteLine("\n***************************************");
            Console.WriteLine("Ingrese el número del semáforo");
            Console.WriteLine("1. Semáforo vehicular - 2. Semáforo peatonal - 3. Salir");
            entrada = Console.ReadLine();

            if (int.TryParse(entrada, out semaforo) && semaforo >= 1 && semaforo <= 3)
            {
                return semaforo;
            }
            else
            {
                Console.WriteLine("Opción inválida. Por favor, ingrese 1, 2 o 3.");
            }
        }
    }

    static void Main()
    {
        bool salir = false;

        while (!salir)
        {
            int semaforo = MostrarMenu();

            bool hayEmergencia = false;
            int tiempoEmergencia = -1;

            if (semaforo == 1)
            {
                Console.Write("¿Hay una emergencia? (s/n): ");
                string emergencia = Console.ReadLine().ToLower();

                if (emergencia == "s")
                {
                    hayEmergencia = true;
                    while (true)
                    {
                        Console.Write("¿En qué tiempo debe activarse la emergencia 0 a 125? (segundos): ");
                        if (int.TryParse(Console.ReadLine(), out tiempoEmergencia) && tiempoEmergencia >= 0 && tiempoEmergencia <= 125)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Tiempo inválido. Debe estar entre 0 y 125 segundos.");
                        }
                    }
                }
            }

            switch (semaforo)
            {
                case 1:
                    Console.WriteLine("******** SEMÁFORO VEHICULAR ********");
                    for (int tiempo = 0; tiempo <= 25; tiempo++)
                    {
                        Console.Clear();
                        Console.WriteLine("******** SEMÁFORO VEHICULAR ********");

                        if (hayEmergencia && tiempo == tiempoEmergencia)
                        {
                            Console.WriteLine("¡EMERGENCIA EN PROCESO! Semáforo en VERDE");
                            Thread.Sleep(100);
                            continue; 
                        }

                        string color = "";
                        if (tiempo >= 0 && tiempo <= 7)
                        {
                            color = "VERDE";
                        }
                        else if (tiempo > 7 && tiempo <= 12)
                        {
                            color = "AMARILLO";
                        }
                        else if (tiempo > 12)
                        {
                            color = "ROJO";
                        }
                        Console.WriteLine($"SEMAFORO EN {color} - Tiempo restante: {25 - tiempo} seg");
                        Thread.Sleep(1000);
                    }
                    Console.WriteLine("******** SEMÁFORO APAGADO ********");
                    break;

                case 2:
                    Console.WriteLine("******** SEMÁFORO PEATONAL ********");
                    for (int tiempo = 0; tiempo <= 30; tiempo++)
                    {
                        Console.Clear();
                        Console.WriteLine("******** SEMÁFORO PEATONAL ********");
                        string color = tiempo <= 15 ? "VERDE" : "ROJO";
                        Console.WriteLine($"SEMAFORO EN {color} - Tiempo restante: {30 - tiempo} seg");
                        Thread.Sleep(1000);
                    }
                    Console.WriteLine("******** SEMÁFORO APAGADO ********");
                    break;

                case 3:
                    Console.WriteLine("******** SEMÁFORO APAGADO ********");
                    salir = true;
                    break;
            }

            if (!salir)
            {
                Console.Clear();
            }
        }
    }
}