using System;
using System.Collections.Generic;

#nullable disable

namespace time_and_attendance_system_api.Models
{
    public partial class AttendanceRecord
    {
        public int Id { get; set; }
        public DateTime? TimeIn { get; set; }
        public DateTime? TimeOut { get; set; }
        public byte InTypeId { get; set; }
        public byte OutTypeId { get; set; }
        public int EmployeeId { get; set; }
        public string Remark { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual InType InType { get; set; }
        public virtual OutType OutType { get; set; }
    }
}
