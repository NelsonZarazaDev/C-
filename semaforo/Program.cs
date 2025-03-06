using System;
using System.Threading;

class SemaforoEjercicio
{
    static void Main()
    {
        int semaforo;
        string entrada;
        do
        {
            Console.WriteLine("Ingrese el número del semáforo");
            Console.WriteLine("1. Semáforo vehicular - 2. Semáforo peatonal - 3. Salir");
            entrada = Console.ReadLine();

            if (int.TryParse(entrada, out semaforo))
            {
                break;
            }
            else
            {
                semaforo = 0;
            }

        } while (semaforo < 1 || semaforo > 3);

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
                for (int tiempo = 0; tiempo <= 125; tiempo++)
                {
                    Console.Clear();
                    Console.WriteLine("******** SEMÁFORO VEHICULAR ********");

                    if (hayEmergencia && tiempo == tiempoEmergencia)
                    {
                        Console.WriteLine("¡EMERGENCIA EN PROCESO! Semáforo en VERDE");
                        Thread.Sleep(10000); // La emergencia dura 10 segundos
                        continue; // Permite que el ciclo continúe después de la emergencia
                    }

                    string color = "";
                    if (tiempo >= 0 && tiempo <= 60)
                    {
                        color = "VERDE";
                    }
                    else if (tiempo > 60 && tiempo <= 65)
                    {
                        color = "AMARILLO";
                    }
                    else if (tiempo > 65)
                    {
                        color = "ROJO";
                    }
                    Console.WriteLine($"SEMAFORO EN {color} - Tiempo restante: {125 - tiempo} seg");
                    Thread.Sleep(1000);
                }
                Console.WriteLine("******** SEMÁFORO APAGADO ********");
                break;

            case 2:
                Console.WriteLine("******** SEMÁFORO PEATONAL ********");
                for (int tiempo = 0; tiempo <= 60; tiempo++)
                {
                    Console.Clear();
                    Console.WriteLine("******** SEMÁFORO PEATONAL ********");
                    string color = tiempo <= 30 ? "VERDE" : "ROJO";
                    Console.WriteLine($"SEMAFORO EN {color} - Tiempo restante: {60 - tiempo} seg");
                    Thread.Sleep(1000);
                }
                Console.WriteLine("******** SEMÁFORO APAGADO ********");
                break;

            case 3:
                Console.WriteLine("******** SEMÁFORO APAGADO ********");
                break;
        }
    }
}
