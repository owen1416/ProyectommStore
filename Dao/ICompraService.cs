using Proyectommstore.Models;
using ProyectommStrore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Proyectommstore.Dao
{
    internal interface ICompraService
    {
        Productos GetProductoPorId(int id);
        PedidoRespuesta GenerarCompra(int clienteId, List<ItemCompra> itemsCompra);
    }
}
