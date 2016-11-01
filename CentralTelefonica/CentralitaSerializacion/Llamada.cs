using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaSerializacion
{
    public abstract class Llamada
    {
        protected float _duracion;
        public float Duracion
        {
            get
            {
                return this._duracion;
            }
        }

        protected string _nroDestino;
        public string NroDestino
        {
            get
            {
                return this._nroDestino;
            }
        }

        protected string _nroOrigen;
        public string NroOrigen
        {
            get
            {
                return this._nroOrigen;
            }
        }

        public abstract float CostoLlamada { get; }

        #region Constructor
        /// <summary>
        /// Constructor que inicializa todos los atributos de la clase
        /// </summary>
        /// <param name="origen">Origen de la llamada</param>
        /// <param name="destino">Destino de la llamada</param>
        /// <param name="duracion">Duracion de la llamada</param>
        public Llamada(string origen, string destino, float duracion)
        {
            this._duracion = duracion;
            this._nroDestino = destino;
            this._nroOrigen = origen;
        }
        #endregion


        /// <summary>
        /// Devuelve un string con los atributos de la clase
        /// </summary>
        protected virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Nro Origen: " + this.NroOrigen);
            sb.AppendLine("Nro Destino: " + this.NroDestino);
            sb.AppendLine("Duracion: " + this.Duracion);

            return sb.ToString();
        }

        /// <summary>
        /// Compara la duracion de la primer llamada con la segunda.
        /// </summary>
        /// <param name="uno">Primer llamada a comparar</param>
        /// <param name="dos">Segunda llamada a comparar</param>
        /// <returns>INT positivo si la primera es mayor, cero si son iguales, negativo si la segunda es mayor</returns>
        public static int OrdenarPorDuracion(Llamada uno, Llamada dos)
        {
            return uno.Duracion.CompareTo(dos.Duracion);
        }

        /// <summary>
        /// Compara los tipos de llamada y sus nro de origen y destino
        /// </summary>
        /// <param name="uno"></param>
        /// <param name="dos"></param>
        /// <returns>Retorna true si las llamadas son de igual tipo con mismos nro de destino y origen</returns>
        public static bool operator ==(Llamada uno, Llamada dos)
        {
            if (!uno.Equals(dos))
                return false;

            if (uno._nroDestino == dos._nroDestino && uno._nroOrigen == dos._nroOrigen)
                return true;

            return false;
        }

        public static bool operator !=(Llamada uno, Llamada dos)
        {
            return !(uno == dos);
        }

    }
}
