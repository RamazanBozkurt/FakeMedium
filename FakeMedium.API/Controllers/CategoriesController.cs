using FakeMedium.MODELS.DTO.Request.Category;
using FakeMedium.SERVICES.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FakeMedium.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        
        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var categories = _categoryService.GetAllCategories();

            if(categories == null)
            {
                return NotFound();
            }

            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById([FromRoute] int id)
        {
            var category = _categoryService.GetCategoryById(id.ToString());

            if(category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPost]
        //[Authorize(Roles = "Admin,Author")]
        public IActionResult AddNewCategory([FromBody]AddNewCategoryRequest request)
        {
            if (ModelState.IsValid)
            {
                string lastCategoryId = _categoryService.AddNewCategory(request);
                return CreatedAtAction(nameof(GetCategoryById), new { id = lastCategoryId }, null);
            }

            return BadRequest(ModelState);
        }

        [HttpPut]
        [Authorize(Roles = "Admin,Author")]
        public IActionResult UpdateCategory([FromBody]UpdateCategoryRequest request)
        {
            var isExist = _categoryService.IsExist(request.Id);

            if (isExist)
            {
                if (ModelState.IsValid)
                {
                    var updatedCategory = _categoryService.UpdateEntity(request);
                    return Ok(updatedCategory);
                }

                return BadRequest(ModelState);
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Author")]
        public IActionResult DeleteCategory([FromRoute] int id)
        {
            var isExist = _categoryService.IsExist(id);

            if (isExist)
            {
                var deletedCategory = _categoryService.DeleteCategory(id);
                return Ok($"{deletedCategory} IS DELETED.");
            }

            return NotFound();
        }
    }
}
