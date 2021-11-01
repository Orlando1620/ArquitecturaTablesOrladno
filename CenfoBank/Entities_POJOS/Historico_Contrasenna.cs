using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJOS
{
    public class Historico_Contrasenna : BaseEntity
    {
        public int IdContrasenna { get; set; }
        public string Contrasennas { get; set; }
        public string Estado { get; set; }
        public string IdUsuario { get; set; }

        public Historico_Contrasenna() { }

        public Historico_Contrasenna(string[] infoArray) {
            Contrasennas = infoArray[0].Trim();
            Estado = infoArray[1].Trim();
            IdUsuario = infoArray[2].Trim();
        }
    }
}
