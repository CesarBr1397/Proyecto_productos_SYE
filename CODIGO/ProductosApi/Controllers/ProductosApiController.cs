using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductosApi.Controllers.Models;
using ProductosApi.data;


namespace ProductosApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosApiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductosApiController(AppDbContext context)
        {
            _context = context;
        }

        public Producto producto = new Producto();

        //Obtener todos
        [HttpGet]
        public IActionResult Get()
        {
            var productos = _context.productos.OrderBy(x => x.idproducto).ToList();
            return Ok(productos);
        }

        //Obtener por ID
        [HttpGet("{id}")]
        public IActionResult getId(int id)
        {
            var producto = _context.productos.Find(id);
            if (producto == null)
            {
                return NotFound("No se encontró el producto");
            }
            return Ok(producto);
        }

        //Agregar
        [HttpPost]
        public IActionResult Post([FromBody] Producto producto)
        {
            var productonuevo = _context.productos.Add(producto);
            _context.SaveChanges();

            var productoGuardado = _context.productos
                .OrderByDescending(x => x.idproducto)
                .FirstOrDefault();

            return Ok(productoGuardado);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Producto ProductoActual)
        {
            var productoExistente = _context.productos.Find(id);
            if (productoExistente == null)
            {
                return NotFound("No se encontró el producto");
            }
            productoExistente.nombre = ProductoActual.nombre;
            productoExistente.precio = ProductoActual.precio;
            productoExistente.cantidad = ProductoActual.cantidad;
            productoExistente.fecha_registro = ProductoActual.fecha_registro;
            productoExistente.estado = ProductoActual.estado;

            _context.SaveChanges();

            return Ok(productoExistente);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var producto = _context.productos.Find(id);

            if (producto == null)
            {
                return NotFound("No se encontró el producto");
            }

            producto.estado = false;
            _context.SaveChanges();

            return Ok("El producto se desactivó correctamente");
        }
    }
}