using Microsoft.EntityFrameworkCore;
using ProjetoFinaAPIRest.Data;
using ProjetoFinaAPIRest.Models;

namespace ProjetoFinaAPIRest.Services
{
    public class UsuarioService
    {
        private readonly Contexto _contexto;

       public UsuarioService()
        {

        }
        public UsuarioService(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<Usuario>> FindAllAsync()
        {
            return await _contexto.User.ToListAsync();
        }

        public async Task InsertAsync(Usuario obj)
        {
            _contexto.Add(obj);
            await _contexto.SaveChangesAsync();
        }
        public async Task<Usuario> FindByIdAsync(int Id)
        {
            return await _contexto.User
                    .FirstOrDefaultAsync(ob => ob.Id == Id);
        }
        public async Task<Usuario> FindByNameAsync(string login)
        {
            Contexto c = new Contexto();
            return await c.User
                    .FirstOrDefaultAsync(ob => ob.User == login);
        }
        public  Usuario FindByName(string login)
        {
            Contexto c = new Contexto();
            return  c.User
                    .FirstOrDefault(ob => ob.User == login);
        }

        public async Task RemoveAsync(int Id)
        {
            try
            {
                var obj = await _contexto.User.FindAsync(Id);
                _contexto.User.Remove(obj);
                await _contexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return;
            }
        }

        public async Task UpdateAsync(Usuario obj)
        {
            _contexto.Update(obj);
            await _contexto.SaveChangesAsync();
        }
    }
}
