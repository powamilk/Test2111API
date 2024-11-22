using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestBUS.Service.Interface;
using TestBUS.ViewModel.Email;
using TestDAL.Entities;
using TestDAL.Repositories.Interface;

namespace TestBUS.Service.Implement
{
    public class EmailService : IEmailService
    {
        private readonly IEmailRepository _emailRepository;
        private readonly IMapper _mapper;

        public EmailService(IEmailRepository emailRepository, IMapper mapper)
        {
            _emailRepository = emailRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<EmailVM>> GetAllEmailsAsync()
        {
            var emails = await _emailRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<EmailVM>>(emails);
        }
        public async Task<EmailVM> GetEmailByIdAsync(int id)
        {
            var email = await _emailRepository.GetByIdAsync(id);
            return _mapper.Map<EmailVM>(email);
        }
        public async Task AddEmailAsync(EmailCreateVM emailCreateVM)
        {
            var emailEntity = _mapper.Map<Email>(emailCreateVM);
            await _emailRepository.AddAsync(emailEntity);
        }
        public async Task UpdateEmailAsync(EmailUpdateVM emailUpdateVM)
        {
            var emailEntity = _mapper.Map<Email>(emailUpdateVM);
            await _emailRepository.UpdateAsync(emailEntity);
        }

        public async Task DeleteEmailAsync(int id)
        {
            await _emailRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<EmailVM>> GetEmailsByUserIdAsync(int userId)
        {
            var emails = await _emailRepository.GetByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<EmailVM>>(emails);
        }
    }
}
