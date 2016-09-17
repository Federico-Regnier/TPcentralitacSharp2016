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

        public Local(string origen, float duracion, string destino, float costo)
            : base(origen, destino, duracion)
        {
            this._costo = costo;
        }

        public Local(Llamada unaLlamada, float costo) : this(unaLlamada.NroOrigen, unaLlamada.Duracion, unaLlamada.NroDestino, costo) { }

        private float CalcularCosto()
        {
            return (this._duracion * this._costo);
        }

        public void Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            /*sb.AppendLine("Nro Origen: " + this.NroOrigen);
            sb.AppendLine("Nro Destino: " + this.NroDestino);
            sb.AppendLine("Duracion: " + this.Duracion);*/
            base.Mostrar();
            sb.AppendLine("Costo Llamada: " + this.CostoLLamada);

            Console.WriteLine(sb);
            
        }
    }
}
