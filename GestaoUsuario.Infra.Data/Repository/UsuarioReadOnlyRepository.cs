using GestaoUsuario.Domain.Interface.Repository;
using GestaoUsuario.Domain.Model;
using GestaoUsuario.Infra.Data.DataBase;
using GestaoUsuario.Infra.Data.DataBase.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoUsuario.Infra.Data.Repository
{
    public class UsuarioReadOnlyRepository : BaseRepositoryEF<Usuario, GestaoUsuarioContext>, IUsuarioReadOnlyRepository
    {
        public UsuarioReadOnlyRepository(GestaoUsuarioContext context) : base(context)
        {
        }

        public async Task<Usuario> ConsultarUsuarios(IQueryable<Usuario> query)
        {

            var resposta = await query.FirstOrDefaultAsync();

            return resposta;
        }
    }
}
