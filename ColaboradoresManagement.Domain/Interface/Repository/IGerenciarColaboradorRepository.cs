using ColaboradoresManagement.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColaboradoresManagement.Domain.Interface.Repository
{
    public interface IGerenciarColaboradorRepository
    {
        Task<IEnumerable<Colaborador>> BuscarColaboradoresAsync();
        Task<Colaborador> BuscarColaboradorPorNomeAsync(string nome);
        Task CadastrarColaboradorAsync(Colaborador colaborador);
        Task RemoverColaboradorAsync(Colaborador colaborador);
    }
}
