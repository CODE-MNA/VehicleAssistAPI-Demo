using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleAssist.Domain
{
    public class AbstractDomainException : Exception
    {
        public string ExceptionName
        {
            get
            {
                return this.GetType().Name;
            }
        }

        public AbstractDomainException(string exception) : base(exception)
        {

        }
    }
}
