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

        public Provincial(string origen, Franja miFranja, float duracion, string destino)
            : base(origen, destino, duracion)
        {
            this._franjaHoraria = miFranja;
        }

        public Provincial(Llamada unallamada, Franja miFranja) : this(unallamada.NroOrigen, miFranja, unallamada.Duracion, unallamada.NroDestino) { }


        private float CalcularCosto()
        {
            switch ((int)this._franjaHoraria)
            {
                case 0:
                    return (this.Duracion * (float)0.99);

                case 1:
                    return (this.Duracion * (float)1.25);

                case 2:
                    return (this.Duracion * (float)0.66);

                default:
                    return 0;
             }
        }

        public void Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            /*sb.AppendLine("Nro Origen: " + this.NroOrigen);
            sb.AppendLine("Nro Destino: " + this.NroDestino);
            sb.AppendLine("Duracion: " + this.Duracion);*/
            base.Mostrar();
            sb.AppendLine("Franja Horaria: " + this._franjaHoraria.ToString());
            sb.AppendLine("Costo Llamada: " + this.CostoLLamada);

            Console.WriteLine(sb);
        }



    }
}
