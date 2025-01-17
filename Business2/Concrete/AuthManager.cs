﻿using Business2.Abstract;
using Business2.Constans;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business2.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<Users> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new Users
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            return new SuccessDataResult<Users>(user, Messages.UserRegistered);
        }

        public IDataResult<Users> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByEmail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<Users>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<Users>(Messages.PasswordError);
            }

            return new SuccessDataResult<Users>(userToCheck.Data, Messages.SuccessfulLogin);
        }

        public IResults UserExists(string email)
        {
           
            
            if (_userService.GetByEmail(email).Data !=null)
       
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(Users user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims.Data);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }
        public IResults ChangePassword(UserForChangingPasswordDto userForChangingPasswordDto)
        {
            Users userInfos = _userService.GetById(userForChangingPasswordDto.Id).Data;

            if (!HashingHelper.VerifyPasswordHash(userForChangingPasswordDto.CurrentPassword,
                                                  userInfos.PasswordHash,
                                                  userInfos.PasswordSalt))
            {
                return new ErrorResult(Messages.CurrentPasswordIsWrong);
            }

            HashingHelper.CreatePasswordHash(userForChangingPasswordDto.NewPassword,
                                             out byte[] passwordHash,
                                             out byte[] passwordSalt);

            userInfos.PasswordHash = passwordHash;
            userInfos.PasswordSalt = passwordSalt;

            _userService.Update(userInfos);

            return new SuccessResult(Messages.PasswordUpdated);
        }
    }
}
