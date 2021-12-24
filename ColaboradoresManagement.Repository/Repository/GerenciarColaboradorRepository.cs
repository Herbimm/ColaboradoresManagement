using ColaboradoresManagement.Domain.Entity;
using ColaboradoresManagement.Domain.Interface.Repository;
using ColaboradoresManagement.Repository.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColaboradoresManagement.Repository.Repository
{
    public class GerenciarColaboradorRepository : IGerenciarColaboradorRepository
    {
        private readonly MyContext _myContext;
        public DbSet<Colaborador> _dbset { get; }

        public GerenciarColaboradorRepository(MyContext myContext)
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
        public async Task<Colaborador> BuscarColaboradorPorNomeAsync(string nome)
        {
            try
            {
                var buscarColaborador = _dbset.FirstOrDefault(c => c.Nome.Contains(nome));
                return buscarColaborador;
            }
            catch (Exception)
            {

                throw;
            }                  

        }      

        public async Task RemoverColaboradorAsync(Colaborador colaborador)
        {
            try
            {
                _dbset.Remove(colaborador);
                await _myContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        public async Task CadastrarColaboradorAsync(Colaborador colaborador)
        {
            try
            {
                var cadastrarColaborador = await _dbset.AddAsync(colaborador);
                await _myContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }            
        }
    }
}
