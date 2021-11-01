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
    public class Dias_ReservaManager : BaseManager
    {
        private Dias_ReservaCrudFactory crudDiaReserva;

        public Dias_ReservaManager()
        {
            crudDiaReserva = new Dias_ReservaCrudFactory();
        }

        public void Create(Dias_Reserva dr)
        {
            try
            {
                var c = crudDiaReserva.Retrieve<Vehiculo>(dr);
                if (c == null)
                {
                    crudDiaReserva.Create(dr);
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


        public List<Dias_Reserva> RetrieveAll()
        {
            try
            {
                return crudDiaReserva.RetrieveAll<Dias_Reserva>();
            }
            catch
            {
                throw new BussinessException();
            }
        }

        public Dias_Reserva RetrieveById(Dias_Reserva dr)
        {
            Dias_Reserva c = null;
            try
            {
                c = crudDiaReserva.Retrieve<Dias_Reserva>(dr);
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


        public void Update(Dias_Reserva dr)
        {
            try
            {
                var c = crudDiaReserva.Retrieve<Dias_Reserva>(dr);

                if (c != null)
                {
                    crudDiaReserva.Update(dr);

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

        public void Delete(Dias_Reserva dr)
        {
            try
            {
                var c = crudDiaReserva.Retrieve<Dias_Reserva>(dr);

                if (c != null)
                {
                    crudDiaReserva.Delete(dr);

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
