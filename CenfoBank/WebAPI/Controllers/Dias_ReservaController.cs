using CoreApi;
using Entities_POJOS;
using Exceptions;
using System;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/Dias_Reserva")]
    public class Dias_ReservaController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        public IHttpActionResult Get()
        {
            apiResp = new ApiResponse();
            var mng = new Dias_ReservaManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        [HttpGet]
        [Route("{idDiaReserva}")]
        public IHttpActionResult Get(int idDiaReserva)
        {
            try
            {
                var mng = new Dias_ReservaManager();
                var diaReserva = new Dias_Reserva
                {
                    IdDiaReserva = idDiaReserva
                };

                diaReserva = mng.RetrieveById(diaReserva);
                apiResp = new ApiResponse();
                apiResp.Data = diaReserva;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        public IHttpActionResult Post(Dias_Reserva diaReserva)
        {
            try
            {
                var mng = new Dias_ReservaManager();
                mng.Create(diaReserva);

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
        public IHttpActionResult Put(Dias_Reserva diaReserva)
        {
            try
            {
                var mng = new Dias_ReservaManager();
                mng.Update(diaReserva);

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
        [Route("{idDiaReserva}")]
        public IHttpActionResult Delete(int idDiaReserva)
        {
            try
            {
                var diaReserva = new Dias_Reserva();
                var mng = new Dias_ReservaManager();
                diaReserva.IdDiaReserva = idDiaReserva;
                diaReserva = mng.RetrieveById(diaReserva);
                mng.Delete(diaReserva);

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