using bscApi.Models;
using Microsoft.EntityFrameworkCore;

namespace bscApi.Repository
{
    public class UserRepository
    {
        private readonly bscContext _context;

        public UserRepository(bscContext context)
        {
            _context = context;
        }

        public async Task<Boolean> AddUser(int id, int idPerfil)
        {
            try
            {
                var person = await _context.Personas.Where(x => x.IdPersona == id).FirstOrDefaultAsync();
                var statusAct = await _context.CatEstatusUsuarios.Where(x => x.EstatusUsuarios == "Activo").Select(x => x.IdEstatusUsuario).FirstOrDefaultAsync();
                var newUser = new Usuario();
                newUser.IdPersona = id;
                newUser.IdPerfil = idPerfil;
                newUser.IdEstatusUsuario = statusAct;

                _context.Usuarios.Add(newUser);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}
