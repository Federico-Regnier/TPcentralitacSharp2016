using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaSerializacion
{
    [Serializable]
    public class Local : Llamada
    {
        protected float _costo;
        public float Costo
        {
            get
            {
                return this._costo;
            }
            set
            {
                this._costo = value;
            }
        }

        public override float CostoLlamada
        {
            get 
            {
                return this.CalcularCosto(); 
            }
        }

        #region Constructores

        public Local() { }

        /// <summary>
        /// Constructor de clase, inicializa los atributos de la clase y los de la base.
        /// </summary>
        /// <param name="origen">Origen de la llamada</param>
        /// <param name="duracion">Duracion de la llamada</param>
        /// <param name="destino">Destino de la llamada</param>
        /// <param name="costo">Costo de llamada</param>
        public Local(string origen, float duracion, string destino, float costo)
            : base(origen, destino, duracion)
        {
            this._costo = costo;
        }

        public Local(Llamada unaLlamada, float costo) : this(unaLlamada.NroOrigen, unaLlamada.Duracion, unaLlamada.NroDestino, costo) { }
        #endregion

        /// <summary>
        /// Devuelve el costo calculado como duracion * costo por min
        /// </summary>
        /// <returns>Costo de llamada</returns>
        private float CalcularCosto()
        {
            return (this._duracion * this._costo);
        }
        
        /// <summary>
        /// Devuelve un string con los atributos de la clase
        /// </summary>
        protected override string  Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.Mostrar());
            sb.AppendLine("Costo Llamada: " + this.CostoLlamada);

            return sb.ToString();
            
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(Local))
                return true;

            return false;
        }

        public override string ToString()
        {
            return this.Mostrar();
        }
    }
}
