using AutoMapper;
using FakeMedium.MODELS.DTO.Request.Content;
using FakeMedium.MODELS.DTO.Response;
using FakeMedium.MODELS.DTO.Response.Content;
using FakeMedium.MODELS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeMedium.SERVICES.Extension
{
    public static class ContentExtensions
    {
        public static List<HomeContentResponse> ConvertContentsToHomeContentResponses (this List<Content> contents, IMapper mapper)
        {
            var dto = mapper.Map<List<HomeContentResponse>>(contents);
            return dto;
        }

        public static HomeContentResponse ConvertContentToHomeContentResponse(this Content content, IMapper mapper)
        {
            return mapper.Map<HomeContentResponse>(content);
        }

        public static Content ConvertAddNewContentRequestToContent (this AddNewContentRequest request, IMapper mapper)
        {
            return mapper.Map<Content>(request);
        }

        public static Content ConvertUpdateContentRequestToContent (this UpdateContentRequest request, IMapper mapper)
        {
            return mapper.Map<Content>(request);
        }

        public static ContentSimpleResponse ConvertContentToContentSimpleResponse (this Content content, IMapper mapper)
        {
            return mapper.Map<ContentSimpleResponse>(content);
        }
    }
}
