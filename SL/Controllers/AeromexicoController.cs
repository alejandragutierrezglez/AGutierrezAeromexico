using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;



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
        [Route("api/Aeromexico/GetAll/Vuelo")]
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
        [Route("api/Aeromexico/GetAll/Pasajero")]
        public IHttpActionResult PasajeroGetAll()
        {
            ML.Pasajero pasajero = new ML.Pasajero();

            ML.Result result = BL.Pasajero.GetAll();
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }


    }

}