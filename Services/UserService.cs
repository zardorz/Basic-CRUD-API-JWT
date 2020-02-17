using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Repositories;

namespace WebApi.Services
{
    public interface IUserService
    {
        List<User> GetAll();
    }

    public class UserService : IUserService
    {
        private readonly UserContext context;
        public UserService(DbContextOptions<ApiDbContext> options)
        {
            context = new UserContext(options);
        }
      
        public List<User> GetAll()
        {
            return context.GetAll();
        }
    }
}