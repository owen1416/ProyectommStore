﻿using Proyectommstore.Dao.DaoImpl;
using Proyectommstore.Dao;
using Proyectommstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProyectommStrore.Models;

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

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            var delete = dao.operacionesEscritura("eliminar", new Pedido { PedidoID = id });

            return Ok(delete);

        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetId(int id)
        {
            var buscar = dao.operacionesLectura("buscar", new Pedido { PedidoID = id }).FirstOrDefault();
            return Ok(buscar);
        }

    }
}
