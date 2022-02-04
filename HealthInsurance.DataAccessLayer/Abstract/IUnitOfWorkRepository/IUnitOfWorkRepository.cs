using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthInsurance.DataAccessLayer.Abstract.IGenericRepository;
using HealthInsurance.EntityLayer.Concrete.Bases;

namespace HealthInsurance.DataAccessLayer.Abstract.IUnitOfWorkRepository
{
    public interface IUnitOfWorkRepository : IDisposable
    {
        IGenericRepository<T> GetRepository<T>() where T : Entity;
        bool BeginTransaction();
        bool RollBackTransaction();
        int SaveChanges();
    }
}
