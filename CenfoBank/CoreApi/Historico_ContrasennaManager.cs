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
    public class Historico_ContrasennaManager
    {
        private Historico_ContrasennaCrudFactory crudHistorico_Contrasenna;

        public Historico_ContrasennaManager()
        {
            crudHistorico_Contrasenna = new Historico_ContrasennaCrudFactory();
        }

        public void Create(Historico_Contrasenna hc)
        {
            try
            {
                var c = crudHistorico_Contrasenna.Retrieve<Vehiculo>(hc);
                if (c == null)
                {
                    crudHistorico_Contrasenna.Create(hc);
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


        public List<Historico_Contrasenna> RetrieveAll()
        {
            try
            {
                return crudHistorico_Contrasenna.RetrieveAll<Historico_Contrasenna>();
            }
            catch
            {
                throw new BussinessException();
            }
        }

        public Historico_Contrasenna RetrieveById(Historico_Contrasenna hc)
        {
            Historico_Contrasenna c = null;
            try
            {
                c = crudHistorico_Contrasenna.Retrieve<Historico_Contrasenna>(hc);
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


        public void Update(Historico_Contrasenna hc)
        {
            try
            {
                var c = crudHistorico_Contrasenna.Retrieve<Historico_Contrasenna>(hc);

                if (c != null)
                {
                    crudHistorico_Contrasenna.Update(hc);

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

        public void Delete(Historico_Contrasenna hc)
        {
            try
            {
                var c = crudHistorico_Contrasenna.Retrieve<Historico_Contrasenna>(hc);

                if (c != null)
                {
                    crudHistorico_Contrasenna.Delete(hc);

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
