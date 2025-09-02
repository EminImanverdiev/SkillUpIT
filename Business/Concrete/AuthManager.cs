using Business.Abstract;
using Business.Contants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using DataAccess.Concrete.Database;
using Entities.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;
        private readonly AppDbContext _db;
        public AuthManager(IUserService userService, ITokenHelper tokenHelper, AppDbContext db)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _db = db;
        }

        public IDataResult<User> Register(UserForRegisterDto dto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            var user = new User
            {
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };

            using var tx = _db.Database.BeginTransaction();
            try
            {
                _db.Users.Add(user);
                _db.SaveChanges();

                var student = _db.OperationClaims.FirstOrDefault(x => x.Name == "Student");
                if (student == null)
                {
                    student = new OperationClaim { Id = Guid.NewGuid(), Name = "Student" };
                    _db.OperationClaims.Add(student);
                    _db.SaveChanges();
                }

                var exists = _db.UserOperationClaims
                    .Any(x => x.UserId == user.Id && x.OperationClaimId == student.Id);

                if (!exists)
                {
                    _db.UserOperationClaims.Add(new UserOperationClaim
                    {
                        Id = Guid.NewGuid(),
                        UserId = user.Id,
                        OperationClaimId = student.Id
                    });
                    _db.SaveChanges();
                }

                tx.Commit();
                return new SuccessDataResult<User>(user, Messages.UserRegistered);
            }
            catch (Exception ex)
            {
                tx.Rollback();
                return new ErrorDataResult<User>(user, "Register failed: " + ex.Message);
            }
        }


        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }
    }
}