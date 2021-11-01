using DataAccess.Dao;
using Entities_POJOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class RolMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID_ROL = "ID_ROL";
        private const string DB_COL_NOMBRE = "NOMBRE";
        private const string DB_COL_ESTADO = "ESTADO";


        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var rol = new Rol
            { 
            IdRol = GetIntValue(row, DB_COL_ID_ROL),
            Nombre = GetStringValue(row, DB_COL_NOMBRE),
            Estado = GetStringValue(row, DB_COL_ESTADO),
            };
            return rol;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var rol = BuildObject(row);
                lstResults.Add(rol);
            }

            return lstResults;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_ROLES_PR" };
            var rol = (Rol)entity;
            operation.AddNvarcharParam(DB_COL_NOMBRE, rol.Nombre);
            operation.AddNvarcharParam(DB_COL_ESTADO, rol.Estado);
            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_ROLES_PR" };

            var c = (Rol)entity;
            operation.AddIntParam(DB_COL_ID_ROL, c.IdRol);
            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_ROLES_PR" };
            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ROLES_PR" };

            var c = (Rol)entity;
            operation.AddIntParam(DB_COL_ID_ROL, c.IdRol);
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_ROLES_PR" };
            var rol = (Rol)entity;
            operation.AddNvarcharParam(DB_COL_NOMBRE, rol.Nombre);
            operation.AddNvarcharParam(DB_COL_ESTADO, rol.Estado);
            return operation;
        }
    }
}
