using System;
using System.Collections.Generic;
using System.Linq;
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

        public void DeleteById(object id)
        {
           T obj = GetById(id);

            _list.Remove(obj);

        }

        public T GetById(object id)
        {
            return _list.Where((T x )=> x.Id == (int)id).First();
        }

        public IEnumerable<T> GetList()
        {
            return _list.AsReadOnly();
        }

        public void Update(T entity)
        {
            int entityID = entity.Id;
            DeleteById(entityID);

            Add(entity);
        }
    }
}
