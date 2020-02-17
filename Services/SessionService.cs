using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Repositories;

namespace WebApi.Services
{
    public interface ISessionService
    {
        Entities.Session Find(Guid id);
        bool Add(Entities.Session session);
        bool Expire(Guid id);
    }

    public class SessionService : ISessionService
    {
        private readonly SessionContext context;
        public SessionService(DbContextOptions<ApiDbContext> options)
        {
            context = new SessionContext(options);
        }

        public Session Find(Guid id)
        {
            return context.Find(id);
        }
        public bool Add(Session session)
        {
            return context.Add(session);
        }
        public bool Expire(Guid id)
        {
            return context.Expire(id);
        }
    }
         
}
