using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Domain;
using VehicleAssist.Domain.Member;

namespace VehicleAssist.Application.Repositories
{
    public interface IMemberRepository
    {
        public Member GetMemberByID(int id);

        public Member GetMemberByEmail(string email);
    }
}
