using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HealthInsurance.DataAccessLayer.Abstract.IGenericRepository;
using HealthInsurance.EntityLayer.Concrete.Bases;
using Microsoft.EntityFrameworkCore;

namespace HealthInsurance.DataAccessLayer.Concrete.EntityFramework.EfGenericRepository
{
    public class EfGenericRepository<T> : IGenericRepository<T> where T : Entity
    {
        #region Variables
        protected readonly DbContext context;
        protected readonly DbSet<T> set;
        #endregion


        #region Contructor
        public EfGenericRepository(DbContext context)
        {
            this.context = context;
            this.set = this.context.Set<T>();
            //TODO : Lazy loading tru olduğu için iptal edildi.
            //this.context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        #endregion

        #region Methods
        public T Add(T entity)
        {
            context.Entry(entity).State = EntityState.Added;
            set.Add(entity);
            return entity;
        }

        public bool Delete(int id)
        {
            return Delete(Find(id));
        }

        public bool Delete(T entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                context.Attach(entity);
            }
            return set.Remove(entity) != null;
        }

        public T Find(int id)
        {
            return set.Find(id);
        }

        public List<T> GetAll()
        {
            return set.ToList();
        }
        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return set.Where(expression);
        }

        public T Update(T entity)
        {
            set.Update(entity);
            return entity;
        }
        #endregion
    }
}
