using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaSerializacion
{
    public interface ISerializable
    {
        public string RutaDeArchivo { get; set; }
        public bool DeSerializarse();
        public bool Serializarse();
    }
}
