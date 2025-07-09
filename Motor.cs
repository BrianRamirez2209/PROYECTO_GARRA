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
            Velocidad = 1.0f; // velocidad por defecto
            Direccion = "adelante"; // dirección de prueba
            Console.WriteLine($"Motor activado. Dirección: {Direccion}, Velocidad: {Velocidad}");
        }
    }
}