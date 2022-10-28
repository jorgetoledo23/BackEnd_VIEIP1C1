using Microsoft.AspNetCore.Mvc;
using Sistema_Web_MVC.Models;

namespace Sistema_Web_MVC.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly AppDbContext _context;

        public CategoriaController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult CategoriaHome()
        {
            var categoriasDelSistema = _context.Categorias.ToList();
            return View(categoriasDelSistema);
        }
        public IActionResult CategoriaCreate()
        {
            return View();
        }

        public IActionResult CategoriaEdit(int Id)
        {
            var C = _context.Categorias.Find(Id);
            if(C == null)
            {
                return View("Error");
            }
            else
            {
                return View(C);
            }
            
        }

        public IActionResult CategoriaDelete(int Id)
        {
            var C = _context.Categorias.Find(Id);
            if (C == null)
            {
                return View("Error");
            }
            else
            {
                _context.Categorias.Remove(C);
                _context.SaveChanges();
                return RedirectToAction(nameof(CategoriaHome));
            }

        }



        [HttpPost]
        public IActionResult CategoriaCreate(Categoria C)
        {
            if (ModelState.IsValid)
            {
                _context.Categorias.Add(C);
                _context.SaveChanges();
                return RedirectToAction(nameof(CategoriaHome));
            }
            else
            {
                ModelState.AddModelError("", "Ha ocurrido un error al guardar!");
                return View(C);
            }
            
        }

        [HttpPost]
        public IActionResult CategoriaEdit(Categoria C)
        {
            if (ModelState.IsValid)
            {
                _context.Categorias.Update(C);
                _context.SaveChanges();
                return RedirectToAction(nameof(CategoriaHome));
            }
            else
            {
                ModelState.AddModelError("", "Ha ocurrido un error al guardar!");
                return View(C);
            }

        }

    }
}
