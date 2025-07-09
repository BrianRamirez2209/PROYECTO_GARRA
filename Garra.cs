

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
