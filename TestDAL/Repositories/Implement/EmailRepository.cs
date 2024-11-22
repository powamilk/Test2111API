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
    public class EmailRepository : IEmailRepository
    {
        private readonly AppDbContext _context;

        public EmailRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Email>> GetAllAsync()
        {
            return await _context.Emails.ToListAsync();
        }

        public async Task<Email> GetByIdAsync(int id)
        {
            return await _context.Emails.FindAsync(id);
        }

        public async Task AddAsync(Email email)
        {
            await _context.Emails.AddAsync(email);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Email email)
        {
            _context.Emails.Update(email);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var email = await _context.Emails.FindAsync(id);
            if (email != null)
            {
                _context.Emails.Remove(email);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Email>> GetByUserIdAsync(int userId)
        {
            return await _context.Emails
                .Where(e => e.UserId == userId)
                .ToListAsync();
        }
    }
}
