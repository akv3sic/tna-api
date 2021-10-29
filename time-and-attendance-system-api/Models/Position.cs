using System;
using System.Collections.Generic;

#nullable disable

namespace time_and_attendance_system_api.Models
{
    public partial class Position
    {
        public Position()
        {
            Employees = new HashSet<Employee>();
        }

        public short Id { get; set; }
        public string Name { get; set; }
        public short DepartmentId { get; set; }
        public string Description { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
