namespace PROYECTO_GARRA
{
    public partial class Maquina
    {
        private Sensor sensor;
        private Motor motor;
        private Interfaz interfaz;
        private Garra garra;


        public Maquina()
        {
            sensor = new Sensor();
            motor = new Motor();
            interfaz = new Interfaz();
            garra = new Garra();
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
