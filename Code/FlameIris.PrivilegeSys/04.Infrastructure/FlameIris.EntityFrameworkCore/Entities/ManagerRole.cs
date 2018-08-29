using System;
using System.Collections.Generic;

namespace FlameIris.EntityFrameworkCore.Enities
{
    public partial class ManagerRole : Entity<Int64>
    {
        public long ManagerId { get; set; }
        public long RoleId { get; set; }

        public Manager Manager { get; set; }
        public Role Role { get; set; }
    }
}
