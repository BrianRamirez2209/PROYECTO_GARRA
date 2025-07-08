using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Coordenadas iniciales:");
            float x1 = PedirValor("X");
            float y1 = PedirValor("Y");
            float z1 = PedirValor("Z");

            Console.WriteLine($"→ Moviendo a ({x1}, {y1}, {z1})");

        if (Confirmar("¿Cerrar garra?"))
        {
            Console.WriteLine("→ Garra cerrada.");
            Console.WriteLine("Coordenadas destino:");
            float x2 = PedirValor("X");
            float y2 = PedirValor("Y");
            float z2 = PedirValor("Z");

            Console.WriteLine($"→ Moviendo a ({x2}, {y2}, {z2})");
        }
    }


