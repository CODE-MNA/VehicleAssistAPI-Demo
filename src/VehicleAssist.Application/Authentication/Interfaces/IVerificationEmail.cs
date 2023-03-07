using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Domain.Member;

namespace VehicleAssist.Application.Authentication.Interfaces
{
    public interface IVerificationEmail
    {

        public  void SendVerificationEmail(Member member);
    }
}
