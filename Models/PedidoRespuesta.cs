using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyectommstore.Models
{
    public class PedidoRespuesta
    {
        public bool Exito { get; set; }
        public string Mensaje { get; set; }
        public object Datos { get; set; } // Puedes guardar el Pedido o algo extra aquí
    }
}   