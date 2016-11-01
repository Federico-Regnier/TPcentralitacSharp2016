using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaSerializacion
{
    public class CentralitaException : Exception
    {
        protected Exception _excepcionInterna;
        public Exception ExcepcionInterna
        {
            get
            {
                return this._excepcionInterna;
            }
        }

        protected string _nombreClase;
        public string NombreClase
        {
            get
            {
                return this._nombreClase;
            }
        }

        protected string _nombreMetodo;
        public string NombreMetodo
        {
            get
            {
                return this._nombreMetodo;
            }
        }

        public CentralitaException(string mensaje, string clase, string metodo)
            : base(mensaje)
        {
            this._nombreClase = clase;
            this._nombreMetodo = metodo;
        }

        public CentralitaException(string mensaje, string clase, string metodo, Exception innerException)
            : this(mensaje, clase, metodo)
        {
            this._excepcionInterna = innerException;
        }

    }
}
