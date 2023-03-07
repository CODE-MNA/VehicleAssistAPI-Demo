﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Domain;
using VehicleAssist.Domain.Member;

namespace VehicleAssist.Application.Repositories
{
    public interface IMemberRepository : IBaseRepository<Member>
    {
        public Member? FindMemberByEmail(string email);
    }
}
