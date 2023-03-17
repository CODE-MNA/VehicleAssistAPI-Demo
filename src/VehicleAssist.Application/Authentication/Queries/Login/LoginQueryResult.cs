using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VehicleAssist.Application.Authentication.Queries.Login
{
    public record LoginQueryResult
    {

        public int MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public string Username { get; set; }

        public string CellPhoneNumber { get; set; }
        public string CompanyName { get; set; }
        public string CompanyDescription { get; set; }

        public string MemberType { get; set; }

        public string Token { get; set; }

        public bool IsCompany { get; set; }
    }
}
