using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleAssist.Domain.Member
{
    public class Member : BaseEntity
    {
        public Member()
        {
          
        }

        public static Member CreateMemberFromRegisterData(string firstName, string lastName, string email, string passwordHash)
        {
            Member member = new Member();
            member.FirstName = firstName;
            member.LastName = lastName;
            member.Email = email;
            member.PasswordHash = passwordHash;

            //Member is instantiated as inactive
            member.UserActivated = false;
            member.UserActivatedDate = null;

            return member;


            //Customer
 

            //Company
            //extra



        }

        public void ActivateUser()
        {
            if (UserActivated == true) return;

            UserActivated = true;
            UserActivatedDate = DateTime.Now;

        }
             

        public int MemberID { get => Id; set
            {
                Id = value;
            } }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }

        public string PasswordHash { get; private set; }

        public bool UserActivated { get; private set; }

        public DateTime? UserActivatedDate { get; private set; }

    }
}
