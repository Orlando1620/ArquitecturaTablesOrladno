using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJOS
{
    public class Catalogo_Membresia : BaseEntity
    {
        public int IdCatalogoMembresia { get; set; }
        public string Nombre { get; set; }
        public double MontoMensual { get; set; }
        public double Comision { get; set; }
        public DateTime Vigencia { get; set; }
        public string Estado { get; set; }

        public Catalogo_Membresia() { }

        public Catalogo_Membresia(string[] infoArray)
        {
            Nombre = infoArray[0].Trim();
            MontoMensual = Convert.ToDouble(infoArray[1].Trim());
            Comision = Convert.ToDouble(infoArray[2].Trim());
            Vigencia = Convert.ToDateTime(infoArray[3].Trim());
            Estado = infoArray[4].Trim();
        }
    }
}
