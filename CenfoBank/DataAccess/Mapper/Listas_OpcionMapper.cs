using DataAccess.Dao;
using Entities_POJOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class Listas_OpcionMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID_LISTA_OPCIONES = "ID_LISTA_OPCIONES";
        private const string DB_COL_VALOR = "VALOR";
        private const string DB_COL_DESCRIPCION = "DESCRIPCION";

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var listOpc = new Listas_Opcion
            {
                IdListaOpcion = GetStringValue(row, DB_COL_ID_LISTA_OPCIONES),
                Valor = GetStringValue(row, DB_COL_VALOR),
                Descripcion = GetStringValue(row, DB_COL_DESCRIPCION),
            };
            return listOpc;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var listasOpc = BuildObject(row);
                lstResults.Add(listasOpc);
            }

            return lstResults;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_LISTAS_OPCIONES_PR" };
            var c = (Listas_Opcion)entity;
            operation.AddNvarcharParam(DB_COL_ID_LISTA_OPCIONES, c.IdListaOpcion);
            operation.AddNvarcharParam(DB_COL_VALOR, c.Valor);
            operation.AddNvarcharParam(DB_COL_DESCRIPCION, c.Descripcion);
            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_LISTAS_OPCIONES_PR" };

            var c = (Listas_Opcion)entity;
            operation.AddNvarcharParam(DB_COL_ID_LISTA_OPCIONES, c.IdListaOpcion);
            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_LISTAS_OPCIONES_PR" };
            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_LISTAS_OPCIONES_PR" };

            var c = (Listas_Opcion)entity;
            operation.AddNvarcharParam(DB_COL_ID_LISTA_OPCIONES, c.IdListaOpcion);
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_LISTAS_OPCIONES_PR" };
            var c = (Listas_Opcion)entity;
            operation.AddNvarcharParam(DB_COL_ID_LISTA_OPCIONES, c.IdListaOpcion);
            operation.AddNvarcharParam(DB_COL_VALOR, c.Valor);
            operation.AddNvarcharParam(DB_COL_DESCRIPCION, c.Descripcion);
            return operation;
        }
    }
}
