using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeMedium.MODELS.DTO.Response.Content
{
    public class HomeContentResponse
    {
        public int Id { get; set; }
        public string ContentHeader { get; set; }
        public string ContentDetails { get; set; }
        public string ImageUrl { get; set; }

        public string CategoryName { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
    }
}
