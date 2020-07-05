using System.Collections.Generic;
using System.Linq;
using AngularBlog.Domain.Interfaces.Repositories;
using AngularBlog.Domain.Models;

namespace AngularBlog.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static readonly User[] Users = {
            new User{Id = 1, Email = "zep@ya.ru", Password = "pass"},
            new User{Id = 2, Email = "zep@gmail.com", Password = "pass"},
        };
        
        public IEnumerable<User> GetAll()
        {
            return Users;
        }

        public User Get(int id)
        {
            return Users.SingleOrDefault(u => u.Id == id);
        }

        public bool Create(User entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(User entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Save()
        {
            throw new System.NotImplementedException();
        }
    }
}