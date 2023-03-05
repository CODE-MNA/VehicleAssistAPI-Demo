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
            _list.Add(Member.CreateMemberFromRegisterData("ABC", "DEF", "GHI@gmail.com", "Temp(abc)"));
            _list.Add(Member.CreateMemberFromRegisterData("doc", "ter", "docter@gmail.com", "Temp(doc)"));
            _list.Add(Member.CreateMemberFromRegisterData("test", "test", "test@test.com", "Temp(test)"));
        }


        public Member GetMemberByID(int id)
        {
            //throw not found exception
            return Members.Where(x => x.MemberID == id).FirstOrDefault();
        }

        public Member GetMemberByEmail(string email)
        {
            return Members.Where(x => email == x.Email).FirstOrDefault();
        }
    }
}
