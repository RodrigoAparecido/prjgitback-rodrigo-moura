using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GestaoUsuario.Infra.Data.DataBase
{
    public class BaseRepositoryEF<TEntity, TContext> where TEntity : class where TContext : DbContext
    {
        public TContext _context;
        internal DbSet<TEntity> _dbSet;

        public BaseRepositoryEF(TContext context)
        {
            context.ChangeTracker.LazyLoadingEnabled = false;

            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task Incluir(TEntity entity)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
        }

        public IQueryable<TEntity> ConsultarPelaExpressao(Expression<Func<TEntity, bool>> expression)
        {
            return _dbSet.Where(expression)
                .AsNoTracking();
        }
    }
}
