using FakeMedium.MODELS.DTO.Request.Category;
using FakeMedium.MODELS.DTO.Response.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeMedium.SERVICES.Abstract
{
    public interface ICategoryService
    {
        List<CategorySimpleResponse> GetAllCategories();
        CategorySimpleResponse GetCategoryById(string id);
        string AddNewCategory(AddNewCategoryRequest entity);
        string DeleteCategory(int id);
        bool IsExist(int id);
        CategorySimpleResponse UpdateEntity(UpdateCategoryRequest entity);
    }
}
