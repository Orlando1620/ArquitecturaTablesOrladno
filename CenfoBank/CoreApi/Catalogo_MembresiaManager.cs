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
    public class Catalogo_MembresiaManager : BaseManager
    {
        private Catalogo_MembresiaCrudFactory crudCatalogoMem;

        public Catalogo_MembresiaManager()
        {
            crudCatalogoMem = new Catalogo_MembresiaCrudFactory();
        }

        public void Create(Catalogo_Membresia cm)
        {
            try {
                var c = crudCatalogoMem.Retrieve<Vehiculo>(cm);
                if (c == null)
                {
                    crudCatalogoMem.Create(cm);
                }
                else
                {
                    //Customer already exist
                    throw new BussinessException(3);
                }
            } catch (Exception ex)
            { 

            }
        }


        public List<Catalogo_Membresia> RetrieveAll()
        {
            try
            {
                return crudCatalogoMem.RetrieveAll<Catalogo_Membresia>();
            }
            catch
            {
                throw new BussinessException();
            }
        }

        public Catalogo_Membresia RetrieveById(Catalogo_Membresia cm)
        {
            Catalogo_Membresia c = null;
            try
            {
                c = crudCatalogoMem.Retrieve<Catalogo_Membresia>(cm);
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


        public void Update(Catalogo_Membresia cm)
        {
            try
            {
                var c = crudCatalogoMem.Retrieve<Catalogo_Membresia>(cm);

                if (c != null)
                {
                    crudCatalogoMem.Update(cm);

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

        public void Delete(Catalogo_Membresia cm)
        {
            try
            {
                var c = crudCatalogoMem.Retrieve<Catalogo_Membresia>(cm);

                if (c != null)
                {
                    crudCatalogoMem.Delete(cm);

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
