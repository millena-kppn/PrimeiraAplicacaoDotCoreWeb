using Microsoft.AspNetCore.Mvc;
using PrimeiraAplicacaoDotCoreWeb.Models.Usuario;
using Service;

namespace PrimeiraAplicacaoDotCoreWeb.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            var db = new Db();
            var listaUsuariosDTO = db.GetUsuarios();
            var listaUsuarios = new List<Usuario>();
            foreach (var usuariosDTO in listaUsuariosDTO)
            { 
                var usuario = new Usuario();
                usuario.Id = usuariosDTO.id; 
                usuario.Nome = usuariosDTO.nome;
                usuario.Sobrenome = usuariosDTO.sobrenome;
                usuario.Email = usuariosDTO.email;
                listaUsuarios.Add(usuario);
            }
            return View(listaUsuarios);
        }
        public IActionResult NovoUsuario()
        {
            return View();
        }
        public IActionResult PersistirUsuario(string nome, string sobrenome, string email)
        {
            return RedirectToAction("Index");
        }
    }
}
