using System;
using System.Collections.Generic;

namespace FlameIris.EntityFrameworkCore.Enities
{
    public partial class Manager : Entity<Int64>
    {
        public Manager()
        {
            ManagerRoles = new HashSet<ManagerRole>();
        }
        public string Username { get; set; }
        public string Password { get; set; }
        public string NickName { get; set; }
        public long? DeptId { get; set; }

        public Department Dept { get; set; }
        public ICollection<ManagerRole> ManagerRoles { get; set; }
    }
}
