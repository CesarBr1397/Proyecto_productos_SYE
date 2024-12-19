using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductosApi.Controllers.Models;
using ProductosApi.data;

namespace ProductosApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        //         public async Task<IActionResult> Index()
        //         {
        //             var productos = await _context.productos.Where(x => x.estado == true).OrderBy(x => x.idproducto).ToListAsync();
        //             return View(productos);
        //         }

        //         public IActionResult Agregar()
        //         {
        //             return View();
        //         }
        //         [HttpPost]
        //         public IActionResult Agregar(Producto producto)
        //         {
        //             var productoNuevo = _context.productos.Add(producto);
        //             _context.SaveChanges();
        //             return RedirectToAction("Index");
        //         }

        //         public IActionResult Details(int id)
        //         {
        //             var producto = _context.productos.Find(id);
        //             return View("Mostrar_id", producto);
        //         }

        //         public IActionResult Update(int id)
        //         {
        //             var producto = _context.productos.Find(id);

        //             return View("Update", producto);
        //         }

        //         [HttpPost]
        //         public IActionResult Update(Producto newProducto)
        //         {
        //             _context.productos.Update(newProducto);
        //             _context.SaveChanges();

        //             return RedirectToAction("Index");
        //         }

        //         public IActionResult Borrar(int id)
        //         {
        //             var producto = _context.productos.Find(id);

        //             return View("Delete", producto);
        //         }

        //         [HttpPost]
        //         public IActionResult Borrar(Producto producto)
        //         {
        //             producto.estado = false;
        //             _context.Update(producto);
        //             _context.SaveChanges();

        //             return RedirectToAction("Index");
        //         }

        //         public IActionResult Atras()
        //         {
        //             return RedirectToAction("Index");
        //         }



        // Obtener todos los productos activos
        public async Task<IActionResult> Index()
        {
            var productos = await _context.productos.FromSqlRaw("SELECT * FROM schemasye.obtener_productos()").ToListAsync();

            return View(productos);
        }

        // CREATE - Agregar un nuevo producto
        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Agregar(Producto producto)
        {
            await _context.Database.ExecuteSqlRawAsync("SELECT * FROM schemasye.insertar_producto({0}, {1}, {2}, {3}, {4})", 
            producto.nombre, 
            producto.precio, 
            producto.cantidad, 
            producto.fecha_registro, 
            producto.estado);

            return RedirectToAction("Index");
        }

        // READ BY ID - Mostrar detalles de un producto
        public async Task<IActionResult> Details(int id)
        {
            var producto = await _context.productos
                .FromSqlRaw("SELECT * FROM schemasye.obtener_producto_por_id({0})", id)
                .FirstOrDefaultAsync();

            return View("Mostrar_id", producto);
        }

        // UPDATE - Actualizar un producto
        public async Task<IActionResult> Update(int id)
        {
            var producto = await _context.productos
                .FromSqlRaw("SELECT * FROM schemasye.obtener_producto_por_id({0})", id)
                .FirstOrDefaultAsync();

            return View("Update", producto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Producto producto)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "SELECT schemasye.actualizar_producto({0}, {1}, {2}, {3}, {4}, {5})",
                producto.idproducto, producto.nombre, producto.precio, producto.cantidad, producto.fecha_registro, producto.estado);

            return RedirectToAction("Index");
        }

        // DELETE - Eliminar (lógico) un producto
        public async Task<IActionResult> Borrar(int id)
        {
            var producto = await _context.productos
                .FromSqlRaw("SELECT * FROM schemasye.obtener_producto_por_id({0})", id)
                .FirstOrDefaultAsync();

            return View("Delete", producto);
        }

        [HttpPost]
        public async Task<IActionResult> Borrar(Producto producto)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "SELECT schemasye.eliminar_producto({0})", producto.idproducto);

            return RedirectToAction("Index");
        }

        // ATRÁS - Redirigir al Index
        public IActionResult Atras()
        {
            return RedirectToAction("Index");
        }
    }
}