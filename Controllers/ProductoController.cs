

using Proyectommstore.Dao.DaoImpl;
using Proyectommstore.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProyectommStrore.Models;
using System.Web.Routing;

namespace Proyectommstore.Controllers
{
    [RoutePrefix("api/pro")]
    public class ProductoController : ApiController
    {

        ProductoDao dao = new ProductoDaoImpl();

        [HttpGet]
        [Route("getall")]
        public IHttpActionResult GetAll()
        {

            return Ok(dao.operacionesLectura("listar", new Productos()));

        }


        [HttpPost]
        [Route("")]
        public IHttpActionResult Post(Productos pro)
        {
            return Ok(dao.operacionesEscritura("insertar", pro));
                
        }

        [HttpDelete]
        [Route("delete")]
        public IHttpActionResult Delete(int id)
        {
            var delete = dao.operacionesEscritura("eliminar", new Productos { ProductoID = id });

            return Ok(delete);

        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetId(int id)
        {
            var buscar = dao.operacionesLectura("buscar", new Productos { ProductoID = id}).FirstOrDefault();
            return Ok(buscar);
        }

        [HttpPut]
        [Route("editar")]
        public IHttpActionResult Put(Productos pro)
        {
            var resultado = dao.operacionesEscritura("editar", pro);
            return Ok(resultado);
        }
    }
}
