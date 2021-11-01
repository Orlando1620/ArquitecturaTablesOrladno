using DataAccess.Dao;
using Entities_POJOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class RolesXUsuarioMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID_USUARIO = "ID_USUARIO";
        private const string DB_COL_ID_ROL = "ID_ROL";

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var rolUsuario = new RolesXUsuario
            {
                IdUsuario = GetStringValue(row, DB_COL_ID_USUARIO),
                IdRol = GetIntValue(row, DB_COL_ID_ROL),
            };
            return rolUsuario;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var rolesUsuario = BuildObject(row);
                lstResults.Add(rolesUsuario);
            }

            return lstResults;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_ROLESxUSUARIOS_PR" };
            var rolUsuario = (RolesXUsuario)entity;
            operation.AddNvarcharParam(DB_COL_ID_USUARIO, rolUsuario.IdUsuario);
            operation.AddIntParam(DB_COL_ID_ROL, rolUsuario.IdRol);
            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_ROLESxUSUARIOS_PR" };

            var c = (RolesXUsuario)entity;
            operation.AddNvarcharParam(DB_COL_ID_USUARIO, c.IdUsuario);
            operation.AddIntParam(DB_COL_ID_ROL, c.IdRol);
            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_ROLESxUSUARIOS_PR" };
            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ROLESxUSUARIOS_PR" };

            var c = (RolesXUsuario)entity;
            operation.AddNvarcharParam(DB_COL_ID_USUARIO, c.IdUsuario);
            operation.AddIntParam(DB_COL_ID_ROL, c.IdRol);
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_ROLESxUSUARIOS_PR" };
            var c = (RolesXUsuario)entity;
            operation.AddNvarcharParam(DB_COL_ID_USUARIO, c.IdUsuario);
            operation.AddIntParam(DB_COL_ID_ROL, c.IdRol);
            return operation;
        }
    }
}
