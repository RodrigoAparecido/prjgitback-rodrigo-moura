using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GestaoUsuario.Domain.Interface.Repository
{
    public interface IBaseRepositoryEF<TEntity> where TEntity : class
    {
        Task Incluir(TEntity entity);
    }

    public interface IBaseReadOnlyRepositoryEF<TEntity> where TEntity : class
    {
        IQueryable<TEntity> ConsultarPelaExpressao(Expression<Func<TEntity, bool>> expression);

    }
}
