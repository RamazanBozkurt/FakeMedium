using FakeMedium.MODELS.DTO.Request.Content;
using FakeMedium.SERVICES.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FakeMedium.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentsController : ControllerBase
    {
        private readonly IContentService _contentService;
        public ContentsController(IContentService contentService)
        {
            _contentService = contentService;
        }

        [HttpGet]
        public IActionResult GetAllContents()
        {
            var responses = _contentService.GetAllContents();

            if(responses == null)
            {
                return NotFound("The contents you were looking for was not found.");
            }

            return Ok(responses);
        }

        [HttpGet("{id}")]
        public IActionResult GetContentById([FromRoute]string id)
        {
            var response = _contentService.GetContentById(id);

            if(response == null)
            {
                return NotFound("The content you were looking for was not found.");
            }

            return Ok(response);
        }

        [HttpGet("Search/{query}")]
        public IActionResult SearchContent([FromRoute]string query)
        {
            var response = _contentService.SearchContent(query);
            if(response == null)
            {
                return NotFound("No content found matching your search criteria.");
            }
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Author")]
        public IActionResult AddNewContent([FromBody]AddNewContentRequest request)
        {
            if (ModelState.IsValid)
            {
                string lastContentId = _contentService.AddNewContent(request);
                return CreatedAtAction(nameof(GetContentById), new { id = lastContentId }, null);
            }

            return BadRequest(ModelState);
        }

        [HttpPut]
        [Authorize(Roles = "Admin,Author")]
        public IActionResult UpdateContent([FromRoute]int id, UpdateContentRequest request)
        {
            var isExist = _contentService.IsExist(id);

            if (isExist)
            {
                if (ModelState.IsValid)
                {
                    var response = _contentService.UpdateContent(request);
                    return Ok(response);
                }
                return BadRequest(ModelState);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Author")]
        public IActionResult DeleteContent([FromRoute] int id)
        {
            var isExist = _contentService.IsExist(id);

            if (isExist)
            {
                var response = _contentService.DeleteContent(id);
                return Ok($"{response} IS DELETED.");
            }

            return NotFound();
        }
    }
}
