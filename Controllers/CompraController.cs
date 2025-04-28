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
using System.Web.Http.Results;

namespace Proyectommstore.Controllers
{
    [RoutePrefix("api/compra")]
    public class CompraController : ApiController
    {
        private readonly ICompraService _compraService;

        public CompraController()
        {
            _compraService = new CompraServiceImpl();
        }

 
  

        [HttpPost]
        [Route("generar")]
        public IHttpActionResult GenerarCompra([FromBody] List<ItemCompra> itemsCompra, [FromUri] int clienteId)
        {
            var resultado = _compraService.GenerarCompra(clienteId, itemsCompra);

            if (!resultado.Exito)
            {
                return BadRequest(resultado.Mensaje);
            }

            return Ok(resultado);
        }
    }
}
