using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDAL.Entities;

namespace TestDAL.Repositories.Interface
{
    public interface IEmailRepository
    {
        Task<IEnumerable<Email>> GetAllAsync();
        Task<Email> GetByIdAsync(int id);
        Task AddAsync(Email email);
        Task UpdateAsync(Email email);
        Task DeleteAsync(int id);
        Task<IEnumerable<Email>> GetByUserIdAsync(int userId);
    }
}
