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
        /// <summary>
        /// Lista que contiene las llamadas
        /// </summary>
        public List<Llamada> Llamadas
        {
            get
            {
                return this._listaDeLlamadas;
            }
        }

        /// <summary>
        /// Ganancia por tipo de llamada locales
        /// </summary>
        public float GananciaPorLocal
        {
            get
            {
                return this.CalcularGanancia(TipoLlamada.Local);
            }
        }

        /// <summary>
        /// Ganancia generada por llamadas provinciales
        /// </summary>
        public float GananciaPorProvincial
        {
            get
            {
                return this.CalcularGanancia(TipoLlamada.Provincial);
            }
        }

        /// <summary>
        /// Ganancia Total de la centralita
        /// </summary>
        public float GananciaTotal
        {
            get
            {
                return this.CalcularGanancia(TipoLlamada.Todas);
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto que inicializa la lista
        /// </summary>
        public Centralita()
        {
            this._listaDeLlamadas = new List<Llamada>();
        }

        /// <summary>
        /// Constructor que recibe por parametro la razon social
        /// </summary>
        /// <param name="nombreEmpresa">Razon social de la empresa</param>
        public Centralita(string nombreEmpresa)
            : this()
        {
            this._razonSocial = nombreEmpresa;
        }
        #endregion

        /// <summary>
        /// Calcula la ganancia segun el tipo de llamada
        /// </summary>
        /// <param name="tipo">Tipo de llamada a calcular la ganancia generada</param>
        /// <returns>Ganancia segun el tipo de llamada</returns>
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

        /// <summary>
        /// Ordena la lista de llamadas segun la duracion (menor a mayor)
        /// </summary>
        public void OrdenarLLamadas()
        {
            this._listaDeLlamadas.Sort(Llamada.OrdenarPorDuracion);
        }

        /// <summary>
        /// Muestra por consola los datos de la centralita y el detalle de llamadas
        /// </summary>
        public void Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            
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
                item.Mostrar();
            }
        }
    }
}
