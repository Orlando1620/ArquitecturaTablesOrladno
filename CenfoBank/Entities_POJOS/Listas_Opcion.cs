using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJOS
{
    public class Listas_Opcion : BaseEntity
    {
        public string IdListaOpcion { get; set; }
        public string Valor { get; set; }
        public string Descripcion { get; set; }


        public Listas_Opcion() { }

        public Listas_Opcion(string[] infoarray) {
            IdListaOpcion = infoarray[0].Trim();
            Valor = infoarray[1].Trim();
            Descripcion = infoarray[2].Trim();
        }
    }
}
