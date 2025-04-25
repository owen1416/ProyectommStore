using ProyectommStrore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyectommstore.Dao
{
    internal interface ProductoDao
    {
        int operacionesEscritura(string indicador, Productos objpro);
        List<Productos> operacionesLectura(string indicador, Productos objpro);

    }
}
