using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleAssist.Application.Repositories
{
    public interface IUnitOfWork
    {
        public void CommitChanges();

        public Task CommitChangesAsync();
    }
}
