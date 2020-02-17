using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Repositories
{
    public class SessionContext : ApiDbContext
    {
        public SessionContext(DbContextOptions<ApiDbContext> options) : base(options) { }
 
        public Entities.Session Find(Guid id)
        {
            var session = Sessions.SingleOrDefault(m => m.Id == id);

            return session;
        }

        public bool Add(Entities.Session session)
        {
            //Expira todas as sessions deste usuario
            List<Entities.Session> sessions = Sessions.Where(s => s.UserID  == session.UserID).ToList();
            sessions.ForEach(a => { a.DtExpire = DateTime.Now; });

            //Cria a nova sessao
            Sessions.Add(session);

            SaveChanges();

            return true;
        }

        public bool Expire(Guid id)
        {
            var session = Sessions.SingleOrDefault(m => m.Id == id);

            if (session == null)
                return false;

            Sessions.Update(new Entities.Session
            {
                Id = session.Id,
                DtExpire = DateTime.Now 
            });

            SaveChanges();
             
            return true;
        }
    }
}
