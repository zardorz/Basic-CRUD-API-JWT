using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using WebApi.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using WebApi.Repositories;

namespace WebApi.Services
{

    public interface IAuthorizationService
    {
        Models.Authorization Authenticate(string username, string password);
        bool LogOut(Guid sessionID);
    }

    public class AuthorizationService : IAuthorizationService
    {
        private readonly AppSettings _appSettings;
        private readonly IUserService _userService;
        private readonly ISessionService _sessionService;

        //public AuthorizationService( AppSettings appSettings)
        public AuthorizationService(AppSettings appSettings, IUserService userService, ISessionService sessionService)
        {
            //UserService userService = null;
            _appSettings = appSettings;
            _userService = userService;
            _sessionService = sessionService;
        }

        public Models.Authorization Authenticate(string username, string password)
        {

            var user = _userService.GetAll().SingleOrDefault(x => x.Username == username ); //&& x.Password == password

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var sessionId = Guid.NewGuid();
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var dtCreated = DateTime.Now;
            var dtExpire = dtCreated.AddDays(7);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = dtExpire,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            //Cria a session no DB
            _sessionService.Add(new Entities.Session()
            {
                DtCreated = dtCreated,
                DtExpire = dtExpire,
                UserID = user.Id,
                Id = sessionId
            });

            return new Models.Authorization()
            {
                AccessToken = tokenHandler.WriteToken(token),
                FirstName = user.FirstName,
                SessionId = sessionId
            };
        }
    
        public bool LogOut(Guid sessionID)
        {
            return _sessionService.Expire(sessionID);
        }
    }
}
