using CoreApi;
using Entities_POJOS;
using Exceptions;
using System;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/Historico_Contrasenna")]
    public class Historico_ContrasennaController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        public IHttpActionResult Get()
        {
            apiResp = new ApiResponse();
            var mng = new Historico_ContrasennaManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        [HttpGet]
        [Route("{idHistoricoCont}")]
        public IHttpActionResult Get(int idHistoricoCont)
        {
            try
            {
                var mng = new Historico_ContrasennaManager();
                var historicoCont = new Historico_Contrasenna
                {
                    IdContrasenna = idHistoricoCont
                };

                historicoCont = mng.RetrieveById(historicoCont);
                apiResp = new ApiResponse();
                apiResp.Data = historicoCont;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        public IHttpActionResult Post(Historico_Contrasenna historicoCont)
        {
            try
            {
                var mng = new Historico_ContrasennaManager();
                mng.Create(historicoCont);

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
        public IHttpActionResult Put(Historico_Contrasenna historicoCont)
        {
            try
            {
                var mng = new Historico_ContrasennaManager();
                mng.Update(historicoCont);

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
        [Route("{idHistoricoCont}")]
        public IHttpActionResult Delete(int idHistoricoCont)
        {
            try
            {
                var historicoCont = new Historico_Contrasenna();
                var mng = new Historico_ContrasennaManager();
                historicoCont.IdContrasenna = idHistoricoCont;
                historicoCont = mng.RetrieveById(historicoCont);
                mng.Delete(historicoCont);

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