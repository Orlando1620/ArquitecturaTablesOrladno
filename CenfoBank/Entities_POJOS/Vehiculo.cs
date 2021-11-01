using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJOS
{
    public class Vehiculo : BaseEntity
    {
        public string IdVehiculoPlaca { get; set; }
        public int CantidadPasajero { get; set; }
        public string TipoCombustible { get; set; }
        public string TipoVehiculo { get; set; }
        public int AnnoFabricacion { get; set; }
        public double CostoReservaHora { get; set; }
        public double PenalizacionEstadoVehicular { get; set; }
        public double KilometrajeMaximo { get; set; }
        public double CostoKilometrajeExcedido { get; set; }
        public double CostoSeguro { get; set; }
        public string TipoReserva { get; set; }
        public string Longitud { get; set; }
        public string Latitud { get; set; }
        public double CostoHoraAdicional { get; set; }
        public int CantidadPuerta { get; set; }
        public string IdOrganizacion { get; set; }
        public int IdModelo { get; set; }
        public int IdMarca { get; set; }

        public Vehiculo() { }

        public Vehiculo(string[] infoArray)
        {
            IdVehiculoPlaca = infoArray[0].Trim();
            CantidadPasajero = Convert.ToInt32(infoArray[1].Trim());
            TipoCombustible = infoArray[2].Trim();
            TipoVehiculo = infoArray[3].Trim();
            AnnoFabricacion = Convert.ToInt32(infoArray[4].Trim());
            CostoReservaHora = Convert.ToDouble(infoArray[5].Trim());
            PenalizacionEstadoVehicular = Convert.ToDouble(infoArray[6].Trim());
            KilometrajeMaximo = Convert.ToDouble(infoArray[7].Trim());
            CostoKilometrajeExcedido = Convert.ToDouble(infoArray[8].Trim());
            CostoSeguro = Convert.ToDouble(infoArray[9].Trim());
            TipoReserva = infoArray[10].Trim();
            Longitud = infoArray[11].Trim();
            Latitud = infoArray[12].Trim();
            CostoHoraAdicional = Convert.ToDouble(infoArray[13].Trim());
            CantidadPuerta = Convert.ToInt32(infoArray[14].Trim());
            IdOrganizacion = infoArray[15].Trim();
            IdModelo = Convert.ToInt32(infoArray[16].Trim());
            IdMarca = Convert.ToInt32(infoArray[17].Trim());
        }
    }
}
