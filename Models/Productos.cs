
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectommStrore.Models
{
    public class Productos
    {
        public int ProductoID { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string Categoria { get; set; }

        public Productos()
        {
            ProductoID = 0;
            Nombre = "";
            Marca = "";
            Modelo = "";
            Descripcion = "";
            Precio = 0;
            Stock = 1;
            Categoria = "";
        }

        public Productos(int productoID, string nombre, string marca, string modelo, string descripcion, decimal precio, int stock, string categoria)
        {
            ProductoID = productoID;
            Nombre = nombre;
            Marca = marca;
            Modelo = modelo;
            Descripcion = descripcion;
            Precio = precio;
            Stock = stock;
            Categoria = categoria;
        }
    }
}