using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ColaboradoresManagement.Controllers
{
    public class ColaboradoresController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
