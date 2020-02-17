using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Repositories;

namespace WebApi.Services
{
    public interface IFlightService
    {
        List<WebApi.Entities.Flight> GetAll();
        WebApi.Entities.Flight GetByID(int id);
        bool Edit(WebApi.Entities.Flight flight);
        bool Delete(int id);
        bool Add(WebApi.Entities.Flight flight);
    }


    public class FlightService : IFlightService
    {
        private readonly FlightContext flightContext;
        public FlightService(DbContextOptions<ApiDbContext> options)
        {
            flightContext = new FlightContext(options);
        }
 

        public List<WebApi.Entities.Flight> GetAll()
        {
            return flightContext.GetAll();
        }

        public WebApi.Entities.Flight GetByID(int id)
        {
            return flightContext.Find(id);
        }

        public bool Edit(WebApi.Entities.Flight flight)
        {
            return flightContext.Edit(flight);
        }

        public bool Delete(int id)
        {
            return flightContext.Delete(id);
        }

        public bool Add(WebApi.Entities.Flight flight)
        {
            return flightContext.Add(flight);
        }
         
    }
}
