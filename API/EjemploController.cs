using System.Linq;
using Datos;
using Datos.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace API
{
    [Route("{controller}")]
    public class EjemploController : Controller
    {
        private Contexto _contexto;

        public EjemploController(Contexto contexto)
        {
            _contexto = contexto;
        }

        // GET
        public IActionResult Index()
        {
            _contexto._sesion.Save(new EntidadRaiz("Hola mundo"));
            _contexto._sesion.Flush();
            return Ok(_contexto.EntidadRaiz.ToList());
        }
    }
}