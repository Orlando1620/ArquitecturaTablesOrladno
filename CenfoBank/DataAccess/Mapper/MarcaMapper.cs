using DataAccess.Dao;
using Entities_POJOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class MarcaMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID_MARCA = "ID_MARCA";
        private const string DB_COL_NOMBRE = "NOMBRE";

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var marca = new Marca
            { 
            IdMarca = GetIntValue(row, DB_COL_ID_MARCA),
            Nombre = GetStringValue(row, DB_COL_NOMBRE),
            };
            return marca;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var marca = BuildObject(row);
                lstResults.Add(marca);
            }

            return lstResults;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_MARCAS_PR" };
            var marca = (Marca)entity;
            operation.AddNvarcharParam(DB_COL_NOMBRE, marca.Nombre);
            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_MARCAS_PR" };

            var c = (Marca)entity;
            operation.AddIntParam(DB_COL_ID_MARCA, c.IdMarca);
            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_MARCAS_PR" };
            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_MARCAS_PR" };

            var c = (Marca)entity;
            operation.AddIntParam(DB_COL_ID_MARCA, c.IdMarca);

            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_MARCAS_PR" };
            var marca = (Marca)entity;
            operation.AddNvarcharParam(DB_COL_NOMBRE, marca.Nombre);
            return operation;
        }
    }
}
