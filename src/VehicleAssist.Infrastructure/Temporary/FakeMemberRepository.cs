using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Application.Repositories;
using VehicleAssist.Domain.Member;

namespace VehicleAssist.Infrastructure.Temporary
{
    public class FakeMemberRepository : FakeBaseRepository<Member>,IMemberRepository
    {

        public List<Member> Members { get => GetList().ToList(); }

        public FakeMemberRepository()
        {
          _list = new List<Member>();

            InitializeFakeData();
        }

        void InitializeFakeData()
        {
        }


      

        public Member FindMemberByEmail(string email)
        {
            return Members.Where(x => email == x.Email).FirstOrDefault();
        }
    }
}
