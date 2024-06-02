using EtkinlikAPI.Models.Auth;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace EtkinlikAPI.Models
{
    public class EtkinlikTokenHandler
    {

        public static JWTToken CreateToken(string email)
        {

            var responseModel = new JWTToken();

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, email),
            };


            //simetrik security key
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("ironmaidenpentagramslipknotironmaidenpentagramslipknot"));


            //imzalama algoritması
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //token oluşturma
            responseModel.AccessTokenExpiration = System.DateTime.Now.AddMinutes(1);



            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
           issuer: "cagatay@mail.com",
           audience: "cagatay1@mail.com",
           expires: responseModel.AccessTokenExpiration,
           signingCredentials: credentials,
           claims: claims
           );

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            responseModel.AccessToken = tokenHandler.WriteToken(jwtSecurityToken);

            return responseModel;



        }
    }
}
