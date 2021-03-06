using DataAccess.Dao;
using DataAccess.Mapper;
using Entities_POJOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Crud
{
    public class VehiculoCrudFactory : CrudFactory
    {
        VehiculoMapper mapper;

        public VehiculoCrudFactory() : base()
        {
            mapper = new VehiculoMapper();
            dao = SqlDao.GetInstance();
        }
        public override void Create(BaseEntity entity)
        {
            var vehiculo = (Vehiculo)entity;
            var sqlOperation = mapper.GetCreateStatement(vehiculo);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseEntity entity)
        {
            var vehiculo = (Vehiculo)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(vehiculo));
        }

        public override T Retrieve<T>(BaseEntity entity)
        {
            var sqlOperation = mapper.GetRetriveStatement(entity);
            var lstResult = dao.ExecuteQueryProcedure(sqlOperation);
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }

            return default(T);
        }

        public override List<T> RetrieveAll<T>()
        {
            var list = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    list.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return list;
        }

        public override void Update(BaseEntity entity)
        {
            var vehiculo = (Vehiculo)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(vehiculo));
        }
    }
}
