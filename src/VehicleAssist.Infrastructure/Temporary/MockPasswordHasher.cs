using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Application.Authentication.Interfaces;

namespace VehicleAssist.Infrastructure.Temporary
{
    public class MockPasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            return $"Temp({password})";
        }

        public bool VerifyPassword(string hash, string password)
        {

            if(hash == $"Temp({password})")
            {
                return true;
            }
            return false;

        }
    }
}
