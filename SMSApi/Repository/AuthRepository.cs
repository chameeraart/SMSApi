using SMSApi.Dto;
using SMSApi.Infrastructure;
using SMSApi.Models;
using SMSApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SMSApi.Repository
{
    public class AuthRepository : IAuth
    {
        private readonly SMSDbContext _context;

        public AuthRepository(SMSDbContext context)
        {
            this._context = context;
        }

        public UserDto Auth(LoginDto loginDto)
        {
            // TODO: Implement password encryption
            var hashedPassword = HashPassword(loginDto.Password); // Example hash function

            var user = _context.users
                .FirstOrDefault(t =>
                    t.username == loginDto.Username &&
                    t.password == hashedPassword &&
                    t.isactive
                );

            if (user == null)
            {
                throw new UnauthorizedAccessException("User name or Password Error");
            }

            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                };


            if (user.UserType == SMSApi.Models.User.UserTypes.Admin)
            {
                claims.Add(new Claim(ClaimTypes.Role, "admin"));
            }
            else
            {
                claims.Add(new Claim(ClaimTypes.Role, "user"));
            }

            var symmetricSecurityKey = new SymmetricSecurityKey(SessionManager.salt);
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(15), // Token expiry
                SigningCredentials = signingCredentials,
                Issuer = SessionManager.Issuer,
                Audience = SessionManager.Audiance
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            var userDto = new UserDto
            {
                JWT = tokenHandler.WriteToken(token),
                UserID = user.Id,
                JwtValidFrom = token.ValidFrom,
                JwtValidTo = token.ValidTo,
                TokenType = "bearer",
                userrole = user.UserType.ToString(),
                username = user.username,
                StudentId=user.studentid
            };

            return userDto;
        }

        private string HashPassword(string password)
        {
            // TODO: Implement password hashing algorithm
            // Example: return HashingLibrary.Hash(password);
            return password; // Placeholder, replace with actual hash
        }







    }
}
