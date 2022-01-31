using GestaoUsuario.Domain.Interface.Repository;
using GestaoUsuario.Infra.Data.DataBase;
using GestaoUsuario.Infra.Data.DataBase.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoUsuario.Infra.Data.Repository
{
    public class UsuarioRepository : BaseRepositoryEF<Usuario, GestaoUsuarioContext>, IUsuarioRepository
    {
        public UsuarioRepository(GestaoUsuarioContext context) : base(context)
        {
        }

        public async Task<Usuario> SelecionarPorID(long id)
        {
            return await _dbSet
                .Where(x => x.ID == id)
                .FirstOrDefaultAsync();
        }

    
        public async Task<Usuario> ConsultarPorLogin(string login)
        {
            return await _dbSet
                .Where(x => x.Login == login)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}
