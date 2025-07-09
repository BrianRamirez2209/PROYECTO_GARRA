using PROYECTO_GARRA;

namespace PROYECTO_GARRA
{

     public class Maquina
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


    public void InsertarMoneda()
        {
            Console.WriteLine("Moneda insertada");
            interfaz.IniciarJuego();
          

            motor.ActivarMotor();
            Console.WriteLine("Motor activado");


            garra.IniciarCiclo();

            if (sensor.DetectarObjeto())
            {
                Console.WriteLine("¡Objeto detectado por la garra!");
            }
            else
            {
                Console.WriteLine("No se detectó ningún objeto.");
            }
        }
    }









    internal class Program
    {
        static void Main(string[] args)
        {

        Maquina maquina = new Maquina();
        maquina.InsertarMoneda();

    }
    }
}
