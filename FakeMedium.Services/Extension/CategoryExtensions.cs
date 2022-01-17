using AutoMapper;
using FakeMedium.MODELS.DTO.Request.Category;
using FakeMedium.MODELS.DTO.Response.Category;
using FakeMedium.MODELS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeMedium.SERVICES.Extension
{
    public static class CategoryExtensions
    {
        public static Category ConvertAddNewCategoryRequestToCategory(this AddNewCategoryRequest request, IMapper mapper)
        {
            return mapper.Map<Category>(request);
        }

        public static List<CategorySimpleResponse> ConvertCategoriesToCategorySimpleResponses(this List<Category> categories, IMapper mapper)
        {
            return mapper.Map<List<CategorySimpleResponse>>(categories);
        }

        public static CategorySimpleResponse ConvertCategoryToCategorySimpleResponse(this Category category, IMapper mapper)
        {
            return mapper.Map<CategorySimpleResponse>(category);
        }

        public static Category ConvertUpdateCategoryRequestToCategory(this UpdateCategoryRequest request, IMapper mapper)
        {
            return mapper.Map<Category>(request);
        }
    }
}
