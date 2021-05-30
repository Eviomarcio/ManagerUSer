using System.Threading.Tasks;
using System.Collections.Generic;
using Manager.Domain.Entities;
using Manager.Infra.Interfaces;

namespace Manager.Infra.interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByEmail(string email);
        Task<List<User>> SearchByEmail(string email);
        Task<List<User>> SearchByName(string name);
    }
}