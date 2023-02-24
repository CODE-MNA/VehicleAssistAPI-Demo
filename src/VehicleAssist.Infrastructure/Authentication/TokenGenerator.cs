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

namespace VehicleAssist.Infrastructure.Authentication
{
    public class TokenGenerator : ITokenGenerator
    {
        TokenConfiguration _tokenConfiguration;

        public TokenGenerator(IOptions<TokenConfiguration> tokenConfiguration)
        {
            _tokenConfiguration = tokenConfiguration.Value;
        }

        public string GenerateToken(int userID, string email)
        {
         
            List<Claim> claims = new List<Claim>();

            //Your Claims

            claims.Add(new Claim(JwtRegisteredClaimNames.Email, email));



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
