using ColaboradoresManagement.Domain.Dto;
using ColaboradoresManagement.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColaboradoresManagement.Domain.Interface.Service
{
    public interface IGerenciarColaboradoresService
    {
        Task<IEnumerable<ColaboradorDto>> BuscarColaboradoresAsync();
        Task<Colaborador> BuscarColaboradorPorNomeAsync();
        Task<Colaborador> CadastrarColaboradorAsync();
        Task<Colaborador> RemoverColaboradorAsync();        
    }
}
