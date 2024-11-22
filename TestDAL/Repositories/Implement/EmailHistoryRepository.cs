using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDAL.Entities;
using TestDAL.Repositories.Interface;

namespace TestDAL.Repositories.Implement
{
    public class EmailHistoryRepository : IEmailHistoryRepository
    {
        private readonly AppDbContext _context;

        public EmailHistoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmailHistory>> GetAllAsync()
        {
            return await _context.EmailHistories.ToListAsync();
        }

        public async Task<EmailHistory> GetByIdAsync(int id)
        {
            return await _context.EmailHistories.FindAsync(id);
        }

        public async Task AddAsync(EmailHistory emailHistory)
        {
            await _context.EmailHistories.AddAsync(emailHistory);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(EmailHistory emailHistory)
        {
            _context.EmailHistories.Update(emailHistory);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var emailHistory = await _context.EmailHistories.FindAsync(id);
            if (emailHistory != null)
            {
                _context.EmailHistories.Remove(emailHistory);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<EmailHistory>> GetByEmailIdAsync(int emailId)
        {
            return await _context.EmailHistories
                .Where(eh => eh.EmailId == emailId)
                .ToListAsync();
        }
    }
}
