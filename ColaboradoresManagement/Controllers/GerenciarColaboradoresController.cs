using ColaboradoresManagement.Domain.Dto;
using ColaboradoresManagement.Domain.Interface.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ColaboradoresManagement.Controllers
{
    [Route("GerenciarColaboradores")]
    [ApiController]
    public class GerenciarColaboradoresController : Controller
    {
        private readonly IGerenciarColaboradoresService _colaboradorService;

        public GerenciarColaboradoresController(IGerenciarColaboradoresService colaboradorService)
        {
            _colaboradorService = colaboradorService;
        }
        
        [HttpGet("BuscarColaboradores")]
        public async Task<IActionResult> BuscarColaboradoresAsync()
        {
            try
            {
                var buscarColaboradores = await _colaboradorService.BuscarColaboradoresAsync();
                return Ok(buscarColaboradores);
            }
            catch (Exception e)
            {
                throw new Exception("Nenhum encontrado" + e);
            }            
        }

        [HttpPost("CadastrarColaborador")]
        public async Task<IActionResult> CadastrarColaboradorAsync(ColaboradorDto colaborador)
        {
            try
            {
                await _colaboradorService.CadastrarColaboradorAsync(colaborador);                
                return Ok("Cadastrado com Sucesso");
            }
            catch (Exception)
            {
                return BadRequest("Falha na requisição");
            }

        }
        [HttpPost("BuscarColaboradorPorNome")]
        public async Task<IActionResult> BuscarColaboradorPorNomeAsync([FromBody]String nome)
        {
            try
            {               
              // var convertJson = JsonConvert.DeserializeObject<ColaboradorDto>(nome);
               var cadastrarColaborador = await _colaboradorService.BuscarColaboradorPorNomeAsync(nome);
               return Ok(cadastrarColaborador);
            }
            catch (Exception e)
            {

                throw new Exception("Nenhum encontrado" + e);
            }
            
        }

        [HttpPost("RemoverColaborador")]
        public async Task<IActionResult> RemoverColaboradorAsync([FromBody]string nome)
        {
            try
            {
                await _colaboradorService.RemoverColaboradorAsync(nome);                
                return Ok("Excluido criado com Sucesso");
            }
            catch (Exception e)
            {
                throw new Exception("Colaborador não encontrado");
            }

        }

    }
}
