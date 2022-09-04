using Microsoft.AspNetCore.Mvc;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Controllers
{
    public class PlanoContaController : Controller
    {
        private readonly ILogger<PlanoContaController> _logger;

        public PlanoContaController(ILogger<PlanoContaController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var planoContasModel = new PlanoContaModel();
            ViewBag.Lista = planoContasModel.ListaPlanoContas();
            return View();
        }

        [HttpGet]
        public IActionResult CriarPlanoConta()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CriarPlanoConta(PlanoContaModel formulario)
        {
            formulario.Insert();
            return RedirectToAction("Index");
        }
    }
}