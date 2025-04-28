using Proyectommstore.Models;
using ProyectommStrore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyectommstore.Dao
{
    internal interface ClientesDao
    {
        int operacionesEscritura(string indicador, Clientes objcli);
        List<Clientes> operacionesLectura(string indicador, Clientes objcli);

    }
}
