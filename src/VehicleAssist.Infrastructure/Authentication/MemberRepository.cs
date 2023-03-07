using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Application.Repositories;
using VehicleAssist.Domain.Company;
using VehicleAssist.Domain.Member;
using VehicleAssist.Infrastructure.Data;

namespace VehicleAssist.Infrastructure.Authentication
{
    public class MemberRepository : EFRepository<Member>, IMemberRepository
    {
        public MemberRepository(VehicleAssistDBContext dbContext) : base(dbContext)
        {
        }

        public T? FindMemberByUsername<T>(string username) where T : Member
        {
        

                List<T> members =  _dbContext.Set<T>().Where(m => m.UserName == username).ToList();
       

            


            
            return members.FirstOrDefault(defaultValue:null);

        }

        public Company? GetCompanyData(int id)
        {
           return _dbContext.Companies.Find(id);
        }

        public T? FindMemberByEmail<T>(string email) where T : Member
        {

            List<T> members = _dbContext.Set<T>().Where(m => m.Email == email).ToList();


            return members.FirstOrDefault(defaultValue: null);

        }


        

    }
}
