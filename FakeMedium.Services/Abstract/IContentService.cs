using FakeMedium.MODELS.DTO.Request.Content;
using FakeMedium.MODELS.DTO.Response;
using FakeMedium.MODELS.DTO.Response.Content;
using FakeMedium.MODELS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeMedium.SERVICES.Abstract
{
    public interface IContentService
    {
        List<HomeContentResponse> GetAllContents();
        HomeContentResponse GetContentById(string id);
        string AddNewContent(AddNewContentRequest request);
        bool IsExist(int id);
        ContentSimpleResponse UpdateContent(UpdateContentRequest request);
        string DeleteContent(int id);
        List<HomeContentResponse> SearchContent(string query);
    }
}
