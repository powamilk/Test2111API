using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDAL.Entities;

namespace TestDAL.Repositories.Interface
{
    public interface IUserRepo
    {
        Task<IEnumerable<User>> GetAllUserAsync();
        Task<User> GetByIdAsync(int id);
        Task AddUserAsync(User user);
        Task DeleteUserAsync(int id);
        Task UpdateUserAsync(User user);
    }
}
