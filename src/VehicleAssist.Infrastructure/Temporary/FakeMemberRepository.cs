using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Application.Repositories;
using VehicleAssist.Domain.Member;

namespace VehicleAssist.Infrastructure.Temporary
{
    public class FakeMemberRepository : IMemberRepository
    {

        public List<Member> Members { get; set; }

        public FakeMemberRepository()
        {
            Members = new List<Member>();
            Members.Add(new Member()
            {
                Email = "anoman@ik.com",
                FirstName = "An",
                LastName = " Oman",
                MemberID = 1

            });

            Members.Add(new Member()
            {
                Email = "spyxfam@anime.com",
                FirstName = "Anya",
                LastName = "Forger",
                MemberID = 2

            });
            Members.Add(new Member()
            {
                Email = "2spyxfam@anime.com",
                FirstName = "Loid",
                LastName = "Forger",
                MemberID = 3

            });
            Members.Add(new Member()
            {
                Email = "mrrobot@tvshow.com",
                FirstName = "Ram",
                LastName = "Elliot",
                MemberID = 4

            });
            Members.Add(new Member()
            {
                Email = "brbad@tvshow.com",
                FirstName = "Walter",
                LastName = "Hartwell-White",
                MemberID = 5

            });
            Members.Add(new Member()
            {
                Email = "test@test.com",
                FirstName = "Test",
                LastName = "Test",
                MemberID = 6
            });
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
