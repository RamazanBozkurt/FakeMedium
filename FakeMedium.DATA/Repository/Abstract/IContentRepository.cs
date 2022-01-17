using FakeMedium.MODELS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeMedium.DATA.Repository.Abstract
{
    public interface IContentRepository : IGenericRepository<Content>
    {
        List<Content> SearchContent(string query);
    }
}
