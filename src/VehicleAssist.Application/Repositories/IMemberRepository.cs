using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Domain;
using VehicleAssist.Domain.Company;
using VehicleAssist.Domain.Member;

namespace VehicleAssist.Application.Repositories
{
    public interface IMemberRepository : IBaseRepository<Member>
    {
        public T? FindMemberByUsername<T>(string username) where T : Member;
        public Company GetCompanyData(int id);
        public T? FindMemberByEmail<T>(string email) where T : Member;

    }
}
