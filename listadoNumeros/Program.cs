using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<string, double> productos = new Dictionary<string, double>()
        {
            { "Camisa", 25.99 },
            { "Pantalón", 35.50 },
            { "Zapatos", 50.00 },
            { "Gorra", 15.75 },
            { "Bufanda", 12.30 }
        };

        List<string> carrito = new List<string>();
        double total = 0.0;
        const int limiteCarrito = 20;

        Console.WriteLine("¡Bienvenido a la tienda!");

        while (true)
        {
            if (carrito.Count >= limiteCarrito)
            {
                Console.WriteLine("\nHa alcanzado el límite máximo de 20 productos.");
                break;
            }

            Console.WriteLine("\nProductos disponibles:");
            int contador = 1;
            foreach (var producto in productos)
            {
                Console.WriteLine($"{contador}. {producto.Key} - ${producto.Value:F2}");
                contador++;
            }

            Console.WriteLine("\nSeleccione un producto por su número (o escriba 'fin' para terminar):");
            string entrada = Console.ReadLine();

            if (entrada.ToLower() == "fin")
            {
                break;
            }

            if (int.TryParse(entrada, out int seleccion) && seleccion >= 1 && seleccion <= productos.Count)
            {
                string productoSeleccionado = new List<string>(productos.Keys)[seleccion - 1];
                double precio = productos[productoSeleccionado];

                carrito.Add(productoSeleccionado);
                total += precio;
                Console.WriteLine($"\n{productoSeleccionado} agregado al carrito. Precio: ${precio:F2}");
                Console.WriteLine($"Productos en el carrito: {carrito.Count}/{limiteCarrito}");
            }
            else
            {
                Console.WriteLine("\nSelección no válida. Intente de nuevo.");
            }
        }

        Console.WriteLine("\nResumen de su compra:");
        int i=1;
        foreach (string producto in carrito)
        {
            Console.WriteLine($"{i}. {producto}: ${productos[producto]:F2}");
            i++;
        }
        Console.WriteLine($"\nTotal a pagar: ${total:F2}");
        Console.WriteLine("\n¡Gracias por su compra! Vuelva pronto.");
    }
}