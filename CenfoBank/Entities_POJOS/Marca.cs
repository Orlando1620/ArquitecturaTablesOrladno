using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJOS
{
    public class Marca : BaseEntity
    {
        public int IdMarca { get; set; }
        public string Nombre { get; set; }

        public Marca() { }

        public Marca(string[] infoArray) {
            Nombre = infoArray[0].Trim();
        }
    }
}
