using GestaoUsuario.Domain.Model;
using GestaoUsuario.Infra.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoUsuario.Domain.Interface.Repository
{
    public interface IUsuarioRepository : IBaseRepositoryEF<Usuario>
    {
        Task<Usuario> ConsultarPorLogin(string login);
        Task<Usuario> SelecionarPorID(long id);
        
    }
    public interface IUsuarioReadOnlyRepository : IBaseReadOnlyRepositoryEF<Usuario>
    {
        Task<Usuario> ConsultarUsuarios(IQueryable<Usuario> query);
    }
}