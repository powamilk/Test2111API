using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDAL.Entities;

namespace TestDAL.Repositories.Interface
{
    public interface IEmailHistoryRepository
    {
        Task<IEnumerable<EmailHistory>> GetAllAsync();
        Task<EmailHistory> GetByIdAsync(int id);
        Task AddAsync(EmailHistory emailHistory);
        Task UpdateAsync(EmailHistory emailHistory);
        Task DeleteAsync(int id);
        Task<IEnumerable<EmailHistory>> GetByEmailIdAsync(int emailId);
    }
}
