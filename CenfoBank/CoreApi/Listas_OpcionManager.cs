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
    public class Listas_OpcionManager : BaseManager
    {

        private Listas_OpcionCrudFactory crudListas_Opcion;

        public Listas_OpcionManager()
        {
            crudListas_Opcion = new Listas_OpcionCrudFactory();
        }

        public void Create(Listas_Opcion lo)
        {
            try
            {
                var c = crudListas_Opcion.Retrieve<Vehiculo>(lo);
                if (c == null)
                {
                    crudListas_Opcion.Create(lo);
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


        public List<Listas_Opcion> RetrieveAll()
        {
            try
            {
                return crudListas_Opcion.RetrieveAll<Listas_Opcion>();
            }
            catch
            {
                throw new BussinessException();
            }
        }

        public Listas_Opcion RetrieveById(Listas_Opcion lo)
        {
            Listas_Opcion c = null;
            try
            {
                c = crudListas_Opcion.Retrieve<Listas_Opcion>(lo);
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


        public void Update(Listas_Opcion lo)
        {
            try
            {
                var c = crudListas_Opcion.Retrieve<Listas_Opcion>(lo);

                if (c != null)
                {
                    crudListas_Opcion.Update(lo);

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

        public void Delete(Listas_Opcion lo)
        {
            try
            {
                var c = crudListas_Opcion.Retrieve<Listas_Opcion>(lo);

                if (c != null)
                {
                    crudListas_Opcion.Delete(lo);

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
