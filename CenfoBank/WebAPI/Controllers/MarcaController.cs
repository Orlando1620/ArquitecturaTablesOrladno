using CoreApi;
using Entities_POJOS;
using Exceptions;
using System;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/Marca")]
    public class MarcaController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        public IHttpActionResult Get()
        {
            apiResp = new ApiResponse();
            var mng = new MarcaManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        [HttpGet]
        [Route("{idMarca}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var mng = new MarcaManager();
                var marca = new Marca
                {
                    IdMarca = id
                };

                marca = mng.RetrieveById(marca);
                apiResp = new ApiResponse();
                apiResp.Data = marca;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        public IHttpActionResult Post(Marca marca)
        {
            try
            {
                var mng = new MarcaManager();
                mng.Create(marca);

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
        public IHttpActionResult Put(Marca marca)
        {
            try
            {
                var mng = new MarcaManager();
                mng.Update(marca);

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
        [Route("{idMarca}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var marca = new Marca();
                var mng = new MarcaManager();
                marca.IdMarca = id;
                marca = mng.RetrieveById(marca);
                mng.Delete(marca);

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