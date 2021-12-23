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
        private readonly IGerenciarColaboradoresService _gerenciarColaboradoresService;

        public ColaboradoresController(IGerenciarColaboradoresService gerenciarColaboradoresService)
        {
            _gerenciarColaboradoresService = gerenciarColaboradoresService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> BuscarColaboradoresAsync()
        {
            return null;
        }

    }
}
