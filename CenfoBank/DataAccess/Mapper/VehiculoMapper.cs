using DataAccess.Dao;
using Entities_POJOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class VehiculoMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID_VEHICULO_PLACA = "ID_VEHICULO_PLACA";
        private const string DB_COL_CANTIDAD_PASAJERO = "CANTIDAD_PASAJEROS";
        private const string DB_COL_TIPO_COMBUSTIBLE = "TIPO_COMBUSTIBLE";
        private const string DB_COL_TIPO_VEHICULO = "TIPO_VEHICULO";
        private const string DB_COL_ANNO_FABRICACION = "ANNO_FABRICACION";
        private const string DB_COL_COSTO_RESERVA_HORA = "COSTO_RESERVA_HORA";
        private const string DB_COL_PENALIZACION_ESTADO_VEHICULAR = "PENALIZACION_ESTADO_VEHICULAR";
        private const string DB_COL_KILOMETRAJE_MAXIMO = "KILOMETRAJE_MAXIMO";
        private const string DB_COL_COSTO_KILOMETRAJE_EXCEDIDO = "COSTO_KILOMETRAJE_EXCEDIDO";
        private const string DB_COL_COSTO_SEGURO = "COSTO_SEGURO";
        private const string DB_COL_TIPO_RESERVA = "TIPO_RESERVA";
        private const string DB_COL_LONGITUD = "LONGITUD";
        private const string DB_COL_LATITUD = "LATITUD";
        private const string DB_COL_COSTO_HORA_ADICIONAL = "COSTO_HORA_ADICIONAL";
        private const string DB_COL_CANTIDAD_PUERTA = "CANTIDAD_PUERTAS";
        private const string DB_COL_ID_ORGANIZACION = "ID_ORGANIZACION";
        private const string DB_COL_ID_MODELO = "ID_MODELO";
        private const string DB_COL_IDMARCA = "ID_MARCA";

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var vehiculo = new Vehiculo
            {

                IdVehiculoPlaca = GetStringValue(row, DB_COL_ID_VEHICULO_PLACA),
                CantidadPasajero = GetIntValue(row, DB_COL_CANTIDAD_PASAJERO),
                TipoCombustible = GetStringValue(row, DB_COL_TIPO_COMBUSTIBLE),
                TipoVehiculo = GetStringValue(row, DB_COL_TIPO_VEHICULO),
                AnnoFabricacion = GetIntValue(row, DB_COL_ANNO_FABRICACION),
                CostoReservaHora = GetDoubleValue(row, DB_COL_COSTO_RESERVA_HORA),
                PenalizacionEstadoVehicular = GetDoubleValue(row, DB_COL_PENALIZACION_ESTADO_VEHICULAR),
                KilometrajeMaximo = GetDoubleValue(row, DB_COL_KILOMETRAJE_MAXIMO),
                CostoKilometrajeExcedido = GetDoubleValue(row, DB_COL_COSTO_KILOMETRAJE_EXCEDIDO),
                CostoSeguro = GetDoubleValue(row, DB_COL_COSTO_SEGURO),
                TipoReserva = GetStringValue(row, DB_COL_TIPO_RESERVA),
                Longitud = GetStringValue(row, DB_COL_LONGITUD),
                Latitud = GetStringValue(row, DB_COL_LATITUD),
                CostoHoraAdicional = GetDoubleValue(row, DB_COL_COSTO_HORA_ADICIONAL),
                CantidadPuerta = GetIntValue(row, DB_COL_CANTIDAD_PUERTA),
                IdOrganizacion = GetStringValue(row, DB_COL_ID_ORGANIZACION),
                IdModelo = GetIntValue(row, DB_COL_ID_MODELO),
                IdMarca = GetIntValue(row, DB_COL_IDMARCA)

            };
            return vehiculo;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var vehiculo = BuildObject(row);
                lstResults.Add(vehiculo);
            }

            return lstResults;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_VEHICULO_PR" };
            var vehiculo = (Vehiculo)entity;
            operation.AddNvarcharParam(DB_COL_ID_VEHICULO_PLACA, vehiculo.IdVehiculoPlaca);
            operation.AddIntParam(DB_COL_CANTIDAD_PASAJERO, vehiculo.CantidadPasajero);
            operation.AddNvarcharParam(DB_COL_TIPO_COMBUSTIBLE, vehiculo.TipoCombustible);
            operation.AddNvarcharParam(DB_COL_TIPO_VEHICULO, vehiculo.TipoVehiculo);
            operation.AddIntParam(DB_COL_ANNO_FABRICACION, vehiculo.AnnoFabricacion);
            operation.AddDoubleParam(DB_COL_COSTO_RESERVA_HORA, vehiculo.CostoReservaHora);
            operation.AddDoubleParam(DB_COL_PENALIZACION_ESTADO_VEHICULAR, vehiculo.PenalizacionEstadoVehicular);
            operation.AddDoubleParam(DB_COL_KILOMETRAJE_MAXIMO, vehiculo.KilometrajeMaximo);
            operation.AddDoubleParam(DB_COL_COSTO_KILOMETRAJE_EXCEDIDO, vehiculo.CostoKilometrajeExcedido);
            operation.AddDoubleParam(DB_COL_COSTO_SEGURO, vehiculo.CostoSeguro);
            operation.AddNvarcharParam(DB_COL_TIPO_RESERVA, vehiculo.TipoReserva);
            operation.AddNvarcharParam(DB_COL_LONGITUD, vehiculo.Longitud);
            operation.AddNvarcharParam(DB_COL_LATITUD, vehiculo.Latitud);
            operation.AddDoubleParam(DB_COL_COSTO_HORA_ADICIONAL, vehiculo.CostoHoraAdicional);
            operation.AddIntParam(DB_COL_CANTIDAD_PUERTA, vehiculo.CantidadPuerta);
            operation.AddNvarcharParam(DB_COL_ID_ORGANIZACION, vehiculo.IdOrganizacion);
            operation.AddIntParam(DB_COL_ID_MODELO, vehiculo.IdModelo);
            operation.AddIntParam(DB_COL_IDMARCA, vehiculo.IdMarca);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_VEHICULO_PR" };

            var c = (Vehiculo)entity;
            operation.AddVarcharParam(DB_COL_ID_VEHICULO_PLACA, c.IdVehiculoPlaca);
            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_VEHICULO_PR" };
            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_VEHICULO_PR" };

            var c = (Vehiculo)entity;
            operation.AddVarcharParam(DB_COL_ID_VEHICULO_PLACA, c.IdVehiculoPlaca);

            return operation;
        }

        public SqlOperation GetRetriveStatementOrganization(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_VEHICULO_BY_ORGANIZACION_PR" };

            var c = (Vehiculo)entity;
            operation.AddVarcharParam(DB_COL_ID_ORGANIZACION, c.IdOrganizacion);

            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_VEHICULO_PR" };

            var vehiculo = (Vehiculo)entity;
            operation.AddNvarcharParam(DB_COL_ID_VEHICULO_PLACA, vehiculo.IdVehiculoPlaca);
            operation.AddIntParam(DB_COL_CANTIDAD_PASAJERO, vehiculo.CantidadPasajero);
            operation.AddNvarcharParam(DB_COL_TIPO_COMBUSTIBLE, vehiculo.TipoCombustible);
            operation.AddNvarcharParam(DB_COL_TIPO_VEHICULO, vehiculo.TipoVehiculo);
            operation.AddIntParam(DB_COL_ANNO_FABRICACION, vehiculo.AnnoFabricacion);
            operation.AddDoubleParam(DB_COL_COSTO_RESERVA_HORA, vehiculo.CostoReservaHora);
            operation.AddDoubleParam(DB_COL_PENALIZACION_ESTADO_VEHICULAR, vehiculo.PenalizacionEstadoVehicular);
            operation.AddDoubleParam(DB_COL_KILOMETRAJE_MAXIMO, vehiculo.KilometrajeMaximo);
            operation.AddDoubleParam(DB_COL_COSTO_KILOMETRAJE_EXCEDIDO, vehiculo.CostoKilometrajeExcedido);
            operation.AddDoubleParam(DB_COL_COSTO_SEGURO, vehiculo.CostoSeguro);
            operation.AddNvarcharParam(DB_COL_TIPO_RESERVA, vehiculo.TipoReserva);
            operation.AddNvarcharParam(DB_COL_LONGITUD, vehiculo.Longitud);
            operation.AddNvarcharParam(DB_COL_LATITUD, vehiculo.Latitud);
            operation.AddDoubleParam(DB_COL_COSTO_HORA_ADICIONAL, vehiculo.CostoHoraAdicional);
            operation.AddIntParam(DB_COL_CANTIDAD_PUERTA, vehiculo.CantidadPuerta);
            operation.AddNvarcharParam(DB_COL_ID_ORGANIZACION, vehiculo.IdOrganizacion);
            operation.AddIntParam(DB_COL_ID_MODELO, vehiculo.IdModelo);
            operation.AddIntParam(DB_COL_IDMARCA, vehiculo.IdMarca);

            return operation;
        }
    }
}
