﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleAssist.Domain.Member.Exceptions
{
    public class LoginUserNotActivatedException : AbstractDomainException
    {
        public LoginUserNotActivatedException(string exception) : base(exception)
        {
        }
    }
}
