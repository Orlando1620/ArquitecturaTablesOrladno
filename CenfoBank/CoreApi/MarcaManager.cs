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
    public class MarcaManager : BaseManager
    {
        private MarcaCrudFactory crudMarca;

        public MarcaManager()
        {
            crudMarca = new MarcaCrudFactory();
        }

        public void Create(Marca m)
        {
            try
            {
                var c = crudMarca.Retrieve<Vehiculo>(m);
                if (c == null)
                {
                    crudMarca.Create(m);
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


        public List<Marca> RetrieveAll()
        {
            try
            {
                return crudMarca.RetrieveAll<Marca>();
            }
            catch
            {
                throw new BussinessException();
            }
        }

        public Marca RetrieveById(Marca m)
        {
            Marca c = null;
            try
            {
                c = crudMarca.Retrieve<Marca>(m);
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


        public void Update(Marca m)
        {
            try
            {
                var c = crudMarca.Retrieve<Marca>(m);

                if (c != null)
                {
                    crudMarca.Update(m);

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

        public void Delete(Marca m)
        {
            try
            {
                var c = crudMarca.Retrieve<Marca>(m);

                if (c != null)
                {
                    crudMarca.Delete(m);

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
