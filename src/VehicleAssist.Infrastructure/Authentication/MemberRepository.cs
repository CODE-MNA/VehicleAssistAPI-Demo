using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Application.Repositories;
using VehicleAssist.Domain.Member;
using VehicleAssist.Infrastructure.Data;

namespace VehicleAssist.Infrastructure.Authentication
{
    public class MemberRepository : EFRepository<Member>, IMemberRepository
    {
        public MemberRepository(VehicleAssistDBContext dbContext) : base(dbContext)
        {
        }

        public Member? FindMemberByUsername(string username)
        {
        
                List<Member> members =  _dbContext.Members.Where(m => m.UserName == username).ToList();
       
            
            return members.FirstOrDefault(defaultValue:null);

        }


        public Member? FindMemberByEmail(string email)
        {

            List<Member> members = _dbContext.Members.Where(m => m.UserName == email).ToList();


            return members.FirstOrDefault(defaultValue: null);

        }
    }
}
