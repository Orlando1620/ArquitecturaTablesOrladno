using DataAccess.Crud;
using Entities_POJOS;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApi
{
    public class RolManager : BaseManager
    {
        private RolCrudFactory crudRol;

        public RolManager()
        {
            crudRol = new RolCrudFactory();
        }

        public void Create(Rol r)
        {
            try
            {
                var c = crudRol.Retrieve<Vehiculo>(r);
                if (c == null)
                {
                    crudRol.Create(r);
                }
                else
                {
                    //Customer already exist
                    throw new BussinessException(3);
                }
            }
            catch (Exception ex)
            {
            }
        }


        public List<Rol> RetrieveAll()
        {
            try
            {
                return crudRol.RetrieveAll<Rol>();
            }
            catch
            {
                throw new BussinessException();
            }
        }

        public Rol RetrieveById(Rol r)
        {
            Rol c = null;
            try
            {
                c = crudRol.Retrieve<Rol>(r);
                if (c == null)
                {
                    throw new BussinessException(4);
                }
                return c;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
            return c;
        }


        public void Update(Rol r)
        {
            try
            {
                var c = crudRol.Retrieve<Rol>(r);

                if (c != null)
                {
                    crudRol.Update(r);

                }
                else
                {
                    throw new BussinessException(3);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public void Delete(Rol r)
        {
            try
            {
                var c = crudRol.Retrieve<Rol>(r);

                if (c != null)
                {
                    crudRol.Delete(r);

                }
                else
                {
                    throw new BussinessException(5);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }
    }
}
