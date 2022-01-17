using AutoMapper;
using FakeMedium.DATA.Context;
using FakeMedium.DATA.Repository.Abstract;
using FakeMedium.MODELS.DTO.Request.User;
using FakeMedium.MODELS.DTO.Response.User;
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
    public class UserService : IUserService
    {
        private readonly FakeMediumDbContext _context;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(FakeMediumDbContext context, IUserRepository userRepository, IMapper mapper)
        {
            _context = context;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public string AddNewUser(AddNewUserRequest request)
        {
            var user = request.ConvertAddNewUserRequestToUser(_mapper);
            var response = _userRepository.AddNewEntity(user);
            return response;
        }

        public string DeleteUser(int id)
        {
            return _userRepository.DeleteEntity(id);
        }

        public List<UserSimpleResponse> GetAllUsers()
        {
            var users = _userRepository.GetAllEntities();
            var dto = users.ConvertUserToUserSimpleResponse(_mapper);
            return dto;
        }

        public UserSimpleResponse GetUserById(int id)
        {
            var user = _userRepository.GetEntityById(id.ToString());
            var dto = user.ConvertUserToUserSimpleResponse(_mapper);
            return dto;
        }

        public bool IsExist(int id)
        {
            return _userRepository.IsExist(id);
        }

        public List<UserSimpleResponse> SearchUser(string query)
        {
            var dto = _userRepository.SearchUser(query);
            var response = dto.ConvertUserToUserSimpleResponse(_mapper);
            return response;
        }

        public UserSimpleResponse UpdateUser(UpdateUserRequest request)
        {
            var user = request.ConvertUpdateUserRequestToUser(_mapper);
            var response = _userRepository.UpdateEntity(user);
            return response.ConvertUserToUserSimpleResponse(_mapper);
        }

        public User UserValidate(string username, string password)
        {
            return _userRepository.UserValidate(username, password);
        }
    }
}
