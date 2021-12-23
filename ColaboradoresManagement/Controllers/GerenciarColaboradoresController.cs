using ColaboradoresManagement.Domain.Interface.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ColaboradoresManagement.Controllers
{
    public class GerenciarColaboradoresController : Controller
    {
        private readonly IGerenciarColaboradoresService _colaboradorService;

        public GerenciarColaboradoresController(IGerenciarColaboradoresService colaboradorService)
        {
            _colaboradorService = colaboradorService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> BuscarColaboradoresAsync()
        {
            var buscarColaboradores = await _colaboradorService.BuscarColaboradoresAsync();
            return View("");
        }
    }
}
