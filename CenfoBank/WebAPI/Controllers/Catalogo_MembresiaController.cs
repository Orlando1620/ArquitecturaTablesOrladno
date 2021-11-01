using CoreApi;
using Entities_POJOS;
using Exceptions;
using System;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ExceptionFilter]
    [RoutePrefix("api/Catalogo_Membresia")]
    public class Catalogo_MembresiaController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        public IHttpActionResult Get()
        {
            apiResp = new ApiResponse();
            var mng = new Catalogo_MembresiaManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        [HttpGet]
        [Route("{idCatalogo}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var mng = new Catalogo_MembresiaManager();
                var catalogoMem = new Catalogo_Membresia
                {
                    IdCatalogoMembresia = id
                };

                catalogoMem = mng.RetrieveById(catalogoMem);
                apiResp = new ApiResponse();
                apiResp.Data = catalogoMem;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        public IHttpActionResult Post(Catalogo_Membresia catalogoMem)
        {
            try
            {
                var mng = new Catalogo_MembresiaManager();
                mng.Create(catalogoMem);

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
        public IHttpActionResult Put(Catalogo_Membresia catalogoMem)
        {
            try
            {
                var mng = new Catalogo_MembresiaManager();
                mng.Update(catalogoMem);

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
        [Route("{idCatalogo}")]
        public IHttpActionResult Delete(int idCatalogo)
        {
            try
            {
                var catalogoMem = new Catalogo_Membresia();
                var mng = new Catalogo_MembresiaManager();
                catalogoMem.IdCatalogoMembresia = idCatalogo;
                catalogoMem = mng.RetrieveById(catalogoMem);
                mng.Delete(catalogoMem);

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