using FakeMedium.MODELS.DTO.Response.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeMedium.MODELS.Entity;

namespace FakeMedium.MODELS.DTO.Response.Category
{
    public class CategorySimpleResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<HomeContentResponse> Contents { get; set; }
    }
}
