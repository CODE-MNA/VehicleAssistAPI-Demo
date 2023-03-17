using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Domain.Appointments;
using VehicleAssist.Domain.Member;
using VehicleAssist.Domain.Reminders;

namespace VehicleAssist.Domain.Customer
{
    public class Customer : Member.Member
    {

        public List<Appointment>? Appointments { get; private set; }
        public List<Vehicle>? Vehicles { get; private set; }
        public List<Reminder>? Reminders { get; private set; }

        //appointments

        //TODO : Take Parameters in this function
        public void AddNewVehicle(int vehicleId, string name, string? plateNumber, string? description, string? color, int? mileage, string? imageLink)
        {
            Vehicle vehicle = Vehicle.CreateVehicleFromInput( name, plateNumber, description, color, mileage, imageLink, this.MemberId);

            Vehicles.Add(vehicle);
        }


        public static Customer ConvertFromMember(Member.Member member)
        {



            Customer customer = new Customer()
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

            return customer;
        }

        public static Customer CreateCustomerFromRegisterData(string username, string firstName, string lastName,
              string email, string phoneNumber, string passwordHash)
        {

           Member.Member member = CreateMemberFromRegisterData(username,firstName,lastName,email,phoneNumber,passwordHash);

        

            
            

            return Customer.ConvertFromMember(member);
            //Customer


            //Company
            //extra



        }
    }
}
