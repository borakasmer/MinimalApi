using System;
using System.Collections.Generic;

#nullable disable

namespace DevNot2021.Entities
{
    public partial class Users
    {
        public Users()
        {
            UserRoles = new HashSet<UserRoles>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string Gsm { get; set; }
        public bool IsDeleted { get; set; }
        public bool? IsAdmin { get; set; }

        public virtual ICollection<UserRoles> UserRoles { get; set; }
    }
}
