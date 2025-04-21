using Microsoft.AspNetCore.Mvc;
using crud_productos.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class ProductosApiController : ControllerBase
{
    private readonly ProductosContext _DBContext;

    public ProductosApiController(ProductosContext context)
    {
        _DBContext = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Producto>> Get()
    {
        return _DBContext.Productos.ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<Producto> Get(int id)
    {
        var producto = _DBContext.Productos.Find(id);
        if (producto == null)
        {
            return NotFound();
        }
        return producto;
    }

    [HttpPost]
    public ActionResult<Producto> Post([FromBody] Producto producto)
    {
        // Validación de los atributos del producto
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);  // Devuelve los errores de validación
        }

        _DBContext.Productos.Add(producto);
        _DBContext.SaveChanges();
        return CreatedAtAction(nameof(Get), new { id = producto.Id }, producto);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Producto producto)
    {
        // Validación de los atributos del producto
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);  // Devuelve los errores de validación
        }

        if (id != producto.Id)
        {
            return BadRequest("El ID del producto no coincide con el ID de la URL.");
        }

        // Verificar si el producto existe
        var productoExistente = _DBContext.Productos.FirstOrDefault(p => p.Id == id);
        if (productoExistente == null)
        {
            return NotFound($"Producto con ID {id} no encontrado.");
        }

        // Actualizar los campos del producto
        productoExistente.Nombre = producto.Nombre;
        productoExistente.Descripcion = producto.Descripcion;
        productoExistente.Precio = producto.Precio;
        productoExistente.Stock = producto.Stock;

        // Guardar cambios en la base de datos
        _DBContext.SaveChanges();

        // Devolver el mensaje y el producto actualizado
        return Ok(new { mensaje = "Producto actualizado correctamente.", producto = productoExistente });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var producto = _DBContext.Productos.Find(id);
        if (producto == null)
        {
            return NotFound($"Producto con ID {id} no encontrado.");
        }

        _DBContext.Productos.Remove(producto);
        _DBContext.SaveChanges();

        // Devolver un mensaje de éxito con el producto eliminado
        return Ok(new { mensaje = "Producto eliminado correctamente.", producto });
    }
}