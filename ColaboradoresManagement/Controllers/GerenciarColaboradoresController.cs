using ColaboradoresManagement.Domain.Dto;
using ColaboradoresManagement.Domain.Entity;
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
        [HttpGet("BuscarColaboradores")]              
        public async Task<IActionResult> BuscarColaboradoresAsync()
        {
            var buscarColaboradores = await _colaboradorService.BuscarColaboradoresAsync();
            return View("_ListaColaboradores");
        }
        [HttpPost("CadastrarColaborador")]
        public async Task<IActionResult> CadastrarColaboradorAsync([FromBody]ColaboradorDto colaborador)
        {
            try
            {                
                await _colaboradorService.CadastrarColaboradorAsync(colaborador);
                return PartialView("_CadastradoComSucesso");
            }
            catch (Exception)
            {
                return PartialView("_CadastradoFalha");
            }           
            
        }
        [HttpGet("BuscarColaboradorPorNome")]
        public async Task<IActionResult> BuscarColaboradorPorNomeAsync(string nome)
        {
            var cadastrarColaborador = await _colaboradorService.BuscarColaboradorPorNomeAsync(nome);
            return View("_ListaColaboradores");
        }

        [HttpDelete("RemoverColaborador")]
        public async Task<IActionResult> RemoverColaboradorAsync(string nome)
        {
            try
            {
                await _colaboradorService.RemoverColaboradorAsync(nome);
                return View("");
            }
            catch (Exception)
            {

                return View("Erro");
            }            
            
        }


    }
}
