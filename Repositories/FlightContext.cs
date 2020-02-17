using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;

namespace WebApi.Repositories
{
    public class FlightContext : ApiDbContext
    {
        public FlightContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        public List<Flight> GetAll()
        {
            var flights = Flights.ToList();

            return flights;
        }

        public Flight Find(int id)
        {
            var user = Flights.SingleOrDefault(m => m.Id == id);

            return user;
        }

        public bool Add(Entities.Flight flight)
        {
            //Cria a nova sessao
            Flights.Add(flight);

            SaveChanges();

            return true;
        }

        public bool Edit(Entities.Flight flight)
        {
            var flightItem = Flights.SingleOrDefault(m => m.Id == flight.Id);

            if (flightItem == null)
                return false;
            
            Entry(flightItem).State = EntityState.Detached;

            Flights.Update(new Entities.Flight
            {
                Id = flight.Id,
                Destiny = flight.Destiny,
                DateDeparture = flight.DateDeparture,
                TimeDeparture = flight.TimeDeparture,
                Name = flight.Name,
                Source = flight.Source
            });

            SaveChanges();

            return true;
        }

        public bool Delete(int id)
        {
            var flightItem = Flights.SingleOrDefault(m => m.Id == id);

            if (flightItem == null)
                return false;

            Flights.Remove(flightItem);

            SaveChanges();

            return true;
        }
    }
}
