using Business.Abstract;
using Core.Entities.Concrate;
using Core.Security.Hashing;
using Core.Security.jwt;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthManager
    {
        private readonly IUserManager _userManager;

        public AuthManager(IUserManager userManager)
        {
            _userManager = userManager;
        }

        public string Login(LoginDto loginDto)
        {
            var checkUser = _userManager.GetByEmai(loginDto.Email);
            if (checkUser == null)
            {
                return null;

            }

            var checkPassword = HashingHelper.Verify(loginDto.Password, checkUser.PasswordHash, checkUser.PasswordSalt);
            if (!checkPassword)

                return null;

            var token = TokenGenator.Token(checkUser, "User");

            return token;



        }

        public void Register(RegisterDto registerDto)
        {

            byte[] passwordHash, passwordSalt;
            HashingHelper.HashPassword(registerDto.Password, out passwordHash, out passwordSalt);
            User user = new()
            {
                 Email = registerDto.Email,
                 Name= registerDto.Name,
                 PasswordHash=passwordHash,
                 PasswordSalt=passwordSalt,
                 SurName=registerDto.Surname,


            };
            _userManager.Add(user);
        }
    }
} 
