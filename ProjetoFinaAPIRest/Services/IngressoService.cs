using Microsoft.EntityFrameworkCore;
using ProjetoFinaAPIRest.Data;
using ProjetoFinaAPIRest.Models;

namespace ProjetoFinaAPIRest.Services
{
    public class IngressoService
    {
        private readonly Contexto _contexto;

        public IngressoService(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<Ingresso>> FindAllAsync()
        {
            return await _contexto.Ingresso.ToListAsync();
        }

        public async Task InsertAsync(Ingresso obj)
        {
            EventoService e = new EventoService(_contexto);
            Evento evento = await e.FindByIdAsync(obj.EventoId);

            TipoIngressoService t = new TipoIngressoService(_contexto);
            TipoIngresso tipoI = await t.FindByIdAsync(obj.TipoIngressoId);

            obj.CalculaValorIngresso(evento.Valor, tipoI.PercentualDesconto);
            _contexto.Add(obj);
            await _contexto.SaveChangesAsync();
        }
        public async Task<Ingresso> FindByIdAsync(int Id)
        {
            return await _contexto.Ingresso
                .FirstOrDefaultAsync(obj => obj.Id == Id);

        }

        public async Task RemoveAsync(int Id)
        {
            try
            {
                var obj = await _contexto.Ingresso.FirstOrDefaultAsync(x => x.Id == Id);
                _contexto.Ingresso.Remove(obj);
                await _contexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return;
            }
        }
        public async Task UpdateAsync(Ingresso Obj)
        {
            EventoService e = new EventoService(_contexto);
            Evento evento = await e.FindByIdAsync(Obj.EventoId);

            TipoIngressoService t = new TipoIngressoService(_contexto);
            TipoIngresso tipoI = await t.FindByIdAsync(Obj.TipoIngressoId);

            Obj.CalculaValorIngresso(evento.Valor, tipoI.PercentualDesconto);
            _contexto.Ingresso.Update(Obj);
            await _contexto.SaveChangesAsync();
        }
    }
}
