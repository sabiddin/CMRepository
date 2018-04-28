using CM.Application.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CM.Data
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public readonly IDboContext db;

        public BaseRepository(IDboContext db)
        {
            this.db = db;
        }

        public virtual TEntity FindById(int Id)
        {
            return db.Set<TEntity>().Find(new object[] { Id });
        }
        
        public virtual List<TEntity> FindAll()
        {
            return db.Set<TEntity>().ToList();
        }

        public virtual List<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            return db.Set<TEntity>().Where(predicate).ToList();
        }

        public virtual void Add(TEntity entity)
        {
            db.Set<TEntity>().Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            if (db.Entry(entity).State != EntityState.Added)
            {
                db.Entry(entity).State = EntityState.Modified;
            }
        }

        public virtual void Delete(TEntity entity)
        {
            db.Set<TEntity>().Remove(entity);
        }

        public virtual Task<TEntity> FindByIdAsync(int Id)
        {
            return db.Set<TEntity>().FindAsync(new object[] { Id });
        }

        public virtual async Task<List<TEntity>> FindByAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var query = db.Set<TEntity>().Where(predicate);
            return await query.ToListAsync();
        }
    }
}
