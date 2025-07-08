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

        }
    }


