using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleAssist.Domain
{
    public abstract class BaseEntity
    {
        protected int _id;

        


        public int Id { get { return _id; } set { _id = value; } }
    }
}
