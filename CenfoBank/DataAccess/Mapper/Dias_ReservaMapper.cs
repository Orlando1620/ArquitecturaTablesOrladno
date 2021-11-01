using DataAccess.Dao;
using Entities_POJOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class Dias_ReservaMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID_DIA_RESERVA = "ID_DIA_RESERVA";
        private const string DB_COL_FECHA_RESERVA = "FECHA_RESERVA";
        private const string DB_COL_ESTADO = "ESTADO";
        private const string DB_COL_ID_VEHICULO_PLACA = "ID_VEHICULO_PLACA";

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var diaReserva = new Dias_Reserva
            {
                IdDiaReserva = GetIntValue(row, DB_COL_ID_DIA_RESERVA),
                FechaReserva = GetDateValue(row, DB_COL_FECHA_RESERVA),
                Estado = GetStringValue(row, DB_COL_ESTADO),
                IdVehiculoPlaca = GetStringValue(row, DB_COL_ID_VEHICULO_PLACA),
            };
            return diaReserva;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var diasReserva = BuildObject(row);
                lstResults.Add(diasReserva);
            }

            return lstResults;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_DIAS_RESERVAS_PR" };
            var diasReserva = (Dias_Reserva)entity;
            operation.AddDateTimeParam(DB_COL_FECHA_RESERVA, diasReserva.FechaReserva);
            operation.AddNvarcharParam(DB_COL_ESTADO, diasReserva.Estado);
            operation.AddNvarcharParam(DB_COL_ID_VEHICULO_PLACA, diasReserva.IdVehiculoPlaca);
            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_DIAS_RESERVAS_PR" };

            var c = (Dias_Reserva)entity;
            operation.AddIntParam(DB_COL_ID_DIA_RESERVA, c.IdDiaReserva);
            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_DIAS_RESERVAS_PR" };
            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_DIAS_RESERVAS_PR" };

            var c = (Dias_Reserva)entity;
            operation.AddIntParam(DB_COL_ID_DIA_RESERVA, c.IdDiaReserva);

            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_DIAS_RESERVAS_PR" };
            var diasReserva = (Dias_Reserva)entity;
            operation.AddDateTimeParam(DB_COL_FECHA_RESERVA, diasReserva.FechaReserva);
            operation.AddNvarcharParam(DB_COL_ESTADO, diasReserva.Estado);
            operation.AddNvarcharParam(DB_COL_ID_VEHICULO_PLACA, diasReserva.IdVehiculoPlaca);
            return operation;
        }
    }
}
