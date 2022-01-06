
using Microsoft.EntityFrameworkCore;
using ProjetoFinaAPIRest.Data;
using ProjetoFinaAPIRest.Models;

namespace ProjetoFinaAPIRest.Services
{
    public class FotoPortifolioService
    {
        private readonly Contexto _contexto;

        public FotoPortifolioService(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<FotoPortifolio>> FindAllAsync()
        {
            return await _contexto.FotoPortifolio.ToListAsync();
        }

        public async Task InsertAsync(FotoPortifolio obj)
        {
            _contexto.Add(obj);
            await _contexto.SaveChangesAsync();
        }
        public async Task<FotoPortifolio> FindByIdAsync(int Id)
        {
            return await _contexto.FotoPortifolio
                    .FirstOrDefaultAsync(ob => ob.Id == Id);
        }

        public async Task RemoveAsync(int Id)
        {
            try
            {
                var obj = await _contexto.FotoPortifolio.FindAsync(Id);
                _contexto.FotoPortifolio.Remove(obj);
                await _contexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return;
            }
        }

        public async Task UpdateAsync(FotoPortifolio obj)
        {
            _contexto.Update(obj);
            await _contexto.SaveChangesAsync();
        }
    }
}
