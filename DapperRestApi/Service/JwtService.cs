using DapperRestApi.DTO.ReqDto;
using DapperRestApi.DTO.ResDto;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace DapperRestApi.Service
{
    public class JwtService : IJwtservice
    {
        private readonly IConfiguration config;
        public JwtService(IConfiguration _configuration)
        {
            config = _configuration;    
        }
        public AuthendicationResponse CreateJwtToken(UserDto userDto)
        {
            DateTime expiration = DateTime.UtcNow.AddMinutes(Convert.ToDouble(config["Jwt:ExpirationMinutes"]));

            Claim[] claim = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,userDto.userId.ToString()),// UserId *
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),// Unique Jwt Id * 
                new Claim(JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),// Issued time of the token *
                new Claim(ClaimTypes.NameIdentifier,userDto.Email),
                //new Claim(ClaimTypes.Name,userDto.userId)
            };
            // Get Encoding of our secret key
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            // Secure the key by using cryphtography Algorithms
            SigningCredentials Securekey = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            // Create token
            JwtSecurityToken tokenPayload = new JwtSecurityToken(
                config["Jwt:Issuer"],config["Jwt:Issuer"],claim,null,expires: expiration,Securekey);
            // Generate token 
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            string token = tokenHandler.WriteToken(tokenPayload); 

            return new AuthendicationResponse() 
            { Token = token, Email = userDto.Email,UserName = userDto.Email,Expiration = expiration};
        }
    }
}
