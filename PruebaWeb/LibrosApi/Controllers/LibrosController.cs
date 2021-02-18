using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ENT;
using BL;

namespace LibrosApi.Controllers
{
    public class LibrosController : ApiController
    {
        LibrosBL _libroAction = new LibrosBL();
        // GET: api/Cliente
        public IEnumerable<clsLibro> Get()
        {
            return _libroAction.Obtener();
        }
    }
}
