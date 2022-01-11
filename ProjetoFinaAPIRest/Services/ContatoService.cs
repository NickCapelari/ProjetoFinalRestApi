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
            return await _contexto.Usuario.ToListAsync();
        }
        public async Task InsertAsync(Contato obj)
        {
            _contexto.Add(obj);
            await _contexto.SaveChangesAsync();
        }
        public async Task<Contato> FindByIdAsync(int Id)
        {
            return await _contexto.Usuario
                .FirstOrDefaultAsync(obj => obj.Id == Id);
        }

        public async Task RemoveAsync(int Id)
        {
            try
            {
                var obj = await _contexto.Usuario.FirstOrDefaultAsync(x => x.Id == Id);
                _contexto.Usuario.Remove(obj);
                await _contexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return;
            }
        }
        public async Task UpdateAsync(Contato Obj)
        {

            _contexto.Usuario.Update(Obj);
            await _contexto.SaveChangesAsync();
        }
    }
}
