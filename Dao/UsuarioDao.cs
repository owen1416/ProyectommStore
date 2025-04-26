using Proyectommstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyectommstore.Dao
{
    public interface UsuarioDao
    {
        Usuarios ObtenerUsuario(string indicador,string NombreUsuario);
        bool VerificarPassword(string passwordIngresado, string passwordAlmacenado);

        int operacionesEscitura(string indicador, Usuarios objusu);
        List<Usuarios> operacionesLectura(string indicador, Usuarios objusu);

        string HashPassword(string password);

    }
}
