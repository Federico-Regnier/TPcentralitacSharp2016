using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaHerencia
{
    public class Provincial : Llamada
    {
        protected Franja _franjaHoraria;

        public float CostoLLamada
        {
            get
            {
                return this.CalcularCosto();
            }
        }

        /// <summary>
        /// Constructor que inicializa todos los atributos de la clase
        /// </summary>
        /// <param name="origen">Origen de la llamada</param>
        /// <param name="miFranja">Franja Horaria</param>
        /// <param name="duracion">Duracion de la llamada</param>
        /// <param name="destino">Destino de la llamada</param>
        public Provincial(string origen, Franja miFranja, float duracion, string destino)
            : base(origen, destino, duracion)
        {
            this._franjaHoraria = miFranja;
        }

        public Provincial(Llamada unallamada, Franja miFranja) : this(unallamada.NroOrigen, miFranja, unallamada.Duracion, unallamada.NroDestino) { }

        /// <summary>
        /// Calcula el costo segun la franja horaria
        /// </summary>
        /// <returns>Costo de llamada</returns>
        private float CalcularCosto()
        {
            switch (this._franjaHoraria)
            {
                case Franja.Franja_1:
                    return (this.Duracion * (float)0.99);

                case Franja.Franja_2:
                    return (this.Duracion * (float)1.25);

                case Franja.Franja_3:
                    return (this.Duracion * (float)0.66);

                default:
                    return 0;
             }
        }

        /// <summary>
        /// Imprime por consola los atributos de clase
        /// </summary>
        public override void Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            base.Mostrar();
            sb.AppendLine("Franja Horaria: " + this._franjaHoraria.ToString());
            sb.AppendLine("Costo Llamada: " + this.CostoLLamada);

            Console.WriteLine(sb);
        }



    }
}
