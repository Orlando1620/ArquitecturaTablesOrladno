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
    public class RolesXUsuarioManager : BaseManager
    {
        private RolesXUsuarioCrudFactory crudRolesXUsuario;

        public RolesXUsuarioManager()
        {
            crudRolesXUsuario = new RolesXUsuarioCrudFactory();
        }

        public void Create(RolesXUsuario rxu)
        {
            try
            {
                var c = crudRolesXUsuario.Retrieve<Vehiculo>(rxu);
                if (c == null)
                {
                    crudRolesXUsuario.Create(rxu);
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


        public List<RolesXUsuario> RetrieveAll()
        {
            try
            {
                return crudRolesXUsuario.RetrieveAll<RolesXUsuario>();
            }
            catch
            {
                throw new BussinessException();
            }
        }

        public RolesXUsuario RetrieveById(RolesXUsuario rxu)
        {
            RolesXUsuario c = null;
            try
            {
                c = crudRolesXUsuario.Retrieve<RolesXUsuario>(rxu);
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


        public void Update(RolesXUsuario rxu)
        {
            try
            {
                var c = crudRolesXUsuario.Retrieve<RolesXUsuario>(rxu);

                if (c != null)
                {
                    crudRolesXUsuario.Update(rxu);

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

        public void Delete(RolesXUsuario rxu)
        {
            try
            {
                var c = crudRolesXUsuario.Retrieve<RolesXUsuario>(rxu);

                if (c != null)
                {
                    crudRolesXUsuario.Delete(rxu);

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
