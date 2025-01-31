﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HealthInsurance.EntityLayer.Abstract.IBases;

namespace HealthInsurance.DataAccessLayer.Abstract.IGenericRepository
{
    public interface IGenericRepository<T> where T : IEntity
    {
        T Add(T entity);
        bool Delete(int id);
        bool Delete(T entity);
        T Update(T entity);
        T Find(int id);
        List<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>> expression);
    }
}
