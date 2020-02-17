using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Entities;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class FlightController : ControllerBase
    {
        private IFlightService _flightService;

        public FlightController(IFlightService flightService)
        {
            _flightService = flightService;
        }

        [HttpGet]
        public ApiResponse<List<Flight>> GetAll()
        {
            var res = _flightService.GetAll();
            if (res == null)
            {

                return new ApiResponse<List<Flight>>()
                {
                    Status = HttpStatusCode.Unauthorized,
                    Message = "Ocorreu ao localizar!"
                };
            }

            return new ApiResponse<List<Flight>>()
            {
                Message = "Registro localizados com sucesso!",
                Result = res
            };
        }

        [HttpGet]
        [Route("id/{id}")]
        public ApiResponse<Flight> GetByID(int id)
        {
            var res = _flightService.GetByID(id);
            if (res == null)
            {

                return new ApiResponse<Flight>()
                {
                    Status = HttpStatusCode.Unauthorized,
                    Message = "Ocorreu ao localizar  registro!"
                };
            }

            return new ApiResponse<Flight>()
            {
                Message = "registro localizado com sucesso!",
                Result = res
            };
        }

        [HttpPut]
        public ApiResponse<bool> Edit([FromBody] Flight flight)
        {
            var res = _flightService.Edit(flight);
            if (!res )
            {

                return new ApiResponse<bool>()
                {
                    Status = HttpStatusCode.Unauthorized,
                    Message = "Ocorreu um erro ao editar!",
                    Result = false
                };
            }

            return new ApiResponse<bool>()
            {
                Message = "Edição efetuada com sucesso!",
                Result = res
            };
        }
         
        [HttpDelete]
        [Route("id/{id}")]
        public ApiResponse<bool> Delete(int id)
        {
            var res = _flightService.Delete(id);
            if (!res)
            {

                return new ApiResponse<bool>()
                {
                    Status = HttpStatusCode.Unauthorized,
                    Message = "Ocorreu um erro ao excluir!",
                    Result = false
                };
            }

            return new ApiResponse<bool>()
            {
                Message = "Exclusão efetuada com sucesso!",
                Result = res
            };
        }

        [HttpPost]
        public ApiResponse<bool> Add([FromBody] Flight flight)
        {
            var res = _flightService.Add(flight);
            if (!res)
            {

                return new ApiResponse<bool>()
                {
                    Status = HttpStatusCode.Unauthorized,
                    Message = "Ocorreu um erro ao salvar!",
                    Result = false
                };
            }

            return new ApiResponse<bool>()
            {
                Message = "Cadastro efetuado com sucesso!",
                Result = res
            };
        }
    }
}