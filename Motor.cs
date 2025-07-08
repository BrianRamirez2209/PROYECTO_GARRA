using System;


namespace PROYECTO_GARRA
{
    public class Motor
    {
        public float Velocidad;
        public string Direccion;
        public bool Encendido;

        public void ActivarMotor()
        {
            Encendido = true;
            Console.WriteLine("Motor activado y girando...");
        }
    }
}
