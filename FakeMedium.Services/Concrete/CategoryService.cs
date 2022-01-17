using AutoMapper;
using FakeMedium.DATA.Repository.Abstract;
using FakeMedium.MODELS.DTO.Request.Category;
using FakeMedium.MODELS.DTO.Response.Category;
using FakeMedium.SERVICES.Abstract;
using FakeMedium.SERVICES.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeMedium.SERVICES.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public string AddNewCategory(AddNewCategoryRequest entity)
        {
            var addedCategory = entity.ConvertAddNewCategoryRequestToCategory(_mapper);
            return _categoryRepository.AddNewEntity(addedCategory);
        }

        public string DeleteCategory(int id)
        {
            return _categoryRepository.DeleteEntity(id);
        }

        public List<CategorySimpleResponse> GetAllCategories()
        {
            var categories = _categoryRepository.GetAllEntities();
            var dto = categories.ConvertCategoriesToCategorySimpleResponses(_mapper);
            return dto;
        }

        public CategorySimpleResponse GetCategoryById(string id)
        {
            var category = _categoryRepository.GetEntityById(id);
            var dto = category.ConvertCategoryToCategorySimpleResponse(_mapper);
            return dto;
        }

        public bool IsExist(int id)
        {
            return _categoryRepository.IsExist(id);
        }

        public CategorySimpleResponse UpdateEntity(UpdateCategoryRequest entity)
        {
            var updatedCategory = entity.ConvertUpdateCategoryRequestToCategory(_mapper);
            var dto = _categoryRepository.UpdateEntity(updatedCategory);
            return dto.ConvertCategoryToCategorySimpleResponse(_mapper);
        }
    }
}
