using System;
// Arquitectura de la Máquina con Garra en C# (simulación jerárquica)
// Estructura en consola para luego implementarse en Unity

using System;
// PROYECTO UNITY - MÁQUINA DE GARRA EN 3D
// Este script simula el funcionamiento de una garra de premios controlada por coordenadas X, Y, Z
// en un sistema de movimiento compuesto por barra X, barra Z, y la estructura de la garra.
// Se basa en una arquitectura compuesta por estructuras rígidas y deslizantes
// para simular el movimiento físico en un entorno Unity

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class MaquinaGarra : MonoBehaviour
{
    // Parámetros ajustables en el Inspector de Unity
    public GameObject garra;
    public GameObject cubo1;
    public GameObject cubo2;
    public GameObject baseGarra;
    public GameObject barraX;
    public GameObject barraZ;
    public GameObject baseX;
    public GameObject baseZ;

    public float largoGarra = 1f;

    private float limiteX;
    private float limiteY;
    private float limiteZ;

    private Vector3 origen;
    private float aperturaPinza = 1.5f;
    private float cierreMinimo = 0.2f;

    private bool objetoDetectado = true; // Simulación

    void Start()
    {
        // Establecer límites según arquitectura definida
        limiteX = largoGarra * 5f;
        limiteZ = largoGarra * 3.5f;
        limiteY = largoGarra * 3f;

        origen = new Vector3(0, limiteY, 0);
        garra.transform.position = origen;

        Debug.Log("🔧 Máquina de garra inicializada");
    }

    void Update()
    {
        // Ejecución controlada por teclado para pruebas
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IniciarCiclo();
        }
    }

    void IniciarCiclo()
    {
        Debug.Log("\n🟡 INICIO DE OPERACIÓN");

        // Paso 1: Obtener coordenadas
        float x = SolicitarCoordenada("X", limiteX);
        float z = SolicitarCoordenada("Z", limiteZ);
        float y = SolicitarCoordenada("Y", limiteY);

        // Validación
        if (x < 0 || x > limiteX || z < 0 || z > limiteZ || y < 0 || y > limiteY)
        {
            Debug.Log("❌ Coordenadas fuera de rango. No se ejecuta.");
            return;
        }

        // Paso 2: Movimiento en X
        MoverX(x);

        // Paso 3: Movimiento en Z
        MoverZ(z);

        // Paso 4: Movimiento en Y hacia abajo
        MoverY(y);

        // Paso 5: Preguntar por cierre
        Debug.Log("¿Desea cerrar la garra? (s/n)");
        string r1 = SimularRespuesta();
        if (r1.ToLower() == "s")
        {
            CerrarPinza();
        }

        // Paso 6: Subir garra
        MoverY(limiteY);

        // Paso 7: Pedir nueva posición para soltar
        float x2 = SolicitarCoordenada("X destino", limiteX);
        float z2 = SolicitarCoordenada("Z destino", limiteZ);
        float y2 = SolicitarCoordenada("Y destino", limiteY);

        if (x2 < 0 || x2 > limiteX || z2 < 0 || z2 > limiteZ || y2 < 0 || y2 > limiteY)
        {
            Debug.Log("❌ Coordenadas fuera de rango. No se ejecuta.");
            return;
        }

        MoverX(x2);
        MoverZ(z2);
        MoverY(y2);

        Debug.Log("¿Desea soltar el objeto? (s/n)");
        string r2 = SimularRespuesta();
        if (r2.ToLower() == "s")
        {
            AbrirPinza();
        }

        // Volver a origen
        MoverY(limiteY);
        MoverX(0);
        MoverZ(0);
        Debug.Log("✅ Ciclo finalizado. Máquina en posición de origen.");
    }

    float SolicitarCoordenada(string eje, float limite)
    {
        Debug.Log($"Ingrese coordenada {eje} (max {limite}):");
        return UnityEngine.Random.Range(0f, limite); // Se simula entrada por consola
    }

    string SimularRespuesta()
    {
        return "s"; // Cambia a "n" si quieres simular negativa
    }

    void MoverX(float x)
    {
        Vector3 pos = garra.transform.position;
        garra.transform.position = new Vector3(x, pos.y, pos.z);
        Debug.Log($"➡️ Garra movida a X = {x}");
    }

    void MoverZ(float z)
    {
        Vector3 pos = garra.transform.position;
        garra.transform.position = new Vector3(pos.x, pos.y, z);
        Debug.Log($"➡️ Garra movida a Z = {z}");
    }

    void MoverY(float y)
    {
        Vector3 pos = garra.transform.position;
        garra.transform.position = new Vector3(pos.x, y, pos.z);
        Debug.Log($"↕️ Garra movida a Y = {y}");
    }

    void CerrarPinza()
    {
        if (objetoDetectado)
        {
            cubo1.transform.localPosition = new Vector3(-0.2f, 0, 0);
            cubo2.transform.localPosition = new Vector3(0.2f, 0, 0);
            Debug.Log("🤏 Pinzas cerradas. Objeto agarrado.");
        }
        else
        {
            cubo1.transform.localPosition = new Vector3(-cierreMinimo, 0, 0);
            cubo2.transform.localPosition = new Vector3(cierreMinimo, 0, 0);
            Debug.Log("🤏 Pinzas cerradas sin objeto.");
        }
    }

    void AbrirPinza()
    {
        cubo1.transform.localPosition = new Vector3(-aperturaPinza / 2f, 0, 0);
        cubo2.transform.localPosition = new Vector3(aperturaPinza / 2f, 0, 0);
        Debug.Log("✋ Pinzas abiertas. Objeto liberado.");
    }
}
