using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Application.Repositories;
using VehicleAssist.Domain;

namespace VehicleAssist.Infrastructure.Data
{
    public class EFRepository<T> : IBaseRepository<T> where T : BaseEntity
    {

        protected readonly VehicleAssistDBContext _dbContext;

        public EFRepository(VehicleAssistDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(T entity)
        {
                _dbContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _dbContext.Remove(entity);
        }

        public T GetById(object id)
        {
          return _dbContext.Set<T>().Find(id);
        }

      
        public ICollection<T> GetList(Expression<Func<T, bool>>? expression)
        {
            if(expression == null)
            {
                return _dbContext.Set<T>().ToList().AsReadOnly();
            }

            return _dbContext.Set<T>().Where(expression).ToList().AsReadOnly();
        }

        public void Update(T entity)
        {
            _dbContext.Update(entity);
        }
    }
}
