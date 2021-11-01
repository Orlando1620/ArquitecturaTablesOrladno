using DataAccess.Dao;
using Entities_POJOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class Historico_ContrasennaMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID_CONTRASENNA = "ID_CONTRASENNA";
        private const string DB_COL_CONTRASENNAS = "CONTRASENNA";
        private const string DB_COL_ESTADO = "ESTADO";
        private const string DB_COL_ID_USUARIO = "ID_USUARIO";

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var historicoContrasenna = new Historico_Contrasenna
            {
                IdContrasenna = GetIntValue(row, DB_COL_ID_CONTRASENNA),
                Contrasennas = GetStringValue(row, DB_COL_CONTRASENNAS),
                Estado = GetStringValue(row, DB_COL_ESTADO),
                IdUsuario = GetStringValue(row, DB_COL_ID_USUARIO),
            };
            return historicoContrasenna;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var historicoContrasenna = BuildObject(row);
                lstResults.Add(historicoContrasenna);
            }

            return lstResults;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_HISTORICOS_CONTRASENNAS_PR" };
            var historicoContrasenna = (Historico_Contrasenna)entity;
            operation.AddNvarcharParam(DB_COL_CONTRASENNAS, historicoContrasenna.Contrasennas);
            operation.AddNvarcharParam(DB_COL_ESTADO, historicoContrasenna.Estado);
            operation.AddNvarcharParam(DB_COL_ID_USUARIO, historicoContrasenna.IdUsuario);
            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_HISTORICOS_CONTRASENNAS_PR" };

            var c = (Historico_Contrasenna)entity;
            operation.AddIntParam(DB_COL_ID_CONTRASENNA, c.IdContrasenna);
            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_HISTORICOS_CONTRASENNAS_PR" };
            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_HISTORICOS_CONTRASENNAS_PR" };

            var c = (Historico_Contrasenna)entity;
            operation.AddIntParam(DB_COL_ID_CONTRASENNA, c.IdContrasenna);
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_HISTORICOS_CONTRASENNAS_PR" };
            var historicoContrasenna = (Historico_Contrasenna)entity;
            operation.AddNvarcharParam(DB_COL_CONTRASENNAS, historicoContrasenna.Contrasennas);
            operation.AddNvarcharParam(DB_COL_ESTADO, historicoContrasenna.Estado);
            operation.AddNvarcharParam(DB_COL_ID_USUARIO, historicoContrasenna.IdUsuario);
            return operation;
        }
    }
}
