using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleAssist.Domain.Company
{
    public class Company : Member.Member
    {

        public string CompanyName { get; set; }

        public string? CompanyDescription { get; set; }

        public List<CompanyService> CompanyServices { get; set; }

        public List<Deal> DealServices { get; set; }




        public static Company CreateCompanyFromRegisterData(string username, string firstName, string lastName,
          string email, string phoneNumber, string passwordHash,string companyName, string? companyDescription = null)
        {
          Member.Member member = CreateMemberFromRegisterData(username, firstName, lastName, email, phoneNumber, passwordHash);
                
                Company company = ConvertFromMember(member);

                company.CompanyName = companyName;
                company.CompanyDescription= companyDescription;

            return company;

        }

        public static Company ConvertFromMember(Member.Member member)
        {



            Company company = new Company()
            {
                MemberId = member.MemberId,
                FirstName = member.FirstName,
                LastName = member.LastName,
                Email = member.Email,
                PasswordHash = member.PasswordHash,
                CellPhoneNumber = member.CellPhoneNumber,
                HomePhoneNumber = member.HomePhoneNumber,
                UserName = member.UserName,
                UserActivatedDate = member.UserActivatedDate,
                UserActivated = member.UserActivated,



            };

            return company;
        }

    }
}
