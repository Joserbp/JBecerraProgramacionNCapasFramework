using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL_WebApi.Controllers
{
    public class AlumnoController : ApiController
    {
        // POST GET PUT DELETE PATCH//

        // GET --- Obtener recursos
        // POST --- Enviar recurso
        // DELETE --- Eliminar

        // PUT --- Reemplazar  //Actualizar

        // PATCH ---Actualiza  //Crea / Actualiza
        [Route("api/Alumno/GetAll")]  
        [HttpGet]  ///Codigos de error HTTP 
        public IHttpActionResult GetAll()
        {
            ML.Result result = BL.Alumno.GetAllEF();
            if(result.Correct)
            {
                return Content(HttpStatusCode.OK, result); 
            }
            else
            {
                return Content(HttpStatusCode.NotFound,result);
            }
        }
        [Route("api/Alumno/Add")]
        [HttpPost]  ///Codigos de error HTTP 
        public IHttpActionResult Add([FromBody]ML.Alumno alumno)
        {
            ML.Result result = BL.Alumno.AddLINQ(alumno);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }

    }
}
