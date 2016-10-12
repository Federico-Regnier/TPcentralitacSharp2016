using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaHerencia
{
    public class Local : Llamada
    {
        protected float _costo;
        public float CostoLLamada
        {
            get
            {
                return this.CalcularCosto();
            }
        }

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

        /// <summary>
        /// Devuelve el costo calculado como duracion * costo por min
        /// </summary>
        /// <returns>Costo de llamada</returns>
        private float CalcularCosto()
        {
            return (this._duracion * this._costo);
        }

        /// <summary>
        /// Imprime por consola los atributos de la clase
        /// </summary>
        public override void Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            base.Mostrar();
            sb.AppendLine("Costo Llamada: " + this.CostoLLamada);

            Console.WriteLine(sb);
            
        }
    }
}
