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
using VehicleAssist.Infrastructure.Email;

namespace VehicleAssist.Infrastructure.Authentication
{
    public class VerificationEmail : IVerificationEmail
    {
        IMailService _mailService;
        MailSettings _mailSettings;

        public VerificationEmail(IMailService mailService, IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
            _mailService = mailService;
        }

        public async void SendVerificationEmail(Member member)
        {
            MailRequest mailRequest = new MailRequest();

            mailRequest.ToEmail = member.Email;

            mailRequest.Subject = "Activation link your account for Vehicle Assist!";

            Dictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.Add("Username", member.UserName);


            string link = GenerateLink(member); 

            parameters.Add("Link",link);
            mailRequest.Arguments = parameters;

            mailRequest.BodyRazorTemplate = $"Hey @Model.Username, Click <a href=@Model.Link> Here</a> To Activate account.";

            try
            {
          await  _mailService.SendMailAsync(mailRequest);

            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }



        public string GenerateLink(Member member)
        {
            string email = member.Email;
            string userID = member.MemberId.ToString();
            string userName = member.UserName;
           

            List<Claim> claims = new List<Claim>();

            //Your Claims

            claims.Add(new Claim(JwtRegisteredClaimNames.Email, email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, userID));
            //Create signer 
            byte[] keyBytes = Encoding.UTF8.GetBytes(_mailSettings.VerifySecret);
            SymmetricSecurityKey secretKey = new SymmetricSecurityKey(keyBytes);
            var signer = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);



           JwtHeader header=  new JwtHeader(signer);
            JwtPayload payload = new JwtPayload(claims);


            var tokenString =  new JwtSecurityTokenHandler().WriteToken(new JwtSecurityToken(header,payload));

            return "http://localhost:8080/auth/local/activate/" + tokenString;
        }
    }
}
