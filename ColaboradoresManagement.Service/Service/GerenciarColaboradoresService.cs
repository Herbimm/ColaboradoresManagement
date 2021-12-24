using AutoMapper;
using ColaboradoresManagement.Domain.Dto;
using ColaboradoresManagement.Domain.Entity;
using ColaboradoresManagement.Domain.Interface.Repository;
using ColaboradoresManagement.Domain.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColaboradoresManagement.Service.Service
{
    public class GerenciarColaboradoresService : IGerenciarColaboradoresService
    {
        private readonly IGerenciarColaboradorRepository _colaboradorRepository;
        private readonly IMapper _mapper;

        public GerenciarColaboradoresService(IGerenciarColaboradorRepository colaboradorRepository,
            IMapper mapper)
        {
            _colaboradorRepository = colaboradorRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ColaboradorDto>> BuscarColaboradoresAsync()
        {
            var buscarColaboradores = await _colaboradorRepository.BuscarColaboradoresAsync();
            var dtoColaboradores = _mapper.Map<IEnumerable<ColaboradorDto>>(buscarColaboradores);
            return dtoColaboradores;
        }

        public async Task<ColaboradorDto> BuscarColaboradorPorNomeAsync(string nome)
        {
            var buscarColaboradorPeloNome = await _colaboradorRepository.BuscarColaboradorPorNomeAsync(nome);
            var colaborador = _mapper.Map<ColaboradorDto>(buscarColaboradorPeloNome);
            return colaborador;
        }

        public async Task CadastrarColaboradorAsync(ColaboradorDto colaborador)
        {
            var cadastro = _mapper.Map<Colaborador>(colaborador);
            cadastro.Id = Guid.NewGuid();
            await _colaboradorRepository.CadastrarColaboradorAsync(cadastro);
        }

        public async Task<string> RemoverColaboradorAsync(string nome)
        {
            var colaborador = await _colaboradorRepository.BuscarColaboradorPorNomeAsync(nome);
            await _colaboradorRepository.RemoverColaboradorAsync(colaborador);
            return nome;
        }
    }
}
