using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaPolimorfismo
{
    class Program
    {
        static void Main(string[] args)
        {
            Centralita miCentralita = new Centralita("Telefonica");
            Llamada nuevaLlamada;

            nuevaLlamada = new Local("444", (float)30 / 60, "555", (float)2.65);
            miCentralita = miCentralita + nuevaLlamada;
            Console.WriteLine(nuevaLlamada.ToString());
            
            nuevaLlamada = new Provincial("666", Franja.Franja_1, (float)21 / 60, "777");
            miCentralita = miCentralita + nuevaLlamada;
            Console.WriteLine(nuevaLlamada.ToString());
            
            nuevaLlamada = new Local("4544", (float)45 / 60, "565", (float)1.99);
            miCentralita = miCentralita + nuevaLlamada;
            Console.WriteLine(nuevaLlamada.ToString());
            
            nuevaLlamada = new Provincial(miCentralita.Llamadas[1], Franja.Franja_3);
            miCentralita = miCentralita + nuevaLlamada;
            Console.WriteLine(nuevaLlamada.ToString());
            
            nuevaLlamada = new Local("444", (float)30 / 60, "555", (float)2.65);
            miCentralita += nuevaLlamada;
            Console.WriteLine(nuevaLlamada.ToString());
            
            miCentralita.OrdenarLLamadas();
            Console.WriteLine(miCentralita.ToString());
            Console.ReadKey();

        }
    }
}
