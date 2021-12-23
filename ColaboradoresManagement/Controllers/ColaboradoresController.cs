using ColaboradoresManagement.Domain.Dto;
using ColaboradoresManagement.Domain.Interface.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ColaboradoresManagement.Controllers
{
    public class ColaboradoresController : Controller
    {
        private readonly IGerenciarColaboradoresService _colaboradorService;

        public ColaboradoresController(IGerenciarColaboradoresService colaboradorService)
        {
            _colaboradorService = colaboradorService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> BuscarColaboradoresAsync()
        {
            var buscarColaboradores = await _colaboradorService.BuscarColaboradoresAsync();
            return View("_ListaColaboradores");
        }
    }
}
