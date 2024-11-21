using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestBUS.Service.Interface;
using TestBUS.ViewModel;
using TestDAL.Entities;
using TestDAL.Repositories.Interface;

namespace TestBUS.Service.Implement
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _repo;
        private readonly IMapper _mapper;

        public UserService(IUserRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;   
        }
        public async Task<int> AddUserAsync(UserCreateVM vm)
        {
            var user = _mapper.Map<User>(vm);
            await _repo.AddUserAsync(user);
            return user.UserId;
        }

        public async Task DeleteUserAsync(int id)
        {
            await _repo.DeleteUserAsync(id);    
        }

        public async Task<IEnumerable<UserVM>> GetAll()
        {
            var user = await _repo.GetAllUserAsync();
            return _mapper.Map<IEnumerable<UserVM>>(user);  
        }

        public async Task<UserVM> GetById(int id)
        {
            var user = await _repo.GetByIdAsync(id);    
            if(user == null)
            {
                throw new KeyNotFoundException("Id ko ton tai");
            }
            return _mapper.Map<UserVM>(user);   
        }

        public async Task UpdateUserAsync(UserUpdateVM vm)
        {
            var user = _mapper.Map<User>(vm);
            await _repo.UpdateUserAsync(user);
        }
    }
}
