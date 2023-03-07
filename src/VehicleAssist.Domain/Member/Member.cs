using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleAssist.Domain.Member
{
    public class Member : BaseEntity
    {
       public int MemberId { get; protected set; }

        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }

        public string CellPhoneNumber { get; protected set; }

        public string? HomePhoneNumber { get; protected set; }

        public string Email { get; protected set; }

        public string UserName { get; protected set; }
        public string PasswordHash { get; protected set; }

        public bool UserActivated { get; protected set; }

        public DateTime? UserActivatedDate { get; protected set; }
        
        protected Member()
        {
          
        }



    

        protected static Member CreateMemberFromRegisterData(string username,string firstName, string lastName,
            string email, string phoneNumber, string passwordHash) 
        {

          

            Member member = new();
            member.FirstName = firstName;
            member.LastName = lastName;
            member.Email = email;
            member.PasswordHash = passwordHash;
            member.UserName = username;
            member.CellPhoneNumber = phoneNumber;

            //Member is instantiated as inactive
            member.UserActivated = false;
            member.UserActivatedDate = null;

            return member;


           


        }

        public void ActivateUser()
        {
            if (UserActivated == true) return;

            UserActivated = true;
            UserActivatedDate = DateTime.Now;

        }
             
        

    }
}
