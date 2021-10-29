using System;
using System.Collections.Generic;

#nullable disable

namespace time_and_attendance_system_api.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
    }
}
