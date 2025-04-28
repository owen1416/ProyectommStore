
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyectommstore.Models
{
    public class Clientes
    {
        public int ClienteID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public int NrDocumento { get; set; }
        public string Documento { get; set; }
    

        public Clientes()
        {
            ClienteID = 0;
            Nombre = "";
            Apellido = "";
            Email = "";
            Telefono = "";
            NrDocumento = 0;
            Documento = "";
            
        }

        public Clientes(int clienteID, string nombre, string apellido, string email, string telefono, int nrDocumento, string documento)
        {
            ClienteID = clienteID;
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Telefono = telefono;
            NrDocumento = nrDocumento;
            Documento = documento;
        }
    }
}