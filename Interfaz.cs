using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
    class Program
    {
        public void IniciarJuego()
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
            if (Confirmar("¿Liberar garra?"))
                Console.WriteLine("→ Objeto liberado.");
            else
                Console.WriteLine("→ No se liberó la garra.");
        }
        else
        {
            Console.WriteLine("→ No se cerró la garra.");
        }

        Console.WriteLine("✓ Fin del proceso.");
        static float PedirValor(string eje)
        {
            Console.Write($"{eje}: ");
            return float.Parse(Console.ReadLine());
        }

        static bool Confirmar(string mensaje)
        {
            Console.Write($"{mensaje} (sí/no): ");
            string r = Console.ReadLine().ToLower();
            return r == "sí" || r == "si";
        }
    }
}
    


