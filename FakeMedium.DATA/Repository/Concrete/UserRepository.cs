using FakeMedium.DATA.Context;
using FakeMedium.DATA.Repository.Abstract;
using FakeMedium.MODELS.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeMedium.DATA.Repository.Concrete
{
    public class UserRepository : IUserRepository
    {
        private readonly FakeMediumDbContext _context;
        public UserRepository(FakeMediumDbContext context)
        {
            _context = context;
        }

        public string AddNewEntity(User entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();
            return entity.Id.ToString();
        }

        public string DeleteEntity(int id)
        {
            var deletedUser = _context.Users.Where(user => user.Id == id).FirstOrDefault();
            _context.Users.Remove(deletedUser);
            return deletedUser.UserName;
        }

        public List<User> GetAllEntities()
        {
            return _context.Users.Include(user => user.Contents).ThenInclude(content => content.Category).ToList();
        }

        public User GetEntityById(string id)
        {
            return _context.Users.Where(user => user.Id.ToString() == id).Include(user => user.Contents).ThenInclude(content => content.Category).FirstOrDefault();
        }

        public bool IsExist(int id)
        {
            return _context.Users.Any(user => user.Id == id);
        }

        public List<User> SearchUser(string query)
        {
            var response = _context.Users.Where(user => user.Name.ToLower().Contains(query.ToLower())
                                                     || user.Surname.ToLower().Contains(query.ToLower())
                                                     || user.UserName.ToLower().Contains(query.ToLower())
                                                     || user.About.ToLower().Contains(query.ToLower())
                                                     ).ToList();
            return response;
        }

        public User UpdateEntity(User entity)
        {
            _context.Users.Update(entity);
            _context.SaveChanges();
            return entity;
        }

        public User UserValidate(string username, string password)
        {
            return _context.Users.Where(user => user.UserName == username && user.Password == password).FirstOrDefault();
        }
    }
}
