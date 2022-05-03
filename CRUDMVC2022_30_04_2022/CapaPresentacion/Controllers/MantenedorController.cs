using Microsoft.AspNetCore.Mvc;
using CapaPresentacion.Data;
using CapaPresentacion.Models;

namespace CapaPresentacion.Controllers
{
    public class MantenedorController : Controller
    {
        REPO_CONTACTO _repo = new REPO_CONTACTO();

        public IActionResult Listar()
        {
            var lista = _repo.listar();

            return View(lista);
        }
        public IActionResult Guardar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Guardar(ContactoModel contacto)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            var ans = _repo.Guadar(contacto);

            if (ans)
            {
                return RedirectToAction("Listar");
            }
            return View();
        }
        public IActionResult Eliminar(int Id)
        {
            var Contact = _repo.listarByContact(Id);
            return View(Contact); ;
        }

        [HttpPost]
        public IActionResult Eliminar(ContactoModel contacto)
        {       
            var ans = _repo.Eliminar(contacto.IdContacto);
            if (ans)
            {
                return RedirectToAction("Listar");
            }
            return View();
        }

        public IActionResult Editar(int Id)
        {
            var Contact = _repo.listarByContact(Id);

            return View(Contact);
        }
        [HttpPost]
        public IActionResult Editar(ContactoModel contacto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var ans = _repo.Editar(contacto);

            if (ans)
            {
                return RedirectToAction("Listar");
            }
            return View();
        }

    }
}
