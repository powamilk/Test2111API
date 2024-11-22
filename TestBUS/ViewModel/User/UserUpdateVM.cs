using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBUS.ViewModel.User
{
    public class UserUpdateVM
    {
        public int UserId { get; set; }

        public string Email { get; set; } = null!;

        public string Name { get; set; } = null!;

        public bool? IsVerified { get; set; }

        public string? Status { get; set; }

        public string? PhoneNumber { get; set; }

    }
}
