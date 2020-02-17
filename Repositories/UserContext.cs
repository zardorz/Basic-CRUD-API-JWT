using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;

namespace WebApi.Repositories
{
    public class UserContext : ApiDbContext
    {
        public UserContext(DbContextOptions<ApiDbContext> options): base(options) { }

        public List<User> GetAll()
        {
            var users = Users.ToList();

            return users;
        }

        public User Find(int id)
        {
            var user = Users.SingleOrDefault(m => m.Id  == id);  

            return user;
        }


        public bool Add(Entities.Session session)
        {
            //Expira todas as sessions deste usuario
            List<Entities.Session> sessions = Sessions.Where(s => s.UserID == session.UserID).ToList();
            sessions.ForEach(a => { a.DtExpire = DateTime.Now; });

            //Cria a nova sessao
            Sessions.Add(session);

            SaveChanges();

            return true;
        }

    }
}
