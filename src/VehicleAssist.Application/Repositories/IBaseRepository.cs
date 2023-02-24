using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleAssist.Application.Repositories
{
    public interface IBaseRepository<T>
    {
        IEnumerable<T> GetList();
        T GetById(object id);

        void Add(T entity);
        void Update(T entity);
        void DeleteById(object id);


    }
}
