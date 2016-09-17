using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaHerencia
{
    public class Centralita
    {
        private List<Llamada> _listaDeLlamadas;
        protected string _razonSocial;

        #region Propiedades
        public List<Llamada> Llamadas
        {
            get
            {
                return this._listaDeLlamadas;
            }
        }

        public float GananciaPorLocal
        {
            get
            {
                return this.CalcularGanancia(TipoLlamada.Local);
            }
        }

        public float GananciaPorProvincial
        {
            get
            {
                return this.CalcularGanancia(TipoLlamada.Provincial);
            }
        }

        public float GananciaTotal
        {
            get
            {
                return this.CalcularGanancia(TipoLlamada.Todas);
            }
        }
        #endregion

        #region Constructores
        public Centralita()
        {
            this._listaDeLlamadas = new List<Llamada>();
        }

        public Centralita(string nombreEmpresa)
            : this()
        {
            this._razonSocial = nombreEmpresa;
        }
        #endregion

        private float CalcularGanancia(TipoLlamada tipo)
        {
            float ganancia = 0;

            switch(tipo.ToString())
            {
                case "Local":
                    foreach (Local llamadaLocal in this._listaDeLlamadas.OfType<Local>())
	                {
		                ganancia += llamadaLocal.CostoLLamada;
                    }
                    break;

                case "Provincial":
                    foreach (Provincial llamadaProvincial in this._listaDeLlamadas.OfType<Provincial>())
	                {
		                ganancia += llamadaProvincial.CostoLLamada;
	                }
                    break;

                default:
                    Local local;
                    Provincial provincial;
                    foreach (Llamada unaLlamada in  this._listaDeLlamadas)
	                {
		                if(unaLlamada is Local)
                        {
                            local = (Local)unaLlamada;
                            ganancia += local.CostoLLamada;
                        }
                        if(unaLlamada is Provincial)
                        {
                            provincial = (Provincial)unaLlamada;
                            ganancia += provincial.CostoLLamada;
                        }
	                }
                    break;
            }

            return ganancia;
        }

        public void OrdenarLLamadas()
        {
            this._listaDeLlamadas.Sort(Llamada.OrdenarPorDuracion);
        }

        public void Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            Local llamadaLocal;
            Provincial llamadaProvincial;

            sb.AppendLine();
            sb.AppendLine("\t" + this._razonSocial);
            sb.AppendLine("Ganancia por Llamadas Locales: " + this.GananciaPorLocal);
            sb.AppendLine("Ganancia por Llamadas Provinciales: " + this.GananciaPorProvincial);
            sb.AppendLine("Ganancia Total: " + this.GananciaTotal);
            sb.AppendLine();
            sb.AppendLine("\t " + "Detalle de llamadas");
            Console.WriteLine(sb);
            foreach (Llamada item in this.Llamadas)
            {
                if (item is Local)
                {
                    llamadaLocal = (Local)item;
                    llamadaLocal.Mostrar();
                }
                if (item is Provincial)
                {
                    llamadaProvincial = (Provincial)item;
                    llamadaProvincial.Mostrar();
                }
            }
        }
    }
}
