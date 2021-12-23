using ColaboradoresManagement.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColaboradoresManagement.Domain.Interface.Repository
{
    public interface IColaboradorRepository
    {
        Task<IEnumerable<Colaborador>> BuscarColaboradoresAsync();
        Task<Colaborador> BuscarColaboradorPorNomeAsync();
        Task<Colaborador> CadastrarColaboradorAsync();
        Task<Colaborador> RemoverColaboradorAsync();
    }
}
