using Proyectommstore.Models;
using ProyectommStrore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyectommstore.Dao
{
    internal interface PedidoDao
    {
        int operacionesEscritura(string indicador, Pedido objpe);
        List<Pedido> operacionesLectura(string indicador, Pedido objpe);
    }
}
