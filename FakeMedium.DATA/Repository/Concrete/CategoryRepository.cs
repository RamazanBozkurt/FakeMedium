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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly FakeMediumDbContext _context;
        public CategoryRepository(FakeMediumDbContext context)
        {
            _context = context;
        }

        public string AddNewEntity(Category entity)
        {
            _context.Categories.Add(entity);
            _context.SaveChanges();
            return entity.Id.ToString();
        }

        public string DeleteEntity(int id)
        {
            var deletedCategory = _context.Categories.Where(category => category.Id == id).FirstOrDefault();
            _context.Categories.Remove(deletedCategory);
            _context.SaveChanges();
            return deletedCategory.Name;
        }

        public List<Category> GetAllEntities()
        {
            return _context.Categories.Include(category => category.Contents).ThenInclude(content => content.User).ToList();
        }

        public Category GetEntityById(string id)
        {
            return _context.Categories.Where(category => category.Id.ToString() == id).Include(category => category.Contents).ThenInclude(content => content.User).FirstOrDefault();
        }

        public bool IsExist(int id)
        {
            return _context.Categories.Any(category => category.Id == id);
        }

        public Category UpdateEntity(Category entity)
        {
            _context.Categories.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
