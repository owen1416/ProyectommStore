using Proyectommstore.Dao;
using Proyectommstore.Dao.DaoImpl;
using Proyectommstore.Models;
using ProyectommStrore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Proyectommstore.Controllers
{
    [RoutePrefix("api/cliente")]
    public class ClienteController : ApiController
    {
        ClientesDao dao = new ClientesDaoImpl();

        [HttpGet]
        [Route("getall")]
        public IHttpActionResult Get()
        {
            return Ok(dao.operacionesLectura("listar", new Clientes()));
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Post(Clientes cli)
        {
            return Ok(dao.operacionesEscritura("insertar", cli));

        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            var delete = dao.operacionesEscritura("eliminar", new Clientes { ClienteID = id });

            return Ok(delete);

        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetId(int id)
        {
            var buscar = dao.operacionesLectura("buscar", new Clientes { ClienteID = id }).FirstOrDefault();
            return Ok(buscar);
        }


        [HttpPut]
        [Route("editar")]
        public IHttpActionResult Put(Clientes cli)
        {
            var resultado = dao.operacionesEscritura("editar", cli);
            return Ok(resultado);
        }
    }
}
