using AutoMapper;
using AutoMapper.QueryableExtensions;
using BlazorApp1.Server.Data.Context;
using BlazorApp1.Server.Data.Models;
using BlazorApp1.Server.Services.Infrastruce;
using BlazorApp1.Shared.DTO;
using BlazorApp1.Shared.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Server.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly MealOrderingDbContext _context;
        private readonly IConfiguration _configuration;

        public UserService(IMapper mapper, MealOrderingDbContext context, IConfiguration configuration)
        {
            _mapper = mapper;
            _context = context;
            _configuration = configuration;
        }

        public async Task<UserDto> CreateUser(UserDto user)
        {
            var dbUser = await _context.Users.Where(i => i.Id == user.Id).FirstOrDefaultAsync();
            if (dbUser != null)
                throw new Exception("ilgili kayit zaten mevcut");

            dbUser = _mapper.Map<User>(user);
            await _context.Users.AddAsync(dbUser);
            int result = await _context.SaveChangesAsync();

            return _mapper.Map<UserDto>(dbUser);
        }

        public async Task<bool> DeleteUserById(Guid id)
        {
            var dbUser = await _context.Users.FirstOrDefaultAsync(i => i.Id == id);
            if (dbUser == null)
                throw new Exception("user not found");

            _context.Users.Remove(dbUser);
            int result = await _context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<UserDto> GetUserById(Guid id)
        {
            return await _context.Users
                .Where(i => i.Id == id)
                .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<List<UserDto>> GetUsers()
        {
            return await _context.Users
                .Where(i => i.IsActive)
                .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<UserLoginResponseDto> Login(string EMail, string Password)
        {
            // veritabanı kullanıcı doğrulam işlemleri

            var encryptedPassword = PasswordEncrypter.Encrypt(Password);

            var dbUser = await _context.Users.FirstOrDefaultAsync(i => i.EmailAddress == EMail && i.Password == encryptedPassword);

            if (dbUser == null)
                throw new Exception("User not found or given information is wrong");

            if (!dbUser.IsActive)
                throw new Exception("User state is Passive!");


            UserLoginResponseDto result = new UserLoginResponseDto();

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSecurityKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.Now.AddDays(int.Parse(_configuration["JwtExpiryInDays"].ToString()));

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, EMail),
                new Claim(ClaimTypes.Name, dbUser.FirstName + " " + dbUser.LastName),
                new Claim(ClaimTypes.UserData, dbUser.Id.ToString())
            };

            var token = new JwtSecurityToken(_configuration["JwtIssuer"], _configuration["JwtAudience"], claims, null, expiry, creds);

            result.ApiToken = new JwtSecurityTokenHandler().WriteToken(token);
            result.User = _mapper.Map<UserDto>(dbUser);

            return result;
        }

        public async Task<UserDto> UpdateUser(UserDto user)
        {
            var dbUser = await _context.Users.Where(i => i.Id == user.Id).FirstOrDefaultAsync();
            if (dbUser == null)
                throw new Exception("user not found");

            _mapper.Map(user, dbUser);
            int result = await _context.SaveChangesAsync();

            return _mapper.Map<UserDto>(dbUser);
        }
    }
}
