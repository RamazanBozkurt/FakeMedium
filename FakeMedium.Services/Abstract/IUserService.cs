using FakeMedium.MODELS.DTO.Request.User;
using FakeMedium.MODELS.DTO.Response.User;
using FakeMedium.MODELS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeMedium.SERVICES.Abstract
{
    public interface IUserService
    {
        User UserValidate(string username, string password);
        List<UserSimpleResponse> GetAllUsers();
        UserSimpleResponse GetUserById(int id);
        string AddNewUser(AddNewUserRequest request);
        UserSimpleResponse UpdateUser(UpdateUserRequest request);
        bool IsExist(int id);
        string DeleteUser(int id);
        List<UserSimpleResponse> SearchUser(string query);
    }
}
