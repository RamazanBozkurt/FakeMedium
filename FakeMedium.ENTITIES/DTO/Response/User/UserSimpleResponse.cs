using FakeMedium.MODELS.DTO.Response.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeMedium.MODELS.DTO.Response.User
{
    public class UserSimpleResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string About { get; set; }
        public List<HomeContentResponse> Contents { get; set; }
    }
}
