using Microsoft.EntityFrameworkCore;
using ProjetoFinaAPIRest.Data;
using ProjetoFinaAPIRest.Models;

namespace ProjetoFinaAPIRest.Services
{
    public class PortifolioService
    {
        private readonly Contexto _contexto;

        public PortifolioService(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<Portifolio>> FindAllAsync()
        {
            return await _contexto.Portifolio.ToListAsync();
        }

        public async Task InsertAsync(Portifolio obj)
        {
            _contexto.Add(obj);
            await _contexto.SaveChangesAsync();
        }
        public async Task<Portifolio> FindByIdAsync(int Id)
        {
            return await _contexto.Portifolio.Include(obj => obj.FotosPortifolio)
                    .FirstOrDefaultAsync(ob => ob.Id == Id);
        }

        public async Task RemoveAsync(int Id)
        {
            try
            {
                var obj = await _contexto.Portifolio.FindAsync(Id);
                _contexto.Portifolio.Remove(obj);
                await _contexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return;
            }
        }

        public async Task UpdateAsync(Portifolio obj)
        {
            _contexto.Update(obj);
            await _contexto.SaveChangesAsync();
        }
    }
}
