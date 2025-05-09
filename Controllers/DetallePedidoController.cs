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
    [RoutePrefix("api/detalle")]
    public class DetallePedidoController : ApiController
    {

        DetalleDao  dao = new DetalleDaoImpl();


        [HttpGet]
        [Route("getall")]   
        public IHttpActionResult Get()
        {
            return Ok(dao.operacionesLectura("listar", new DetallePedido()));
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            var delete = dao.operacionesEscritura("eliminar", new DetallePedido { DetallePedidoID = id });

            return Ok(delete);

        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetId(int id)
        {
            var buscar = dao.operacionesLectura("buscar", new DetallePedido { DetallePedidoID = id }).FirstOrDefault();
            return Ok(buscar);
        }
    }
}

