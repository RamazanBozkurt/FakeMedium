using AutoMapper;
using FakeMedium.MODELS.DTO.Request.User;
using FakeMedium.MODELS.DTO.Response.User;
using FakeMedium.MODELS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeMedium.SERVICES.Extension
{
    public static class UserExtensions
    {
        public static List<UserSimpleResponse> ConvertUserToUserSimpleResponse (this List<User> users, IMapper mapper)
        {
            return mapper.Map<List<UserSimpleResponse>>(users);
        }
        public static UserSimpleResponse ConvertUserToUserSimpleResponse (this User user, IMapper mapper)
        {
            return mapper.Map<UserSimpleResponse>(user);
        }

        public static User ConvertAddNewUserRequestToUser (this AddNewUserRequest request, IMapper mapper)
        {
            return mapper.Map<User>(request);
        }

        public static User ConvertUpdateUserRequestToUser (this UpdateUserRequest request, IMapper mapper)
        {
            return mapper.Map<User>(request);
        }

        public static List<User> ConvertUserSimpleResponseToUser (this List<UserSimpleResponse> userSimpleResponses, IMapper mapper)
        {
            return mapper.Map<List<User>>(userSimpleResponses);
        }
    }
}
