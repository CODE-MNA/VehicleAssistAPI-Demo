using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Application.Authentication.Interfaces;
using BC = BCrypt.Net.BCrypt;

namespace VehicleAssist.Infrastructure.Authentication
{
    public class PasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            string hashedPassword = BC.HashPassword(password);

            return hashedPassword;

        }

        public bool VerifyPassword(string hash,string password)
        {
            return BC.Verify(password, hash);
        }
    }
}
