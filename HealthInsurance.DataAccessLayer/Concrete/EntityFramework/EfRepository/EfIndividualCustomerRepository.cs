using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthInsurance.DataAccessLayer.Abstract.IRepository;
using HealthInsurance.DataAccessLayer.Concrete.EntityFramework.EfGenericRepository;
using HealthInsurance.EntityLayer.Concrete.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthInsurance.DataAccessLayer.Concrete.EntityFramework.EfRepository
{
    public class EfIndividualCustomerRepository : EfGenericRepository<IndividualCustomer>, IIndividualCustomerRepository
    {
        public EfIndividualCustomerRepository(DbContext context) : base(context)
        {
        }
    }
}
