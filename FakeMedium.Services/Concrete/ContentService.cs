using AutoMapper;
using FakeMedium.DATA.Repository.Abstract;
using FakeMedium.MODELS.DTO.Request.Content;
using FakeMedium.MODELS.DTO.Response;
using FakeMedium.MODELS.DTO.Response.Content;
using FakeMedium.MODELS.Entity;
using FakeMedium.SERVICES.Abstract;
using FakeMedium.SERVICES.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeMedium.SERVICES.Concrete
{
    public class ContentService : IContentService
    {
        private readonly IContentRepository _contentRepository;
        private readonly IMapper _mapper;
        public ContentService(IContentRepository contentRepository, IMapper mapper)
        {
            _contentRepository = contentRepository;
            _mapper = mapper;
        }

        public string AddNewContent(AddNewContentRequest request)
        {
            var dto = request.ConvertAddNewContentRequestToContent(_mapper);
            var response = _contentRepository.AddNewEntity(dto);
            return response;
        }

        public string DeleteContent(int id)
        {
            return _contentRepository.DeleteEntity(id);
        }

        public List<HomeContentResponse> GetAllContents()
        {
            var responses = _contentRepository.GetAllEntities();
            var dto = responses.ConvertContentsToHomeContentResponses(_mapper);
            return dto;
        }

        public HomeContentResponse GetContentById(string id)
        {
            var response = _contentRepository.GetEntityById(id);
            var dto = response.ConvertContentToHomeContentResponse(_mapper);
            return dto;
        }

        public bool IsExist(int id)
        {
            return _contentRepository.IsExist(id);
        }

        public List<HomeContentResponse> SearchContent(string query)
        {
            var response = _contentRepository.SearchContent(query);
            var dto = response.ConvertContentsToHomeContentResponses(_mapper);
            return dto;
        }

        public ContentSimpleResponse UpdateContent(UpdateContentRequest request)
        {
            var dto = request.ConvertUpdateContentRequestToContent(_mapper);
            var response = _contentRepository.UpdateEntity(dto);
            return response.ConvertContentToContentSimpleResponse(_mapper);
        }
    }
}
