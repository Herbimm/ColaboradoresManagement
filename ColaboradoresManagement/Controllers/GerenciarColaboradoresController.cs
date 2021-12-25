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
            return View("ListaColaboradores", buscarColaboradores);
        }

        [HttpPost("CadastrarColaborador")]
        public async Task<IActionResult> CadastrarColaboradorAsync(ColaboradorDto colaborador)
        {
            try
            {                
                await _colaboradorService.CadastrarColaboradorAsync(colaborador);
                TempData["AlertMensage"] = "Cadastro criado com Sucesso";
                return RedirectToAction("Index");
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
            return View("ListaColaboradoresPorNome", cadastrarColaborador);
        }

        [HttpPost("RemoverColaborador")]
        public async Task<IActionResult> RemoverColaboradorAsync(string nome)
        {
            try
            {
                await _colaboradorService.RemoverColaboradorAsync(nome);
                TempData["AlertMensage"] = "Excluido criado com Sucesso";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return View("Erro");
            }            
            
        }


    }
}
