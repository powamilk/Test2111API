using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestBUS.Service.Interface;
using TestBUS.ViewModel.EmailHistory;
using TestDAL.Entities;
using TestDAL.Repositories.Interface;

namespace TestBUS.Service.Implement
{
    public class EmailHistoryService : IEmailHistoryService
    {
        private readonly IEmailHistoryRepository _emailHistoryRepository;
        private readonly IMapper _mapper;

        public EmailHistoryService(IEmailHistoryRepository emailHistoryRepository, IMapper mapper)
        {
            _emailHistoryRepository = emailHistoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmailHistoryVM>> GetAllAsync()
        {
            var emailHistories = await _emailHistoryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<EmailHistoryVM>>(emailHistories);
        }

        public async Task<EmailHistoryVM> GetByIdAsync(int id)
        {
            var emailHistory = await _emailHistoryRepository.GetByIdAsync(id);
            return _mapper.Map<EmailHistoryVM>(emailHistory);
        }

        public async Task AddAsync(EmailHistoryCreateVM emailHistoryCreateVM)
        {
            var emailHistoryEntity = _mapper.Map<EmailHistory>(emailHistoryCreateVM);
            await _emailHistoryRepository.AddAsync(emailHistoryEntity);
        }

        public async Task UpdateAsync(EmailHistoryUpdateVM emailHistoryUpdateVM)
        {
            var emailHistoryEntity = _mapper.Map<EmailHistory>(emailHistoryUpdateVM);
            await _emailHistoryRepository.UpdateAsync(emailHistoryEntity);
        }

        public async Task DeleteAsync(int id)
        {
            await _emailHistoryRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<EmailHistoryVM>> GetByEmailIdAsync(int emailId)
        {
            var emailHistories = await _emailHistoryRepository.GetByEmailIdAsync(emailId);
            return _mapper.Map<IEnumerable<EmailHistoryVM>>(emailHistories);
        }
    }
}
