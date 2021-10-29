using System;
using System.Collections.Generic;

#nullable disable

namespace time_and_attendance_system_api.Models
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public int RoleId { get; set; }
        public string Role1 { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
