using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Application.Repositories;

namespace VehicleAssist.Infrastructure.Temporary
{
    //Use the IUnitOfWork interface and add it to the 
    //DBContext you are going to make later
    public class TempUoW : IUnitOfWork
    {
        public void CommitChanges()
        {
            Console.WriteLine("Saved Changes!");
        }
    }
}
