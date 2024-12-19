using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace ProductosApi.Controllers.Models
{
    public class Producto
    {
        [Key]
        public int idproducto { get; set; }
        public string? nombre { get; set; }
        public double precio { get; set; }
        public int cantidad { get; set; }
        public DateOnly fecha_registro { get; set; }
        public bool estado { get; set; }
    }
}