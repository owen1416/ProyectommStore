using Proyectommstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyectommstore.Dao
{
    internal interface DetalleDao
    {
        int operacionesEscritura(string indicador, DetallePedido objdetalle);
        List<DetallePedido> operacionesLectura(string indicador, DetallePedido objdetalle);
    }
}
