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
        M�todo de index de la crud que devuelve el listado de los productos almacenados en el sistema
        21/04/2025 Juan Barrag�n
        */
        public IActionResult Index()
        {
            List<Producto> lista = _DBContext.Productos.ToList();
            return View(lista);
        }

        /*
        M�todo de detalle de la crud que devuelve el detalle de un producto espec�fico
        21/04/2025 Juan Barrag�n
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
        M�todo que actualiza o inserta un producto espec�fico
        21/04/2025 Juan Barrag�n
        */
        [HttpPost]
        public IActionResult Producto_Detalle(ProductoVm oProductoVm)
        {
            // Validaci�n de los atributos del producto
            if (!ModelState.IsValid)
            {
                // Si no es v�lido, retornar a la vista con los errores de validaci�n
                return View(oProductoVm);
            }

            if (oProductoVm.oProducto.Id == 0)
            {
                // Si el ID es 0, es una creaci�n (insertar)
                _DBContext.Productos.Add(oProductoVm.oProducto);
            }
            else
            {
                // Si el ID no es 0, es una actualizaci�n
                _DBContext.Productos.Update(oProductoVm.oProducto);
            }

            _DBContext.SaveChanges();

            // Redirigir a la lista de productos despu�s de guardar
            return RedirectToAction("Index", "Home");
        }

        /*
        M�todo que redirecciona al eliminar un producto espec�fico
        21/04/2025 Juan Barrag�n
        */
        [HttpGet]
        public IActionResult Eliminar(int idProducto)
        {
            Producto oProducto = _DBContext.Productos.Where(p => p.Id == idProducto).FirstOrDefault();

            return View(oProducto);
        }

        /*
        M�todo que elimina un producto espec�fico
        21/04/2025 Juan Barrag�n
        */
        [HttpPost]
        public IActionResult Eliminar(Producto oProducto)
        {
            if (oProducto == null)
            {
                // Validaci�n para asegurarse de que el producto no sea nulo
                return NotFound();
            }

            _DBContext.Productos.Remove(oProducto);
            _DBContext.SaveChanges();

            // Redirigir a la lista de productos despu�s de eliminar
            return RedirectToAction("Index", "Home");
        }
    }
}