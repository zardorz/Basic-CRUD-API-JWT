using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebApi.Services;
using WebApi.Models;
using System.Linq;
using WebApi.Entities;
using System.Net;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ApiResponse<List<User>> GetAll()
        {
            var users = _userService.GetAll();

            if (users == null)
            {

                return new ApiResponse<List<User>>()
                {
                    Status = HttpStatusCode.Unauthorized,
                    Message = "Usuário ou Senha Inválidos!"
                };
            }

            return new ApiResponse<List<User>>()
            {
                Message = "Login efetuado com sucesso!",
                Result = users
            };
        }
    }
}
