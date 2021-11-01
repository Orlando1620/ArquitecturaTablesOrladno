using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJOS
{
    public class Dias_Reserva : BaseEntity
    {
        public int IdDiaReserva { get; set; }
        public DateTime FechaReserva { get; set; }
        public string Estado { get; set; }
        public string IdVehiculoPlaca { get; set; }

        public Dias_Reserva() { }

        public Dias_Reserva(string[] infoArray)
        {
            FechaReserva = Convert.ToDateTime(infoArray[0].Trim());
            Estado = infoArray[1].Trim();
            IdVehiculoPlaca = infoArray[2].Trim();
        }
    }
}
