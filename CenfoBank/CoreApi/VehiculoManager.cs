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
    public class VehiculoManager : BaseManager
    {
        private VehiculoCrudFactory crudVehiculo;

        public VehiculoManager()
        {
            crudVehiculo = new VehiculoCrudFactory();
        }

        public void Create(Vehiculo v)
        {
            try
            {
                var c = crudVehiculo.Retrieve<Vehiculo>(v);
                if (c == null)
                {
                    crudVehiculo.Create(v);
                }
                else
                {
                    //Customer already exist
                    throw new BussinessException(3);}
                }
            catch (Exception ex)
            {
            }
        }


        public List<Vehiculo> RetrieveAll()
        {
            try
            {
                return crudVehiculo.RetrieveAll<Vehiculo>();
            }
            catch
            {
                throw new BussinessException();
            }
        }

        public Vehiculo RetrieveById(Vehiculo v)
        {
            Vehiculo c = null;
            try
            {
                c = crudVehiculo.Retrieve<Vehiculo>(v);
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


        public void Update(Vehiculo v)
        {
            try
            {
                var c = crudVehiculo.Retrieve<Vehiculo>(v);

                if (c != null)
                {
                    crudVehiculo.Update(v);

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

        public void Delete(Vehiculo v)
        {
            try
            {
                var c = crudVehiculo.Retrieve<Vehiculo>(v);

                if (c != null)
                {
                    crudVehiculo.Delete(v);

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
