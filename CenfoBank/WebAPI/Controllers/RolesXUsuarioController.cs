using CoreApi;
using Entities_POJOS;
using Exceptions;
using System;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/RolesXUsuario")]
    public class RolesXUsuarioController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        public IHttpActionResult Get()
        {
            apiResp = new ApiResponse();
            var clMng = new RolesXUsuarioManager();
            apiResp.Data = clMng.RetrieveAll();

            return Ok(apiResp);
        }

        [HttpGet]
        [Route("{IdUsuario/idRol}")]
        public IHttpActionResult Get(string ids)
        {
            try
            {
                var infoArray = ids.Split('/');
                var mng = new RolesXUsuarioManager();
                var rolUsu = new RolesXUsuario
                {
                    IdUsuario = infoArray[0],
                    IdRol = Convert.ToInt32(infoArray[1]),
                };

                rolUsu = mng.RetrieveById(rolUsu);
                apiResp = new ApiResponse();
                apiResp.Data = rolUsu;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        public IHttpActionResult Post(RolesXUsuario rolUsu)
        {
            try
            {
                var mng = new RolesXUsuarioManager();
                mng.Create(rolUsu);

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-"
                    + bex.AppMessage.Message));
            }
        }

        [HttpPut]
        public IHttpActionResult Put(RolesXUsuario rolUsu)
        {
            try
            {
                var mng = new RolesXUsuarioManager();
                mng.Update(rolUsu);

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        [HttpDelete]
        [Route("{idRol/IdUsuario}")]
        public IHttpActionResult Delete(string data)
        {
            try
            {
                var infoArray = data.Split('/');
                var rolUsu = new RolesXUsuario();
                var mng = new RolesXUsuarioManager();
                rolUsu.IdUsuario = infoArray[0];
                rolUsu.IdRol = Convert.ToInt32(infoArray[1]);
                rolUsu = mng.RetrieveById(rolUsu);
                mng.Delete(rolUsu);

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
    }
}