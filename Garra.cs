using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

// Arquitectura de la Máquina con Garra en C# (simulación jerárquica)
// Estructura en consola para luego implementarse en Unity

using System;

namespace MaquinaGarra
{
    // Clase base: la estructura que sostiene toda la máquina y permite desplazamiento en X
    public class BaseX
    {
        public float PosX { get; private set; } // Posición actual en X
        public float LimiteX { get; private set; } // Límite máximo de desplazamiento en X
        public CarroZ carroZ; // Contiene el mecanismo de movimiento en Z

        public BaseX(float largoGarra)
        {
            LimiteX = 5 * largoGarra; // Límite X es 5 veces el largo de la garra
            PosX = 0; // Inicia en posición 0
            carroZ = new CarroZ(largoGarra); // Inicializa el carroZ
        }

        // Mueve el carroZ en la dirección X dentro del rango permitido
        public bool MoverCarroZ(float nuevaX)
        {
            if (nuevaX < 0 || nuevaX > LimiteX)
            {
                Console.WriteLine("❌ Movimiento en X fuera de rango");
                return false;
            }

            PosX = nuevaX;
            Console.WriteLine($"➡️ CarroZ movido a X = {PosX}");
            return true;
        }
    }

    // Clase que representa el carroZ que se desliza sobre la base X y contiene el soporte de la garra
    public class CarroZ
    {
        public float PosZ { get; private set; } // Posición actual en Z
        public float LimiteZ { get; private set; } // Límite máximo de desplazamiento en Z
        public SoporteGarra soporte;

        public CarroZ(float largoGarra)
        {
            LimiteZ = 3.5f * largoGarra; // Límite Z es 3.5 veces el largo de la garra
            PosZ = 0;
            soporte = new SoporteGarra(largoGarra); // Contiene la garra
        }

        // Mueve el soporte de la garra en la dirección Z dentro del rango permitido
        public bool MoverSoporte(float nuevaZ)
        {
            if (nuevaZ < 0 || nuevaZ > LimiteZ)
            {
                Console.WriteLine("❌ Movimiento en Z fuera de rango");
                return false;
            }

            PosZ = nuevaZ;
            Console.WriteLine($"➡️ SoporteGarra movido a Z = {PosZ}");
            return true;
        }
    }

    // Clase que contiene la garra que sube/baja y abre/cierra
    public class SoporteGarra
    {
        public Garra garra;

        public SoporteGarra(float largoGarra)
        {
            garra = new Garra(largoGarra); // Inicializa la garra con el tamaño base
        }
    }

    // Clase final que controla la lógica de la garra: subida, bajada y manipulación de pinzas
    public class Garra
    {
        private float alturaY;
        private float alturaMax;
        private float alturaMin;

        private float aperturaActual;
        private float aperturaMax;
        private float aperturaMin;
        private bool estaCerrada;
        private float tamañoObjeto;

        public Garra(float largoGarra)
        {
            alturaMax = 3 * largoGarra; // Altura máxima
            alturaMin = 0.2f; // Altura mínima permitida
            aperturaMax = 1.5f; // Máxima apertura de las pinzas
            aperturaMin = 0.2f; // Mínima apertura (pinzas cerradas)

            alturaY = alturaMax; // Inicia en la altura máxima
            aperturaActual = aperturaMax;
            estaCerrada = false;
            tamañoObjeto = 0;
        }

        public void Bajar()
        {
            alturaY = alturaMin;
            Console.WriteLine("🔽 Garra bajada.");
        }

        public void Subir()
        {
            alturaY = alturaMax;
            Console.WriteLine("🔼 Garra subida.");
        }

        public void CargarObjeto(float tamaño)
        {
            tamañoObjeto = tamaño;
            Console.WriteLine($"📦 Objeto de {tamañoObjeto} unidades colocado entre las pinzas.");
        }

        public void CerrarPinzas()
        {
            if (tamañoObjeto >= aperturaMin && tamañoObjeto <= aperturaMax)
            {
                aperturaActual = tamañoObjeto;
                estaCerrada = true;
                Console.WriteLine("🤏 Pinzas cerradas con objeto.");
            }
            else
            {
                aperturaActual = aperturaMin;
                estaCerrada = true;
                Console.WriteLine("🤏 Pinzas cerradas (no se detectó objeto válido).");
            }
        }

        public void AbrirPinzas()
        {
            aperturaActual = aperturaMax;
            estaCerrada = false;
            tamañoObjeto = 0;
            Console.WriteLine("✋ Pinzas abiertas.");
        }

        public void Estado()
        {
            Console.WriteLine($"📍 Altura Y: {alturaY}, Apertura: {aperturaActual}, ¿Cerrada?: {estaCerrada}");
        }

        // Método para mover en Y con validación
        public bool MoverY(float nuevaY, float largoGarra)
        {
            float min = 0.2f;
            float max = 3 * largoGarra;

            if (nuevaY < min || nuevaY > max)
            {
                Console.WriteLine("❌ Movimiento en Y fuera de rango");
                return false;
            }

            alturaY = nuevaY;
            Console.WriteLine($"➡️ Garra movida a Y = {alturaY}");
            return true;
        }
    }

    // To fix IDE0060, we can remove the unused "args" parameter from the Main method signature.
    class Program
    {
        private static void Main()
        {
            float largoBase = 1.0f;
            BaseX baseX = new BaseX(largoBase);

            while (true)
            {
                Console.WriteLine("\n📌 Ingrese X Z Y (o 'salir'):");
                string input = Console.ReadLine();
                if (input.ToLower() == "salir") break;

                // Leer coordenadas ingresadas
                string[] valores = input.Split(' ');
                if (valores.Length != 3 ||
                    !float.TryParse(valores[0], out float x) ||
                    !float.TryParse(valores[1], out float z) ||
                    !float.TryParse(valores[2], out float y))
                {
                    Console.WriteLine("❌ Entrada inválida");
                    continue;
                }

                // Movimiento por jerarquía
                if (!baseX.MoverCarroZ(x)) continue;
                if (!baseX.carroZ.MoverSoporte(z)) continue;
                if (!baseX.carroZ.soporte.garra.MoverY(y, largoBase)) continue;

                Console.WriteLine("\n¿Cerrar pinzas? (s/n)");
                if (Console.ReadLine().ToLower() == "s")
                {
                    Console.Write("👉 Tamaño objeto: ");
                    if (float.TryParse(Console.ReadLine(), out float tam))
                    {
                        var garra = baseX.carroZ.soporte.garra;
                        garra.CargarObjeto(tam);
                        garra.Bajar();
                        garra.CerrarPinzas();
                        garra.Subir();
                    }
                }

                Console.WriteLine("\n¿Liberar objeto? (s/n)");
                if (Console.ReadLine().ToLower() == "s")
                {
                    var garra = baseX.carroZ.soporte.garra;
                    garra.Bajar();
                    garra.AbrirPinzas();
                    garra.Subir();
                    baseX.MoverCarroZ(0);
                    baseX.carroZ.MoverSoporte(0);
                }
            }
        }
    }
}
