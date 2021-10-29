using System;
using System.Collections.Generic;

#nullable disable

namespace time_and_attendance_system_api.Models
{
    public partial class Department
    {
        public Department()
        {
            Positions = new HashSet<Position>();
        }

        public short Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Position> Positions { get; set; }
    }
}
