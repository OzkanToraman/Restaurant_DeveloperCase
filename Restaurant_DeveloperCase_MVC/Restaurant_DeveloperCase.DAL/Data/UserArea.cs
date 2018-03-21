using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_DeveloperCase.DAL.Data
{
    public class UserArea
    {
        public UserArea()
        {
            IsDeleted = false;
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public bool IsDeleted { get; set; }
        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
    }
}
