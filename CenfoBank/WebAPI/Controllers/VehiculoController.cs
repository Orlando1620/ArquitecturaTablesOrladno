using CoreApi;
using Entities_POJOS;
using Exceptions;
using System;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/Vehiculo")]
    public class VehiculoController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        public IHttpActionResult Get()
        {
            apiResp = new ApiResponse();
            var mng = new VehiculoManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        [HttpGet]
        [Route("{idVehiculoPlaca}")]
        public IHttpActionResult Get(string placa)
        {
            try
            {
                var mng = new VehiculoManager();
                var vehiculo = new Vehiculo
                {
                    IdVehiculoPlaca = placa
                };

                vehiculo = mng.RetrieveById(vehiculo);
                apiResp = new ApiResponse();
                apiResp.Data = vehiculo;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        public IHttpActionResult Post(Vehiculo vehiculo)
        {
            try
            {
                var mng = new VehiculoManager();
                mng.Create(vehiculo);

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
        public IHttpActionResult Put(Vehiculo vehiculo)
        {
            try
            {
                var mng = new VehiculoManager();
                mng.Update(vehiculo);

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
        [Route("{idVehiculoPlaca}")]
        public IHttpActionResult Delete(String placa)
        {
            try
            {
                var vehiculo = new Vehiculo();
                var mng = new VehiculoManager();
                vehiculo.IdVehiculoPlaca = placa;
                vehiculo = mng.RetrieveById(vehiculo);
                mng.Delete(vehiculo);

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