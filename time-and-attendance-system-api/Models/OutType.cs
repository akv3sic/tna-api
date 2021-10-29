using System;
using System.Collections.Generic;

#nullable disable

namespace time_and_attendance_system_api.Models
{
    public partial class OutType
    {
        public OutType()
        {
            AttendanceRecords = new HashSet<AttendanceRecord>();
        }

        public byte Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<AttendanceRecord> AttendanceRecords { get; set; }
    }
}
