using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAuthorizationService _authorizationService;

        public AuthenticationController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        [HttpPost("login")]
        public ApiResponse<Models.Authorization> Authenticate([FromBody]AuthenticateModel model)
        {
            var authorization = _authorizationService.Authenticate(model.Username, model.Password);

            if (authorization == null)
            {

                return new ApiResponse<Models.Authorization>()
                {
                    Status = HttpStatusCode.Unauthorized,
                    Message = "Usuário ou Senha Inválidos!"
                };
            }

            return new ApiResponse<Models.Authorization>()
            {
                Message = "Login efetuado com sucesso!",
                Result = authorization
            };
        }

        [HttpPost("logout")]
        public ApiResponse<bool> Logout(Guid sessionID)
        {
            var res = _authorizationService.LogOut(sessionID);

            if (!res)
            {

                return new ApiResponse<bool>()
                {
                    Status = HttpStatusCode.Unauthorized,
                    Message = "Sessão não localizada!",
                    Result = res
                };
            }

            return new ApiResponse<bool>()
            {
                Message = "Logout efetuado com sucesso!",
                Result = res
            };
        }

    }
}