using Microsoft.AspNetCore.Mvc;
using crud_productos.Models;
using crud_productos.Models.ViewModels;
using System.Linq;

namespace crud_productos.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductosContext _DBContext;

        public HomeController(ProductosContext context)
        {
            _DBContext = context;
        }

        /*
        Método de index de la crud que devuelve el listado de los productos almacenados en el sistema
        21/04/2025 Juan Barragán
        */
        public IActionResult Index()
        {
            List<Producto> lista = _DBContext.Productos.ToList();
            return View(lista);
        }

        /*
        Método de detalle de la crud que devuelve el detalle de un producto específico
        21/04/2025 Juan Barragán
        */
        [HttpGet]
        public IActionResult Producto_Detalle(int idProducto)
        {
            ProductoVm oProductoVm = new ProductoVm()
            {
                oProducto = new Producto()
            };

            if (idProducto != 0)
            {
                oProductoVm.oProducto = _DBContext.Productos.Find(idProducto);
            }

            return View(oProductoVm);
        }

        /*
        Método que actualiza o inserta un producto específico
        21/04/2025 Juan Barragán
        */
        [HttpPost]
        public IActionResult Producto_Detalle(ProductoVm oProductoVm)
        {
            // Validación de los atributos del producto
            if (!ModelState.IsValid)
            {
                // Si no es válido, retornar a la vista con los errores de validación
                return View(oProductoVm);
            }

            if (oProductoVm.oProducto.Id == 0)
            {
                // Si el ID es 0, es una creación (insertar)
                _DBContext.Productos.Add(oProductoVm.oProducto);
            }
            else
            {
                // Si el ID no es 0, es una actualización
                _DBContext.Productos.Update(oProductoVm.oProducto);
            }

            _DBContext.SaveChanges();

            // Redirigir a la lista de productos después de guardar
            return RedirectToAction("Index", "Home");
        }

        /*
        Método que redirecciona al eliminar un producto específico
        21/04/2025 Juan Barragán
        */
        [HttpGet]
        public IActionResult Eliminar(int idProducto)
        {
            Producto oProducto = _DBContext.Productos.Where(p => p.Id == idProducto).FirstOrDefault();

            return View(oProducto);
        }

        /*
        Método que elimina un producto específico
        21/04/2025 Juan Barragán
        */
        [HttpPost]
        public IActionResult Eliminar(Producto oProducto)
        {
            if (oProducto == null)
            {
                // Validación para asegurarse de que el producto no sea nulo
                return NotFound();
            }

            _DBContext.Productos.Remove(oProducto);
            _DBContext.SaveChanges();

            // Redirigir a la lista de productos después de eliminar
            return RedirectToAction("Index", "Home");
        }
    }
}