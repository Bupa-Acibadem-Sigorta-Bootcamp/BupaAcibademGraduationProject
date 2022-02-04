using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthInsurance.DataAccessLayer.Abstract.IGenericRepository;
using HealthInsurance.DataAccessLayer.Abstract.IUnitOfWorkRepository;
using HealthInsurance.DataAccessLayer.Concrete.EntityFramework.EfGenericRepository;
using HealthInsurance.EntityLayer.Concrete.Bases;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace HealthInsurance.DataAccessLayer.Concrete.EntityFramework.EfUnitOfWorkRepository
{
    public class EfUnitOfWorkRepository : IUnitOfWorkRepository
    {
        #region Variables

        private readonly DbContext context;
        private IDbContextTransaction transaction;
        bool dispose;

        public EfUnitOfWorkRepository(DbContext context)
        {
            this.context = context;
        }

        #endregion
        public IGenericRepository<T> GetRepository<T>() where T : Entity
        {
            return new EfGenericRepository<T>(context);
        }

        public bool BeginTransaction()
        {
            try
            {
                transaction = context.Database.BeginTransaction();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RollBackTransaction()
        {
            try
            {
                transaction.Rollback();
                transaction = null;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int SaveChanges()
        {
            var _transaction = this.transaction != null ? this.transaction : context.Database.BeginTransaction();
            using (_transaction)
            {
                try
                {
                    if (context == null)
                    {
                        throw new ArgumentException("Context is null");
                    }
                    int result = context.SaveChanges();
                    _transaction.Commit();
                    return result;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new Exception("Error on save changes", e);
                }
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.dispose)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.dispose = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

