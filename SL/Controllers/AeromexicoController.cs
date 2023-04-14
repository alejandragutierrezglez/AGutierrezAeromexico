using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;

namespace SL.Controllers
{
    public class AeromexicoController : ApiController
    {
        // GET: Aeromexico


        [HttpPost]
        [Route("api/Aeromexico/Pasajero/Login/{username}/{password}")]
        public IHttpActionResult Login(string username, string password)
        {
            ML.Result result = BL.Usuario.UsuarioGetByUsername(username, password);
            if (result.Correct)
            {
                ML.Usuario usuario = (ML.Usuario)result.Object;

                if (username == usuario.Username && password == usuario.Password)
                {
                    result.Autoriced = "AUTHORIZED";
                    return Ok(result.Autoriced);
                }
                else
                {
                    return NotFound();
                }
            }
            result.Autoriced = "NO AUTHORIZED";
            return Ok(result.Autoriced);
        }


        [HttpPost]
        [Route("api/Aeromexico/Pasajero/Add")]
        public IHttpActionResult Add([FromBody] ML.Pasajero pasajero)
        {
            ML.Result result = BL.Pasajero.AddEF(pasajero);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpGet]
        [Route("api/Aeromexico/GetAll/{fechaInicio}/{fechaFin}")]
        public IHttpActionResult GetAll(DateTime fechaInicio, DateTime fechaFin)
        {
            ML.Vuelo vuelo = new ML.Vuelo();           

            ML.Result result = BL.Vuelo.GetAllByFechas(fechaInicio, fechaFin);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("api/Aeromexico/ReservacionVuelo/GetAll/Vuelo")]
        public IHttpActionResult VueloGetAll()
        {
            ML.Vuelo vuelo = new ML.Vuelo();

            ML.Result result = BL.Vuelo.GetAll();
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpGet]
        [Route("api/Aeromexico/ReservacionVuelo/GetAll/VuelosPasajeros")]
        public IHttpActionResult VuelosPasajerosGetAll()
        {
            ML.Pasajero pasajero = new ML.Pasajero();

            ML.Result result = BL.Pasajero.VueloPasajeroGetAll();
            if (result.Correct)
            {
                return Ok(result);

            }
            else
            {
                return NotFound();
            }
        }


       
        [HttpPost]
        [Route("api/Aeromexico/ReservacionVuelo/{idPasajero}/{idVuelo}")]
        public IHttpActionResult ReservacionVuelo(int idPasajero, int idVuelo)
        {

            ML.Pasajero pasajero = new ML.Pasajero();

            ML.Result result = BL.Reservacion.ReservacionAdd(idPasajero, idVuelo);
          
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return InternalServerError();
            }
        }

    }

}