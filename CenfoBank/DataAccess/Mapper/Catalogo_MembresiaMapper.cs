using DataAccess.Dao;
using Entities_POJOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class Catalogo_MembresiaMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID_CATALOGO_MEMBRESIA = "ID_CATALOGO_MEMBRESIA ";
        private const string DB_COL_NOMBRE = "NOMBRE";
        private const string DB_COL_MONTO_MENSUAL = "MONTO_MENSUAL";
        private const string DB_COL_COMISION = "COMISION";
        private const string DB_COL_VIGENCIA = "VIGENCIA";
        private const string DB_COL_ESTADO = "ESTADO";


        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var catalogoMembresia = new Catalogo_Membresia
            {
                IdCatalogoMembresia = GetIntValue(row, DB_COL_ID_CATALOGO_MEMBRESIA),
                Nombre = GetStringValue(row, DB_COL_NOMBRE),
                MontoMensual = GetDoubleValue(row, DB_COL_MONTO_MENSUAL),
                Comision = GetDoubleValue(row, DB_COL_COMISION),
                Vigencia = GetDateValue(row, DB_COL_VIGENCIA),
                Estado = GetStringValue(row, DB_COL_ESTADO),
            };
            return catalogoMembresia;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var catalogoMembresia = BuildObject(row);
                lstResults.Add(catalogoMembresia);
            }

            return lstResults;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_CATALOGOS_MEMBRESIAS_PR" };
            var catalogoMembresia = (Catalogo_Membresia)entity;
            operation.AddNvarcharParam(DB_COL_NOMBRE, catalogoMembresia.Nombre);
            operation.AddDoubleParam(DB_COL_MONTO_MENSUAL, catalogoMembresia.MontoMensual);
            operation.AddDoubleParam(DB_COL_COMISION, catalogoMembresia.Comision);
            operation.AddDateTimeParam(DB_COL_VIGENCIA, catalogoMembresia.Vigencia);
            operation.AddNvarcharParam(DB_COL_ESTADO, catalogoMembresia.Estado);
            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_CATALOGOS_MEMBRESIAS_PR" };

            var c = (Catalogo_Membresia)entity;
            operation.AddIntParam(DB_COL_ID_CATALOGO_MEMBRESIA, c.IdCatalogoMembresia);
            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_CATALOGOS_MEMBRESIAS_PR" };
            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_CATALOGOS_MEMBRESIAS_PR" };

            var c = (Catalogo_Membresia)entity;
            operation.AddIntParam(DB_COL_ID_CATALOGO_MEMBRESIA, c.IdCatalogoMembresia);

            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_CATALOGOS_MEMBRESIAS_PR" };
            var catalogoMembresia = (Catalogo_Membresia)entity;
            operation.AddNvarcharParam(DB_COL_NOMBRE, catalogoMembresia.Nombre);
            operation.AddDoubleParam(DB_COL_MONTO_MENSUAL, catalogoMembresia.MontoMensual);
            operation.AddDoubleParam(DB_COL_COMISION, catalogoMembresia.Comision);
            operation.AddDateTimeParam(DB_COL_VIGENCIA, catalogoMembresia.Vigencia);
            operation.AddNvarcharParam(DB_COL_ESTADO, catalogoMembresia.Estado);
            return operation;
        }
    }
}
