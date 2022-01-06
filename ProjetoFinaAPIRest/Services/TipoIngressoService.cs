using Microsoft.EntityFrameworkCore;
using ProjetoFinaAPIRest.Data;
using ProjetoFinaAPIRest.Models;

namespace ProjetoFinaAPIRest.Services
{
    public class TipoIngressoService
    {
        private readonly Contexto _contexto;

        public TipoIngressoService(Contexto contexto)
        {
            _contexto = contexto;
        }

        public TipoIngressoService()
        {
        }

        public async Task<List<TipoIngresso>> FindAllAsync()
        {
            return await _contexto.TipoIngresso.ToListAsync();
        }
        public async Task InsertAsync(TipoIngresso obj)
        {
            _contexto.Add(obj);
            await _contexto.SaveChangesAsync();
        }
        public async Task<TipoIngresso> FindByIdAsync(int Id)
        {
            return await _contexto.TipoIngresso
            .FirstOrDefaultAsync(obj => obj.Id == Id);
        }

        public async Task RemoveAsync(int Id)
        {
            try
            {
                var obj = await _contexto.TipoIngresso.FindAsync(Id);
                _contexto.TipoIngresso.Remove(obj);
                await _contexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return;
            }
        }
        public async Task UpdateAsync(TipoIngresso obj)
        {

            _contexto.Update(obj);
            await _contexto.SaveChangesAsync();
        }
    }
}
