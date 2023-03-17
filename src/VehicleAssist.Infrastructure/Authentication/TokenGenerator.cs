using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Application.Authentication.Interfaces;
using VehicleAssist.Domain.Member;

namespace VehicleAssist.Infrastructure.Authentication
{
    public class TokenGenerator : ITokenGenerator
    {
        TokenConfiguration _tokenConfiguration;

        public TokenGenerator(IOptions<TokenConfiguration> tokenConfiguration)
        {
            _tokenConfiguration = tokenConfiguration.Value;
        }

        public string GenerateToken(Member member)
        {
            string email = member.Email;
            string userID = member.MemberId.ToString();
         
            List<Claim> claims = new List<Claim>();

            //Your Claims

            claims.Add(new Claim(JwtRegisteredClaimNames.Email, email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, userID));
            claims.Add(new Claim(type:"member_id", userID));
            claims.Add(new Claim(type:"user_activated", value:member.UserActivated.ToString()));
            claims.Add(new Claim(ClaimTypes.Role, member.MemberType.ToString()));
            //Create signer 
           byte[] keyBytes = Encoding.UTF8.GetBytes(_tokenConfiguration.Secret);
           SymmetricSecurityKey secretKey = new SymmetricSecurityKey(keyBytes);
           var signer = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

          
            var token = new JwtSecurityToken(issuer:_tokenConfiguration.Issuer,audience:_tokenConfiguration.Audience,
                claims,expires:DateTime.Now.AddMinutes(_tokenConfiguration.ExpiryMinutes),signingCredentials:signer);


            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
