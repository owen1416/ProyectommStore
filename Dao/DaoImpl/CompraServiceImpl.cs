// TuProyectoApi/Services/ServiceImpl/CompraServiceImpl.cs
using Proyectommstore.Dao;
using Proyectommstore.Dao.DaoImpl;
using Proyectommstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using ProyectommStrore.Models;
using Proyectommstore.Controllers;

namespace Proyectommstore.Dao.DaoImpl
{
    public class CompraServiceImpl : ICompraService
    {
        ProductoDao productoDao = new ProductoDaoImpl();
        PedidoDao pedidoDao = new PedidoDaoImpl();


        public Productos GetProductoPorId(int id)
        {
            return productoDao.operacionesLectura("buscar", new Productos() { ProductoID = id }).FirstOrDefault();
        }


        public ResultadoOperacion GenerarCompra(int clienteId, List<ItemCompra> itemsCompra)
        {
            if (itemsCompra == null || !itemsCompra.Any() || clienteId <= 0)
            {
                return new ResultadoOperacion
                {
                    Exito = false,
                    Mensaje = "La lista de items de compra no puede estar vacía y el ClienteId debe ser válido."
                };
            }

            decimal totalPedido = 0;
            var detallesPedido = new List<DetallePedido>();
            var productosActualizados = new List<Productos>();

            foreach (var item in itemsCompra)
            {
                var producto = GetProductoPorId(item.ProductoId);
                if (producto == null || producto.Stock < item.Cantidad)
                {
                    return new ResultadoOperacion
                    {
                        Exito = false,
                        Mensaje = $"Stock insuficiente para el producto con ID: {item.ProductoId}"
                    };
                }

                var subtotal = item.Cantidad * producto.Precio;
                totalPedido += subtotal;

                detallesPedido.Add(new DetallePedido
                {
                    ProductoID = item.ProductoId,
                    Cantidad = item.Cantidad,
                    PrecioUnitario = producto.Precio,
                    Subtotal = subtotal
                });

                productosActualizados.Add(new Productos
                {
                    ProductoID = producto.ProductoID,
                    Stock = producto.Stock - item.Cantidad
                });
            }

            var nuevoPedido = new Pedido
            {
                ClienteID = clienteId,
                FechaPedido = DateTime.Now,
                Estado = "Pendiente",
                Total = totalPedido
            };

            int pedidoCreado = pedidoDao.OperacionesEscrituraPedido("insertar", nuevoPedido);
            if (pedidoCreado <= 0 || nuevoPedido.PedidoID <= 0)
            {
                return new ResultadoOperacion
                {
                    Exito = false,
                    Mensaje = "Error al crear el pedido."
                };
            }

            int pedidoId = nuevoPedido.PedidoID;

            foreach (var detalle in detallesPedido)
            {
                detalle.PedidoID = pedidoId;
                int detalleCreado = pedidoDao.OperacionesEscrituraDetallePedido("insertar", detalle);
                if (detalleCreado <= 0)
                {
                    return new ResultadoOperacion
                    {
                        Exito = false,
                        Mensaje = "Error al crear los detalles del pedido."
                    };
                }

                var productoActualizar = productosActualizados.FirstOrDefault(p => p.ProductoID == detalle.ProductoID);
                if (productoActualizar != null)
                {
                    productoDao.operacionesEscritura("actualizar_stock", productoActualizar);
                }
            }

            return new ResultadoOperacion
            {
                Exito = true,
                Mensaje = "Pedido creado exitosamente.",
                Datos = nuevoPedido
            };
        }
    }
}
