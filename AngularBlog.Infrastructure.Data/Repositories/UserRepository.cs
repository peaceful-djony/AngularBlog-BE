using System.Collections.Generic;
using AngularBlog.Domain.Interfaces.Repositories;
using AngularBlog.Domain.Models;

namespace AngularBlog.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        public IEnumerable<int> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public int Get(User id)
        {
            throw new System.NotImplementedException();
        }

        public bool Create(int entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(int entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(User id)
        {
            throw new System.NotImplementedException();
        }

        public bool Save()
        {
            throw new System.NotImplementedException();
        }
    }
}