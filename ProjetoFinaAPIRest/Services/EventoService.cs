using Microsoft.EntityFrameworkCore;
using ProjetoFinaAPIRest.Data;
using ProjetoFinaAPIRest.Models;

namespace ProjetoFinaAPIRest.Services
{
    public class EventoService
    {
        private readonly Contexto _contexto;

        public EventoService(Contexto contexto)
        {
            _contexto = contexto;
        }

     

        public async Task<List<Evento>> FindAllAsync()
        {
            return await _contexto.Evento.Include(ob=> ob.LocalEvento).ToListAsync();
        }

        public async Task InsertAsync(Evento obj)
        {
            _contexto.Add(obj);
            await _contexto.SaveChangesAsync();
        }
        public async Task<Evento> FindByIdAsync(int Id)
        {
            return await _contexto.Evento.
                Include(ob => ob.LocalEvento)
                .FirstOrDefaultAsync(ob => ob.Id == Id);
        }

        public async Task RemoveAsync(int Id)
        {
            try
            {
                var obj = await _contexto.Evento.FindAsync(Id);
                _contexto.Evento.Remove(obj);
                await _contexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return;
            }
        }

        public async Task UpdateAsync(Evento obj)
        {
            _contexto.Update(obj);
            await _contexto.SaveChangesAsync();
        }

        public async Task<List<Evento>> FindByDate()
        {
            var result = from obj in _contexto.Evento select obj;
            result = result.Where(x => x.DataFim >= DateTime.Now);
            return await result
                .Include(x => x.LocalEvento)
                .OrderBy(x=> x.DataInicio)
                .ToListAsync();
        }
    }
}
