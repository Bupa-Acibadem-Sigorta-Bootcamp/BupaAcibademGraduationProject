using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HealthInsurance.BusinessLogicLayer.Concrete.MapperConfiguration;
using HealthInsurance.BusinessLogicLayer.Concrete.ResultMessages;
using HealthInsurance.DataAccessLayer.Abstract.IGenericRepository;
using HealthInsurance.DataAccessLayer.Abstract.IUnitOfWorkRepository;
using HealthInsurance.EntityLayer.Abstract.IResults;
using HealthInsurance.EntityLayer.Concrete.Bases;
using HealthInsurance.EntityLayer.Concrete.Results;
using HealthInsurance.InterfaceLayer.Abstract.IGenericService;
using Microsoft.Extensions.DependencyInjection;

namespace HealthInsurance.BusinessLogicLayer.Concrete.BusinessLogicLayerBase
{
    public class BusinessLogicBase<T, TDto> : IGenericService<T, TDto> where T : Entity where TDto : Dto
    {
        #region Variables

        private readonly IUnitOfWorkRepository unitOfWork;
        private readonly IServiceProvider service;
        protected readonly IGenericRepository<T> repository;

        #endregion

        #region Constructors
        public BusinessLogicBase(IServiceProvider service)
        {
            unitOfWork = service.GetService<IUnitOfWorkRepository>();
            repository = unitOfWork.GetRepository<T>();
            this.service = service;
        }

        #endregion
        public IDataResult<TDto> Add(TDto entity, bool saveChanges = true)
        {
            try
            {
                var resolvedResult = " ";
                var TResult = repository.Add(ObjectMapper.Mapper.Map<T>(entity));
                resolvedResult = string.Join(',', TResult.GetType().GetProperties()
                    .Select(x => $"-{x.Name}: {x.GetValue(TResult) ?? ""}-"));
                if (saveChanges)
                {
                    Save();
                }

                return new SuccessDataResult<TDto>(ObjectMapper.Mapper.Map<T, TDto>(TResult), Messages.ProductAdded);
            }
            catch (Exception)
            {
                return new ErrorDataResult<TDto>(Messages.ProductAddingWrong);
            }
        }

        public  Task<IDataResult<TDto>> AddAsync(TDto entity, bool saveChanges = true)
        {

            return Task<IDataResult<TDto>>.Factory.StartNew(() =>
            {
                try
                {
                    var resolvedResult = " ";
                    var TResult = repository.Add(ObjectMapper.Mapper.Map<T>(entity));
                    resolvedResult = string.Join(',', TResult.GetType().GetProperties()
                        .Select(x => $"-{x.Name}: {x.GetValue(TResult) ?? ""}-"));
                    if (saveChanges)
                    {
                        Save();
                    }

                    return new SuccessDataResult<TDto>(ObjectMapper.Mapper.Map<T, TDto>(TResult),
                        Messages.ProductAddedAsync);
                }
                catch (Exception)
                {
                    return new ErrorDataResult<TDto>(null, Messages.ProductAddingAsycnWrong);
                }
            });
        }

        public IDataResult<bool> DeleteById(int id, bool saveChanges = true)
        {
            try
            {
                repository.Delete(id);
                if (saveChanges) Save();
                return new SuccessDataResult<bool>(true, Messages.ProductDeleted);
            }
            catch (Exception)
            {
                return new ErrorDataResult<bool>(false, Messages.ProductNotDeleted!);
            }
        }

        public IDataResult<Task<bool>> DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<bool> Delete(TDto entity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Task<bool>> DeleteAsync(TDto entity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<TDto> Update(TDto entity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Task<TDto>> UpdateAsync(TDto entity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<TDto> Find(int id)
        {
            try
            {
                return new SuccessDataResult<TDto>(ObjectMapper.Mapper.Map<T, TDto>(repository.Find(id)), Messages.ProductListedById);
            }
            catch (Exception)
            {
                return new ErrorDataResult<TDto>(null, Messages.ProductNotListedById);
            }
        }

        public IDataResult<IQueryable<T>> GetIQueryable()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<TDto>> GetAll()
        {
            try
            {
                List<T> getAllList = repository.GetAll();
                var dtoGetAllList = getAllList.Select(x => ObjectMapper.Mapper.Map<TDto>(x)).ToList();
                return new SuccessDataResult<List<TDto>>(dtoGetAllList, Messages.ProductsListed);
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<TDto>>(Messages.ProductsNotListed);
            }
        }

        //TODO : Tipin belli olduğu yerde kullanılabilir.
        public IDataResult<List<TDto>> GetAll(Expression<Func<T, bool>> expression)
        {
            try
            {
                List<T> getAllList = repository.GetAll(expression).ToList();
                var dtoGetAllList = getAllList.Select(x => ObjectMapper.Mapper.Map<TDto>(x)).ToList();
                return new SuccessDataResult<List<TDto>>(dtoGetAllList, Messages.ProductsListed);
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<TDto>>(Messages.ProductsNotListed);
            }

        }

        public void Save()
        {
            unitOfWork.SaveChanges();
        }
    }
}
