namespace PROYECTO_GARRA
{
    public partial class Maquina
    {
        public Sensor sensor;
        public Motor motor;
        public Interfaz interfaz;
        public Garra garra;


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
