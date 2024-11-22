using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestBUS.ViewModel.EmailHistory;

namespace TestBUS.Service.Interface
{
    public interface IEmailHistoryService
    {
        Task<IEnumerable<EmailHistoryVM>> GetAllAsync();
        Task<EmailHistoryVM> GetByIdAsync(int id);
        Task AddAsync(EmailHistoryCreateVM emailHistoryCreateVM);
        Task UpdateAsync(EmailHistoryUpdateVM emailHistoryUpdateVM);
        Task DeleteAsync(int id);
        Task<IEnumerable<EmailHistoryVM>> GetByEmailIdAsync(int emailId);
    }
}
