using FakeMedium.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeMedium.DATA.Repository.Abstract
{
    public interface IGenericRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAllEntities();
        T GetEntityById(string id);
        string AddNewEntity(T entity);
        bool IsExist(int id);
        T UpdateEntity(T entity);
        string DeleteEntity(int id); 
    }
}
