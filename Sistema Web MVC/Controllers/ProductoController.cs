using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sistema_Web_MVC.Models;

namespace Sistema_Web_MVC.Controllers
{
    public class ProductoController : Controller
    {
        private readonly AppDbContext _context;

        public ProductoController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> ProductoHome()
        {
            var productosDelSistema = await _context.Productos.Include(p=>p.Categoria).ToListAsync();
            return View(productosDelSistema);
        }
        public IActionResult ProductoCreate()
        {
            var categorias = _context.Categorias.ToList();
            ViewData["Categorias"] = new SelectList(categorias, "CategoriaId", "Nombre");
            return View();
        }

        [HttpPost]
        public IActionResult ProductoCreate(Producto P)
        {
            if (ModelState.IsValid)
            {
                _context.Add(P);
                _context.SaveChanges();
                return RedirectToAction(nameof(ProductoHome));
            }
            else
            {
                ModelState.AddModelError("", "Ha ocurrido un error al guardar!");
                return View(P);
            }
        }

        public IActionResult ProductoEdit(int Id)
        {
            var C = _context.Productos.Find(Id);
            if (C == null)
            {
                return View("Error");
            }
            else
            {
                var categorias = _context.Categorias.ToList();
                ViewData["Categorias"] = new SelectList(categorias, "CategoriaId", "Nombre");
                return View(C);
            }

        }

        [HttpPost]
        public IActionResult ProductoEdit(Producto C)
        {
            if (ModelState.IsValid)
            {
                _context.Productos.Update(C);
                _context.SaveChanges();
                return RedirectToAction(nameof(ProductoHome));
            }
            else
            {
                ModelState.AddModelError("", "Ha ocurrido un error al guardar!");
                return View(C);
            }

        }
    }
}
