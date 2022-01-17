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
    public class ContentRepository : IContentRepository
    {
        private readonly FakeMediumDbContext _context;
        public ContentRepository(FakeMediumDbContext context)
        {
            _context = context;
        }

        public string AddNewEntity(Content entity)
        {
            _context.Contents.Add(entity);
            _context.SaveChanges();
            return entity.Id.ToString();
        }

        public string DeleteEntity(int id)
        {
            var deletedContent = _context.Contents.Where(content => content.Id == id).FirstOrDefault();
            _context.Contents.Remove(deletedContent);
            _context.SaveChanges();
            return deletedContent.ContentHeader;
        }

        public List<Content> GetAllEntities()
        {
            return _context.Contents.Include(content => content.Category).Include(content => content.User).ToList();
        }

        public Content GetEntityById(string id)
        {
            return _context.Contents.Where(content => content.Id.ToString() == id).Include(content => content.Category).Include(content => content.User).FirstOrDefault();
        }

        public bool IsExist(int id)
        {
            return _context.Contents.Any(content => content.Id == id);
        }

        public List<Content> SearchContent(string query)
        {
            var response = _context.Contents.Where(c => c.ContentHeader.ToLower().Contains(query.ToLower())
                                                     || c.ContentBody.ToLower().Contains(query.ToLower())
                                                     || c.ContentDetails.ToLower().Contains(query.ToLower())
            ).ToList();
            return response;
        }

        public Content UpdateEntity(Content entity)
        {
            _context.Contents.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
