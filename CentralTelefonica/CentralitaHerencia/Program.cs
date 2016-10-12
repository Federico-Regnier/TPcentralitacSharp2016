using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaHerencia
{
    class Program
    {
        static void Main(string[] args)
        {
            Centralita miCentralita = new Centralita("Telefonica");
            
            miCentralita.Llamadas.Add(new Local("444", (float)30/60, "555", (float)2.65));
            miCentralita.Llamadas.Last().Mostrar();
            miCentralita.Llamadas.Add(new Provincial("666", Franja.Franja_1, (float)21/60, "777"));
            miCentralita.Llamadas.Last().Mostrar();
            miCentralita.Llamadas.Add(new Local("444", (float)45/60, "555", (float)1.99));
            miCentralita.Llamadas.Last().Mostrar();
            miCentralita.Llamadas.Add(new Provincial(miCentralita.Llamadas[1], Franja.Franja_3));
            miCentralita.Llamadas.Last().Mostrar();

            miCentralita.OrdenarLLamadas();
            miCentralita.Mostrar();
            Console.ReadKey();

        }
    }
}
