using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJOS
{
    public class RolesXUsuario : BaseEntity
    {
        public string IdUsuario { get; set; }
        public int IdRol { get; set; }

        public RolesXUsuario() { }

        public RolesXUsuario(string[] infoArray) {
            IdUsuario = infoArray[0].Trim();
            IdRol = Convert.ToInt32(infoArray[1].Trim());
        }
    }
}
