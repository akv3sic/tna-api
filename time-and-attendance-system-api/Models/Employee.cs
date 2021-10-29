using System;
using System.Collections.Generic;

#nullable disable

namespace time_and_attendance_system_api.Models
{
    public partial class Employee
    {
        public Employee()
        {
            AttendanceRecords = new HashSet<AttendanceRecord>();
        }

        public int Id { get; set; }
        public string CardId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public short PositionId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Position Position { get; set; }
        public virtual ICollection<AttendanceRecord> AttendanceRecords { get; set; }
    }
}
