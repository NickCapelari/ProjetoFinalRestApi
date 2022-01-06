using Microsoft.EntityFrameworkCore;
using ProjetoFinaAPIRest.Data;
using ProjetoFinaAPIRest.Models;

namespace ProjetoFinaAPIRest.Services
{
    public class PessoaService
    {
        private readonly Contexto _contexto;

        public PessoaService(Contexto contexto)
        {
            _contexto = contexto;
        }


        public async Task<List<Pessoa>> FindAllAsync()
        {
            return await _contexto.Pessoa.Include(obj => obj.Contatos).ToListAsync();
        }


        public async Task InsertAsync(Pessoa obj)
        {
            obj.Contatos = new List<Contato>();
            _contexto.Add(obj);
            await _contexto.SaveChangesAsync();
        }

        public async Task<Pessoa> FindByIdAsync(int Id)
        {
            return await _contexto.Pessoa
                .Include(obj => obj.Contatos)
                .FirstOrDefaultAsync(obj => obj.Id == Id);
        }

        public async Task RemoveAsync(int Id)
        {
            try
            {
                var obj = await _contexto.Pessoa.FindAsync(Id);
                _contexto.Pessoa.Remove(obj);
                await _contexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return;
            }
        }

        public async Task UpdateAsync(Pessoa obj)
        {
            _contexto.Update(obj);
            await _contexto.SaveChangesAsync();
        }
    }
}
