using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Application.Repositories;
using VehicleAssist.Domain;

namespace VehicleAssist.Infrastructure.Temporary
{
    public class FakeBaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected List<T> _list;

     
        public void Add(T entity)
        {
            
           _list.Add(entity);
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(object id)
        {
           T obj = GetById(id);

            _list.Remove(obj);

        }

        public virtual T GetById(object id)
        {
            return _list[(int)id];
        }

        public IEnumerable<T> GetList()
        {
            return _list.AsReadOnly();
        }

        public ICollection<T> GetList(Expression<Func<T, bool>>? expression = null)
        {
            throw new NotImplementedException();
        }

        public ICollection<T> GetList(Expression<Func<T, bool>>? expression, params string[] includedEntities)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
