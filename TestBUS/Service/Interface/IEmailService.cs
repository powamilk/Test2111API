using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestBUS.ViewModel.Email;

namespace TestBUS.Service.Interface
{
    public interface IEmailService
    {
        Task<IEnumerable<EmailVM>> GetAllEmailsAsync();
        Task<EmailVM> GetEmailByIdAsync(int id);
        Task AddEmailAsync(EmailCreateVM emailCreateVM);
        Task UpdateEmailAsync(EmailUpdateVM emailUpdateVM);
        Task DeleteEmailAsync(int id);
        Task<IEnumerable<EmailVM>> GetEmailsByUserIdAsync(int userId);
    }
}
