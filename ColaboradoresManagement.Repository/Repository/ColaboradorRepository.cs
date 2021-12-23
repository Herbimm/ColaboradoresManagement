using ColaboradoresManagement.Domain.Entity;
using ColaboradoresManagement.Domain.Interface.Repository;
using ColaboradoresManagement.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColaboradoresManagement.Repository.Repository
{
    public class ColaboradorRepository : IColaboradorRepository
    {
        private readonly MyContext _myContext;
        public DbSet<Colaborador> _dbset { get; }

        public ColaboradorRepository(MyContext myContext)
        {
            _myContext = myContext;
            _dbset = myContext.Set<Colaborador>();
        }
        public async Task<IEnumerable<Colaborador>> BuscarColaboradoresAsync()
        {
            try
            {
                IQueryable<Colaborador> query = _myContext.Colaborador;
                query.OrderBy(c => c.Nome);
                return await query.ToArrayAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e + "Erro na busca dos Colaboradores");
            }
                      
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
