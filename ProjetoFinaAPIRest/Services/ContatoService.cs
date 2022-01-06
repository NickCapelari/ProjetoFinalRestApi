using Microsoft.EntityFrameworkCore;
using ProjetoFinaAPIRest.Data;
using ProjetoFinaAPIRest.Models;

namespace ProjetoFinaAPIRest.Services
{
    public class ContatoService
    {
        private readonly Contexto _contexto;

        public ContatoService(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<Contato>> FindAllAsync()
        {
            return await _contexto.Contato.ToListAsync();
        }
        public async Task InsertAsync(Contato obj)
        {
            _contexto.Add(obj);
            await _contexto.SaveChangesAsync();
        }
        public async Task<Contato> FindByIdAsync(int Id)
        {
            return await _contexto.Contato
                .FirstOrDefaultAsync(obj => obj.Id == Id);
        }

        public async Task RemoveAsync(int Id)
        {
            try
            {
                var obj = await _contexto.Contato.FirstOrDefaultAsync(x => x.Id == Id);
                _contexto.Contato.Remove(obj);
                await _contexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return;
            }
        }
        public async Task UpdateAsync(Contato Obj)
        {

            _contexto.Contato.Update(Obj);
            await _contexto.SaveChangesAsync();
        }
    }
}
