using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJOS
{
    public class Rol : BaseEntity
    {
        public int IdRol { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }

        public Rol() { }

        public Rol(string[] infoArray)
        {
            Nombre = infoArray[0].Trim();
            Estado = infoArray[1].Trim();
        }
    }
}
