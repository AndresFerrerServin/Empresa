using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL.Controllers
{
    public class EmpleadoController : ApiController
    {
        [HttpGet]
        [Route("api/empleado/GetAll")]
        public IHttpActionResult GetAll()
        {
            ML.Result result = BL.Empleado.GetAll();

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }
        [HttpPost]
        [Route("api/empleado/add")]
        public IHttpActionResult Add([FromBody] ML.Empleado empleado)
        {
            ML.Result result = BL.Empleado.Add(empleado);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        [HttpPut]
        [Route("api/empleado/update/{Id_NumEmp}")]
        public IHttpActionResult Put(int Id_NumEmp, [FromBody] ML.Empleado empleado)
        {
            empleado.Id_NumEmp = Id_NumEmp;
            ML.Result result = BL.Empleado.Update(empleado);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        [HttpDelete]
        [Route("api/empleado/delete/{Id_NumEmp}")]

        public IHttpActionResult Delete(int Id_NumEmp)
        {

            ML.Empleado empleado = new ML.Empleado();
            empleado.Id_NumEmp = Id_NumEmp;
            var result = BL.Empleado.Delete(empleado);
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
        [Route("api/empleado/getById/{Id_NumEmp}")]
        public IHttpActionResult GetById(int Id_NumEmp)
        {
            var result = BL.Empleado.GetById(Id_NumEmp);
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
