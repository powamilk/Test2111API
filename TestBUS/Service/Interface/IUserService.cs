using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestBUS.ViewModel.User;

namespace TestBUS.Service.Interface
{
    public interface IUserService
    {
        Task<IEnumerable<UserVM>> GetAll(); 
        Task<UserVM> GetById(int id);
        Task<int> AddUserAsync(UserCreateVM vm);
        Task UpdateUserAsync(UserUpdateVM vm);
        Task DeleteUserAsync(int id);
    }
}
