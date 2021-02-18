using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ent;
using BL;

namespace ClienteApi.Controllers
{

    public class ClienteController : ApiController
    {
        ClienteBL _ClienteActions = new ClienteBL();
        // GET: api/Cliente
        public IEnumerable<clsCliente> Get()
        {
            return _ClienteActions.Obtener();
        }
        

        // POST: api/Cliente
        [HttpPost]
        public IHttpActionResult Post([FromBody]clsCliente pCliente)
        {
            try
            {
                _ClienteActions.Guardar(pCliente);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }

        // PUT: api/Cliente/5
        [HttpPost]
        public IHttpActionResult Put(int id, [FromBody]clsCliente pCliente)
        {
            try
            {
                _ClienteActions.Modificar(pCliente);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // DELETE: api/Cliente/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                _ClienteActions.Eliminar(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
