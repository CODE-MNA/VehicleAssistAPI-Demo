using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Domain;

namespace VehicleAssist.Application.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        ICollection<T> GetList(Expression<Func<T, bool>>? expression = null);
        ICollection<T> GetList(Expression<Func<T, bool>>? expression, params string[] includedEntities);
        T? GetById(object id);

        void Add(T entity);

        void Update(T entity);
        void Delete(T entity);

       

    }
}
