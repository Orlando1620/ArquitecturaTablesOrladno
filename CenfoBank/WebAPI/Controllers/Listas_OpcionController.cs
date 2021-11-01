using System;
using CoreApi;
using Entities_POJOS;
using Exceptions;
using System;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/Listas_Opcion")]
    public class Listas_OpcionController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        public IHttpActionResult Get()
        {
            apiResp = new ApiResponse();
            var mng = new Listas_OpcionManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(string id)
        {
            try
            {
                var mng = new Listas_OpcionManager();
                var listOpc = new Listas_Opcion
                {
                    IdListaOpcion = id
                };

                listOpc = mng.RetrieveById(listOpc);
                apiResp = new ApiResponse();
                apiResp.Data = listOpc;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        public IHttpActionResult Post(Listas_Opcion listOpc)
        {
            try
            {
                var mng = new Listas_OpcionManager();
                mng.Create(listOpc);

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
        public IHttpActionResult Put(Listas_Opcion listOpc)
        {
            try
            {
                var mng = new Listas_OpcionManager();
                mng.Update(listOpc);

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
        [Route("{id}")]
        public IHttpActionResult Delete(string id)
        {
            try
            {
                var listOpc = new Listas_Opcion();
                var mng = new Listas_OpcionManager();
                listOpc.IdListaOpcion = id;
                listOpc = mng.RetrieveById(listOpc);
                mng.Delete(listOpc);

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