using FakeMedium.MODELS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeMedium.DATA.Repository.Abstract
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User UserValidate(string username, string password);
        List<User> SearchUser(string query);
    }
}
