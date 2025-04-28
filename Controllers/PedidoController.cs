using Proyectommstore.Dao.DaoImpl;
using Proyectommstore.Dao;
using Proyectommstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Proyectommstore.Controllers
{

    [RoutePrefix("api/pedido")]
    public class PedidoController : ApiController
    {
        PedidoDao dao = new PedidoDaoImpl();

        [HttpGet]
        [Route("getall")]
        public IHttpActionResult Get()
        {
           
            var pedidos = dao.operacionesLectura("listar", new Pedido());

            return Ok(pedidos);
        }

    }
}
