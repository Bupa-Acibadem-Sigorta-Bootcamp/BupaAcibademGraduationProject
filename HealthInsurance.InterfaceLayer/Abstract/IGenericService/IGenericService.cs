using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HealthInsurance.EntityLayer.Abstract.IBases;
using HealthInsurance.EntityLayer.Abstract.IResults;

namespace HealthInsurance.InterfaceLayer.Abstract.IGenericService
{
    public interface IGenericService<T, TDto> where T : IEntity where TDto : IDto
    {
        IResult Add(TDto entity, bool saveChanges = true);
        IDataResult<Task<TDto>> AddAsync(TDto entity);
        IDataResult<bool> DeleteById(int id, bool saveChanges = true);
        IDataResult<Task<bool>> DeleteByIdAsync(int id);
        IDataResult<bool> Delete(TDto entity);
        IDataResult<Task<bool>> DeleteAsync(TDto entity);
        IDataResult<TDto> Update(TDto entity);
        IDataResult<Task<TDto>> UpdateAsync(TDto entity);
        IDataResult<TDto> Find(int id);
        IDataResult<IQueryable<T>> GetIQueryable();
        IDataResult<List<TDto>> GetAll();
        IDataResult<List<TDto>> GetAll(Expression<Func<T, bool>> expression);
        void Save();
    }
}
