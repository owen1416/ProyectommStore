using Proyectommstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyectommstore.Dao
{
    internal interface PedidoCompraDao
    {
        int OperacionesEscrituraPedido(string indicador, Pedido objPedido);
        Pedido OperacionesLecturaPedido(string indicador, Pedido objPedido);
        int OperacionesEscrituraDetallePedido(string indicador, DetallePedido objDetallePedido);
    }
}
