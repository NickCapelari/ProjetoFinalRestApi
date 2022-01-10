using Microsoft.EntityFrameworkCore;
using ProjetoFinaAPIRest.Data;
using ProjetoFinaAPIRest.Models;

namespace ProjetoFinaAPIRest.Services
{
    public class LocalEventoService
    {
        private readonly Contexto _contexto;

        public LocalEventoService(Contexto contexto)
        {
            _contexto = contexto;
        }
        public async Task<List<LocalEvento>> FindAllAsync()
        {
            return await _contexto.LocalEvento.ToListAsync();
        }
        public async Task InsertAsync(LocalEvento obj)
        {
            _contexto.Add(obj);
            await _contexto.SaveChangesAsync();
        }
        public async Task<LocalEvento> FindByIdAsync(int Id)
        {
            return await _contexto.LocalEvento
                .FirstOrDefaultAsync(obj => obj.Id == Id);
        }

        public async Task RemoveAsync(int Id)
        {
            try
            {
                var obj = await _contexto.LocalEvento.FirstOrDefaultAsync(x => x.Id == Id);
                _contexto.LocalEvento.Remove(obj);
                await _contexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return;
            }
        }
        public async Task UpdateAsync(LocalEvento Obj)
        {

            _contexto.LocalEvento.Update(Obj);
            await _contexto.SaveChangesAsync();
        }
    }
}
