using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaSerializacion
{
    [Serializable]
    public class Centralita
    {
        private List<Llamada> _listaDeLlamadas;
        protected string _razonSocial;
        private string _ruta;
        public string RutaDeArchivo
        {
            get
            {
                return this._ruta;
            }

            set
            {
                this._ruta = value;
            }
        }

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
                        ganancia += llamadaLocal.CostoLlamada;
                    }
                    break;

                case "Provincial":
                    foreach (Provincial llamadaProvincial in this._listaDeLlamadas.OfType<Provincial>())
	                {
		                ganancia += llamadaProvincial.CostoLlamada;
	                }
                    break;

                default:
                    foreach (Llamada unaLlamada in  this._listaDeLlamadas)
	                {
                        ganancia += unaLlamada.CostoLlamada;
	                }
                    break;
            }

            return ganancia;
        }

        /// <summary>
        /// Agrega una nueva llamada a la centralita
        /// </summary>
        /// <param name="nuevaLlamada">Llamada a agregar</param>
        private void AgregarLlamada(Llamada nuevaLlamada)
        {
            this._listaDeLlamadas.Add(nuevaLlamada);
        }

        /// <summary>
        /// Ordena la lista de llamadas segun la duracion (menor a mayor)
        /// </summary>
        public void OrdenarLLamadas()
        {
            this._listaDeLlamadas.Sort(Llamada.OrdenarPorDuracion);
        }

        public static bool operator ==(Centralita central, Llamada nuevaLlamada)
        {
            foreach (Llamada item in central.Llamadas)
            {
                if (nuevaLlamada == item)
                    return true;
            }

            return false;
        }

        public static bool operator !=(Centralita central, Llamada nuevaLlamada)
        {
            return !(central == nuevaLlamada);
        }

        public static Centralita operator +(Centralita central, Llamada nuevaLlamada)
        {
            if (central != nuevaLlamada)
            {
                central.AgregarLlamada(nuevaLlamada);
                return central;
            }

            throw new CentralitaException("La llamada ya existe", "Centralita", "AgregarLlamada");

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine();
            sb.AppendLine("\t" + this._razonSocial);
            sb.AppendLine("=======================================");
            sb.AppendLine("Ganancia por Llamadas Locales: " + this.GananciaPorLocal);
            sb.AppendLine("Ganancia por Llamadas Provinciales: " + this.GananciaPorProvincial);
            sb.AppendLine("Ganancia Total: " + this.GananciaTotal);
            sb.AppendLine();
            sb.AppendLine("\t " + "Detalle de llamadas");
            sb.AppendLine("=======================================");
            foreach (Llamada item in this.Llamadas)
            {
                sb.Append(item.ToString()).AppendLine();
            }

            return sb.ToString();
        }



    }
}
