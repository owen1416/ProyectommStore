using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyectommstore.Models
{
    public class DetallePedido
    {
        public int DetallePedidoID { get; set; }
        public int PedidoID { get; set; }
        public int ProductoID { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }

        public DetallePedido()
        {
        }

        public DetallePedido(int detallePedidoID, int pedidoID, int productoID, int cantidad, decimal precioUnitario, decimal subtotal)
        {
            DetallePedidoID = detallePedidoID;
            PedidoID = pedidoID;
            ProductoID = productoID;
            Cantidad = cantidad;
            PrecioUnitario = precioUnitario;
            Subtotal = subtotal;
        }
    }
}