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

        public Task<Colaborador> BuscarColaboradorPorNomeAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Colaborador> CadastrarColaboradorAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Colaborador> RemoverColaboradorAsync()
        {
            throw new NotImplementedException();
        }
    }
}
